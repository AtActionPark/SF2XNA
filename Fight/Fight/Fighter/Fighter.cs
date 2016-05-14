using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Fight.Animations;

namespace Fight
{
    public enum State { Idle,Walk, Hit,AirHit, Attack,Jump,JumpAttack, ForwardJump, KnockDown,Thrown,Technical, HighBlock, LowBlock, Crouch,Throw,TryThrow, Recover, StandUp }

    public class Fighter
    {
        public Vector2 Position;
        public Vector2 velocity;

        public Buffer buffer;
        public AttackState attackState;
        public AttackState projAttackState;
        public AnimationManager animManager;
        public State state;
        public IA IA;

        public List<Projectile> projectiles = new List<Projectile>();

        #region hitboxes
        public Rectangle HitBox;
        public Rectangle HurtBox;
        public Rectangle CollisionBox;
        public Rectangle GuardProcBox;

        Color hurtBoxColor = Color.Green;
        Color collisionBoxColor = Color.DarkGreen;
        Color hitBoxColor = Color.Red;
        Color guardProcBoxColor = Color.DarkRed;
        #endregion

        #region state bool
        public bool recovering = false;
        public bool wasHit = false;
        public bool crouching = false;
        public bool blocked = false;
        public bool blockStuned = false;
        public bool knockedDown = false;
        public bool isOnGround = true;
        public bool blocksHigh = false;
        public bool blocksLow = false;
        public bool guardProced = false;
        public bool projGuardProced = false;
        public bool neutralJumping = false;
        public bool close = false;
        public bool isJumping = false;
        public bool isStandHitting = false;
        public bool isCrouchHitting = false;
        public bool isCloseHitting = false;
        public bool isCommandHitting = false;
        public bool resetHit = false;
        public bool canThrow = false;
        public bool isThrowing = false;
        public bool thrown = false;
        public int throwDir = 1;
        public bool justThrew = false;
        public bool isTryingToThrow = false;
        public bool canKaraCancel = false;
        public bool technical = false;
        public bool startUp
        {
            get
            {
                return state == State.Attack &&
                    animManager.frameIndex <= animManager.GetAnim().startUp;
                }
        }
        public bool active
        {
            get
            {
                return state == State.Attack &&
                    animManager.frameIndex <= animManager.GetAnim().startUp + animManager.GetAnim().active;
            }
        }
        public bool recovery
        {
            get
            {
                return state == State.Attack &&
                    animManager.frameIndex <= animManager.GetAnim().startUp + animManager.GetAnim().active + animManager.GetAnim().recovery;
            }
        }
        public bool counterHit = false;
        public bool airHit = false;
        public bool lastFrame = false;
        public bool canSpecialCancel = false;
        public bool hitted = false;
        #endregion

        #region constants
        public int HitPoints = 1000;
        int MaxHitPoints = 1000;
        float jumpHeightVel = 18;
        float jumpWidthVel = 5;
        float groundSpeed = 5;
        float backGroundSpeed = 4;
        float gravity = 0.7f;
        int knockedDownMax = 100;
        int cancelWindow = 10;
        int maxCancelWindow = 10;
        #endregion

        #region stuff
        public string name;
        public int sign = 1;
        public int lastSign = 1;
        public PlayerIndex playerIndex = PlayerIndex.One;
        int knockedDownCounter = 100;
        public Vector2 thrownPosition;
        public int comboNb;
        #endregion
        

        public Fighter(Vector2 position, PlayerIndex playerIndex)
        {
            Position = position;
            this.playerIndex = playerIndex;
            SetAnims();
            IA = null;
        }

        public void Update(GameTime gameTime)
        {
            buffer.Update(sign, playerIndex);

            if (IA != null && Static.activateIA)
                IA.Update();
            
            Controls();
            SetState();
            animManager.Update(gameTime);

            velocity.Y += gravity;
            Position += velocity;
            Collision(gameTime);
            lastSign = sign;

            foreach (Projectile projectile in projectiles)
                projectile.Update(gameTime);

            projectiles = projectiles.Where(x => !x.removed).ToList();

            SpecialCancelTimer();
        }

        #region Draw
        public void DrawBuffer(SpriteBatch spriteBatch)
        {
            buffer.Draw(spriteBatch, playerIndex == PlayerIndex.One ? new Vector2(9, 10) : new Vector2(770, 10), playerIndex);
        }

        public void DrawHitPoints(SpriteBatch spriteBatch)
        {
            if (playerIndex == PlayerIndex.One)
            {
                spriteBatch.Draw(Art.WhitePixel, new Rectangle(80, 20, 300, 20), Color.Red);
                spriteBatch.Draw(Art.WhitePixel, new Rectangle(80 + (300-300*HitPoints/MaxHitPoints), 20, 300*HitPoints/MaxHitPoints, 20), Color.Yellow);
            }

            if (playerIndex == PlayerIndex.Two)
            {
                spriteBatch.Draw(Art.WhitePixel, new Rectangle(420, 20, 300, 20), Color.Red);
                spriteBatch.Draw(Art.WhitePixel, new Rectangle(420, 20, 300 * HitPoints / MaxHitPoints, 20), Color.Yellow);
            }
                
            
        }

        public void DrawAnim(SpriteBatch spriteBatch)
        {
            animManager.Draw(spriteBatch);
        }

        public void DrawProjectiles(SpriteBatch spriteBatch)
        {
            foreach (Projectile projectile in projectiles)
                projectile.Draw(spriteBatch);
        }
        public void DrawPosition(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Art.WhitePixel, new Rectangle((int)Position.X, (int)Position.Y, 5, 5), Color.Red);
        }
        public void DrawHurtBox(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Art.WhitePixel, HurtBox, hurtBoxColor);
        }
        public void DrawHitBox(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Art.WhitePixel, HitBox, hitBoxColor);
        }
        public void DrawCollisionBox(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Art.WhitePixel, CollisionBox, collisionBoxColor);
        }
        public void DrawGuardProcBox(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Art.WhitePixel, GuardProcBox, guardProcBoxColor);
        }

        
        #endregion

        public void Controls()
        {
            crouching = ((buffer.crouch) && isOnGround && state != State.LowBlock);
            if (isOnGround) neutralJumping = false;

            if (state == State.Throw || state == State.TryThrow|| state == State.Technical)
                return;
            if (state == State.StandUp || state == State.AirHit)
                return;

            if (thrown)
            {
                state = State.Thrown;
                return;
            }
            if (knockedDown)
            {
                state = State.KnockDown;
                return;
            }
            if (wasHit||resetHit)
            {
                state = State.Hit;
                return;
            }
            if (recovering)
            {
                state = State.Recover;
                return;
            }

            if (blockStuned)
            {
                if(blocksHigh)
                    state = State.HighBlock;
                else 
                    state = State.LowBlock;
                return;
            }
            if (IA == null || !IA.blockall)
            {
                blocksHigh = false;
                blocksLow = false;
            }

            #region throw
            canKaraCancel = animManager.frameIndex < animManager.GetAnim().startUp;
            if (buffer.forwardThrow && isOnGround && (state != State.Attack || (state == State.Attack && canKaraCancel)))
            {
                animManager.ResetFrameCount();
                state = State.TryThrow;
                return;
            }
            #endregion

            #region attack
            if (buffer.shoryuMotion && (state != State.Attack || canSpecialCancel) && isOnGround)
            {
                hitted = false;
                animManager.ResetFrameCount();
                state = State.Attack;
                attackState.type = AttackType.Dragon;
                attackState.strength = buffer.strength;
            }
            if (buffer.tatsuMotion && (state != State.Attack || canSpecialCancel) && isOnGround)
            {
                hitted = false;
                isOnGround = false;
                animManager.ResetFrameCount();
                state = State.Attack;
                attackState.type = AttackType.Tatsu;
                attackState.strength = buffer.strength;
            }

            if (buffer.hadoMotion && (state != State.Attack||canSpecialCancel) && isOnGround)
            {
                hitted = false;
                animManager.ResetFrameCount();
                state = State.Attack;
                attackState.type = AttackType.Hado;
                attackState.strength = buffer.strength;
                projAttackState.type = AttackType.Hado;
                projAttackState.strength = buffer.strength;
            }

            if (buffer.hkick && state != State.Attack)
            {
                animManager.ResetFrameCount();
                state = State.Attack;
                attackState.type = AttackType.Roundhouse;
            }

            if (buffer.hpunch && state != State.Attack)
            {
                animManager.ResetFrameCount();
                state = State.Attack;
                attackState.type = AttackType.Fierce;
            }

            if (buffer.mkick && state != State.Attack)
            {
                animManager.ResetFrameCount();
                state = State.Attack;
                attackState.type = AttackType.Forward;
            }

            if (buffer.mpunch && state != State.Attack)
            {
                animManager.ResetFrameCount();
                state = State.Attack;
                attackState.type = AttackType.Strong;
            }

            if (buffer.lkick && state != State.Attack)
            {
                animManager.ResetFrameCount();
                state = State.Attack;
                attackState.type = AttackType.Short;
            }

            if (buffer.lpunch && state != State.Attack)
            {
                animManager.ResetFrameCount();
                state = State.Attack;
                attackState.type = AttackType.Jab;
            }
            #endregion

            #region block
            if (buffer.moveBackward && isOnGround && state != State.Attack && (guardProced||projGuardProced))
            {
                blocksHigh = true;
                Blocks(2);
            }
            else if (buffer.moveCrouchBackward && isOnGround && state != State.Attack && (guardProced || projGuardProced))
            {
                blocksLow = true;
                Blocks(2);
            }
            #endregion

            #region jump
            else if (buffer.backwardJump && isOnGround && state != State.Attack)
            {
                animManager.ResetFrameCount();
                BackwardJump();
            }
            else if (buffer.forwardJump && isOnGround && state != State.Attack)
            {
                animManager.ResetFrameCount();
                ForwardJump();
            }
            else if (buffer.neutralJump && isOnGround && state != State.Attack)
            {
                animManager.ResetFrameCount();
                NeutralJump();
                neutralJumping = true;
            }
            #endregion

            #region walk

            else if ((buffer.moveCrouchBackward|| buffer.moveCrouch || buffer.moveCrouchForward) && isOnGround && state != State.Attack && state != State.LowBlock)
            {
                state = State.Crouch;
            }
            else if (buffer.moveBackward && isOnGround && state != State.Attack && state != State.HighBlock)
            {
                Position.X -= backGroundSpeed * sign;
                state = State.Walk;
            }

            else if (buffer.moveForward && isOnGround && state != State.Attack)
            {
                Position.X += groundSpeed * sign;
                state = State.Walk;
            }

            else if (state != State.Attack && isOnGround)
                state = State.Idle;
            #endregion
        }

        public void SetState()
        {
            #region hit/knockdown/block
            #region knockDown
            if (state == State.KnockDown)
            {
                knockedDownCounter--;
                if (isOnGround)
                {
                    animManager.animation = "knockedDown";

                    if (knockedDownCounter < 0)
                    {
                        knockedDown = false;
                        animManager.ResetFrameCount();
                        state = State.StandUp;
                    }

                }
                if (knockedDownCounter < 0)
                    knockedDownCounter = knockedDownMax;
                return;
            }
            #endregion
            #region standUp
            if (state == State.StandUp)
            {
                if (isOnGround)
                {
                    animManager.animation = "standUp";

                    if (animManager.animEnded)
                    {
                        wasHit = false;
                        animManager.ResetFrameCount();
                        ImmediateActionOnWakeUp();
                        state = State.Idle;
                    }

                }
                return;
            }
            #endregion
            #region thrown
            else if (state == State.Thrown)
            {
                animManager.animation = "thrown";

                if (animManager.animEnded)
                {
                    wasHit = false;
                    thrown = false;
                    Position.X = thrownPosition.X + throwDir * 250;
                    velocity.X = 0;
                    GetKnockedDown();
                }
                return;
            }
            #endregion
            #region airHit
            else if (state == State.AirHit)
            {
                if (isOnGround)
                {
                    wasHit = false;
                    airHit = false;
                    animManager.ResetFrameCount();
                    ImmediateActionOnWakeUp();
                    state = State.Idle;
                }
            }
            #endregion
            #region hit
            else if (state == State.Hit)
            {
                if (animManager.animEnded)
                {
                    wasHit = false;
                    animManager.ResetFrameCount();
                    ImmediateActionOnWakeUp();
                    state = State.Idle;
                }
            }
            #endregion
            #region recover
            else if (state == State.Recover)
            {
                if (animManager.animEnded)
                {
                    recovering = false;
                    animManager.ResetFrameCount();
                    state = State.Idle;
                }
            }
            #endregion
            #region lowBlock
            else if (state == State.LowBlock)
            {
                if (buffer.moveBackward)
                    state = State.HighBlock;
                if (animManager.animEnded)
                {
                        animManager.ResetFrameCount();
                        ImmediateActionOnWakeUp();
                        state = State.Idle;
                        blockStuned = false;
                }
            }
            #endregion
            #region highBlock
                else if (state == State.HighBlock)
                {
                    if (buffer.moveCrouchBackward)
                        state = State.LowBlock;
                    if (animManager.animEnded)
                    {
                        animManager.ResetFrameCount();
                        ImmediateActionOnWakeUp();
                        state = State.Idle;
                        blockStuned = false;
                    }
                }
                #endregion
            #endregion

            #region move
                else if (state == State.Idle)
                {
                    animManager.animation = "idle";
                }

                else if (state == State.Walk)
                {
                    animManager.animation = "walk";
                }
                else if (state == State.Crouch)
                {
                    animManager.animation = "crouch";
                }
                #endregion

            #region throw
                else if (state == State.TryThrow)
                {
                    if (isOnGround)
                    {
                        animManager.animation = "tryThrow";
                        isTryingToThrow = true;
                    }


                    if (animManager.animEnded)
                    {
                        animManager.ResetFrameCount();
                        state = State.Idle;
                        isTryingToThrow = false;

                        if (canThrow)
                        {
                            state = State.Throw;
                            isThrowing = true;
                            justThrew = true;
                        }
                    }
                }

                else if (state == State.Throw)
                {
                    animManager.animation = "forwardThrow";
                    isThrowing = true;

                    if (animManager.animEnded)
                    {
                        isThrowing = false;
                        sign *= -1;
                        animManager.ResetFrameCount();
                        if (isOnGround)
                            state = State.Idle;
                        else
                            state = State.Jump;
                    }
                }

                else if (state == State.Technical)
                {
                    animManager.animation = "tryThrow";
                    technical = true;
                    if (animManager.animEnded)
                    {
                        ResetBools();
                        technical = false;
                        velocity.X -= 20 * sign;
                        animManager.ResetFrameCount();
                        if (isOnGround)
                            state = State.Idle;
                        else
                            state = State.Jump;
                    }
                }
                #endregion

            #region attack
            else if (state == State.Attack)
            {
                #region dragon
                if (attackState.type == AttackType.Dragon)
                {
                    #region Hard
                    if (attackState.strength == Strength.Hard)
                    {
                        {
                            velocity.X = attackState.displacement.X * sign;
                            animManager.animation = "hardDragon";
                            canSpecialCancel = false;

                            if (animManager.animEnded && isOnGround)
                            {
                                isStandHitting = false;
                                isJumping = false;
                                isCrouchHitting = false;
                                isCloseHitting = false;
                                animManager.ResetFrameCount();
                                animManager.ChangeAnimation("recover", new RecoverAnim(attackState.onLandingrecover));
                                animManager.animation = "recover";
                                recovering = true;
                                state = State.Recover;
                                hitted = false;
                            }
                        }
                    }
                    #endregion
                    #region Medium
                    else if (attackState.strength == Strength.Medium)
                    {
                        velocity.X = attackState.displacement.X * sign;
                        animManager.animation = "mediumDragon";
                        canSpecialCancel = false;
                        if (animManager.animEnded && isOnGround)
                        {
                            isStandHitting = false;
                            isJumping = false;
                            isCrouchHitting = false;
                            isCloseHitting = false;
                            animManager.ResetFrameCount();
                            animManager.ChangeAnimation("recover", new RecoverAnim(attackState.onLandingrecover));
                            animManager.animation = "recover";
                            recovering = true;
                            state = State.Recover;
                            hitted = false;
                        }
                    }
                    #endregion
                    #region light
                    else if (attackState.strength == Strength.Light)
                    {
                        velocity.X = attackState.displacement.X * sign;
                        animManager.animation = "lightDragon";
                        canSpecialCancel = false;
                        if (animManager.animEnded && isOnGround)
                        {
                            isStandHitting = false;
                            isJumping = false;
                            isCrouchHitting = false;
                            isCloseHitting = false;
                            animManager.ResetFrameCount();
                            animManager.ChangeAnimation("recover", new RecoverAnim(attackState.onLandingrecover));
                            animManager.animation = "recover";
                            recovering = true;
                            state = State.Recover;
                            hitted = false;
                        }
                    }
                    #endregion
                }
                #endregion
                #region Tatsu
                if (attackState.type == AttackType.Tatsu)
                {
                    #region Hard
                    if (attackState.strength == Strength.Hard)
                    {
                        {
                            isOnGround = false;
                            animManager.animation = "hardTatsu";
                            canSpecialCancel = false;

                            if (animManager.animEnded)
                            {
                                isOnGround = true;
                                isStandHitting = false;
                                isJumping = false;
                                isCrouchHitting = false;
                                isCloseHitting = false;
                                animManager.ResetFrameCount();
                                animManager.ChangeAnimation("recover", new RecoverAnim(attackState.onLandingrecover));
                                animManager.animation = "recover";
                                recovering = true;
                                state = State.Recover;
                                hitted = false;
                            }
                        }
                    }
                    #endregion
                    #region Medium
                    else if (attackState.strength == Strength.Medium)
                    {
                        isOnGround = false;
                        animManager.animation = "mediumTatsu";
                        canSpecialCancel = false;
                        if (animManager.animEnded)
                        {
                            isOnGround = true;
                            isStandHitting = false;
                            isJumping = false;
                            isCrouchHitting = false;
                            isCloseHitting = false;
                            animManager.ResetFrameCount();
                            animManager.ChangeAnimation("recover", new RecoverAnim(attackState.onLandingrecover));
                            animManager.animation = "recover";
                            recovering = true;
                            state = State.Recover;
                            hitted = false;
                        }
                    }
                    #endregion
                    #region light
                    else if (attackState.strength == Strength.Light)
                    {
                        isOnGround = false;
                        animManager.animation = "lightTatsu";
                        canSpecialCancel = false;
                        if (animManager.animEnded)
                        {
                            isOnGround = true;
                            isStandHitting = false;
                            isJumping = false;
                            isCrouchHitting = false;
                            isCloseHitting = false;
                            animManager.ResetFrameCount();
                            animManager.ChangeAnimation("recover", new RecoverAnim(attackState.onLandingrecover));
                            animManager.animation = "recover";
                            recovering = true;
                            state = State.Recover;
                            hitted = false;
                        }
                    }
                    #endregion
                }
                #endregion
                #region Hado
                if (attackState.type == AttackType.Hado)
                {
                    #region Hard
                    if (attackState.strength == Strength.Hard)
                    {
                        velocity.X = attackState.displacement.X * sign;
                        animManager.animation = "lightHado";
                        canSpecialCancel = false;
                        if (animManager.frameIndex == MoveList.hardHado.startUp)
                            projectiles.Add(new Projectile(this));
                        if (animManager.animEnded)
                        {
                            isStandHitting = false;
                            isJumping = false;
                            isCrouchHitting = false;
                            isCloseHitting = false;
                            animManager.ResetFrameCount();
                            state = State.Idle;
                            hitted = false;
                        }
                    }
                    #endregion
                    #region Medium
                    else if (attackState.strength == Strength.Medium)
                    {
                        velocity.X = attackState.displacement.X * sign;
                        animManager.animation = "lightHado";
                        canSpecialCancel = false;
                        if (animManager.frameIndex == MoveList.mediumHado.startUp)
                            projectiles.Add(new Projectile(this));
                        if (animManager.animEnded)
                        {
                            isStandHitting = false;
                            isJumping = false;
                            isCrouchHitting = false;
                            isCloseHitting = false;
                            animManager.ResetFrameCount();
                            state = State.Idle;
                            hitted = false;
                        }
                    }
                    #endregion
                    #region light
                    else if (attackState.strength == Strength.Light)
                    {
                        velocity.X = attackState.displacement.X * sign;
                        animManager.animation = "lightHado";
                        canSpecialCancel = false;
                        if (animManager.frameIndex == MoveList.lightHado.startUp)
                            projectiles.Add(new Projectile(this));
                        if (animManager.animEnded)
                        {
                            isStandHitting = false;
                            isJumping = false;
                            isCrouchHitting = false;
                            isCloseHitting = false;
                            animManager.ResetFrameCount();
                            state = State.Idle;
                            hitted = false;
                        }
                    }
                    #endregion
                }
                #endregion
                #region  Fierce
                if (attackState.type == AttackType.Fierce)
                {
                    if (animManager.frameIndex == 1)
                        Position.X += sign * attackState.displacement.X;
                    if (isOnGround)
                    {
                        if (crouching && !isStandHitting && !isCloseHitting)
                        {
                            animManager.animation = "crouchingFierce";
                            isCrouchHitting = true;
                        }
                        else if (!isCrouchHitting)
                            if (close)
                            {
                                animManager.animation = "closeStandingFierce";
                                isCloseHitting = true;
                            }
                            else if (!isCloseHitting)
                            {
                                animManager.animation = "standingFierce";
                                isStandHitting = true;
                            }
                    }
                    else
                    {
                        if (neutralJumping)
                            animManager.animation = "neutralJumpingFierce";
                        else
                            animManager.animation = "jumpingFierce";
                        isJumping = true;
                    }


                    if (animManager.animEnded || (isJumping && isOnGround))
                    {
                        isStandHitting = false;
                        isJumping = false;
                        isCrouchHitting = false;
                        isCloseHitting = false;
                        animManager.ResetFrameCount();
                        if (isOnGround)
                            state = State.Idle;
                        else
                            state = State.Jump;
                        canSpecialCancel = false;
                        hitted = false;
                    }
                }
                #endregion
                #region Roundhouse
                if (attackState.type == AttackType.Roundhouse)
                {
                    if (animManager.frameIndex == 1)
                        Position.X += sign * attackState.displacement.X;
                    if (isOnGround)
                    {
                        if (crouching && !isStandHitting && !isCloseHitting)
                        {
                            animManager.animation = "crouchingRoundhouse";
                            isCrouchHitting = true;
                        }
                        else if (!isCrouchHitting)
                            if (close)
                            {
                                animManager.animation = "closeStandingRoundhouse";
                                isCloseHitting = true;
                            }
                            else if (!isCloseHitting)
                            {
                                animManager.animation = "standingRoundhouse";
                                isStandHitting = true;
                            }
                    }
                    else
                    {
                        if (neutralJumping)
                            animManager.animation = "neutralJumpingRoundhouse";
                        else
                            animManager.animation = "jumpingRoundhouse";
                        isJumping = true;
                    }


                    if (animManager.animEnded || (isJumping && isOnGround))
                    {
                        isStandHitting = false;
                        isCloseHitting = false;
                        isCrouchHitting = false;
                        isJumping = false;
                        animManager.ResetFrameCount();
                        if (isOnGround)
                            state = State.Idle;
                        else
                            state = State.Jump;
                        canSpecialCancel = false;
                        hitted = false;
                    }
                }
                #endregion
                #region  Strong
                if (attackState.type == AttackType.Strong)
                {
                    if (animManager.frameIndex == 1)
                        Position.X += sign * attackState.displacement.X;
                    if (isOnGround)
                    {
                        if (crouching && !isStandHitting && !isCloseHitting)
                        {
                            animManager.animation = "crouchingStrong";
                            isCrouchHitting = true;
                        }
                        else if (!isCrouchHitting)
                            if (close)
                            {
                                animManager.animation = "closeStandingStrong";
                                isCloseHitting = true;
                            }
                            else if (!isCloseHitting)
                            {
                                animManager.animation = "standingStrong";
                                isStandHitting = true;
                            }
                    }
                    else
                    {
                        if (neutralJumping)
                            animManager.animation = "neutralJumpingStrong";
                        else
                            animManager.animation = "jumpingStrong";
                        isJumping = true;
                    }

                    if (animManager.animEnded || (isJumping && isOnGround))
                    {
                        isStandHitting = false;
                        isCloseHitting = false;
                        isJumping = false;
                        isCrouchHitting = false;
                        animManager.ResetFrameCount();
                        if (isOnGround)
                            state = State.Idle;
                        else
                            state = State.Jump;
                        canSpecialCancel = false;
                        hitted = false;
                    }
                }
                #endregion
                #region Forward
                if (attackState.type == AttackType.Forward)
                {
                    if (animManager.frameIndex == 1)
                        Position.X += sign * attackState.displacement.X;
                    if (isOnGround)
                    {
                        if (crouching && !isStandHitting && !isCloseHitting)
                        {
                            animManager.animation = "crouchingForward";
                            isCrouchHitting = true;
                        }
                        else if (!isCrouchHitting)
                            if (close)
                            {
                                animManager.animation = "closeStandingForward";
                                isCloseHitting = true;
                            }
                            else if (!isCloseHitting)
                            {
                                animManager.animation = "standingForward";
                                isStandHitting = true;
                            }
                    }
                    else
                    {
                        if (neutralJumping)
                            animManager.animation = "neutralJumpingForward";
                        else
                            animManager.animation = "jumpingForward";
                        isJumping = true;
                    }

                    if (animManager.animEnded || (isJumping && isOnGround))
                    {
                        isStandHitting = false;
                        isCloseHitting = false;
                        isJumping = false;
                        isCrouchHitting = false;
                        animManager.ResetFrameCount();
                        if (isOnGround)
                            state = State.Idle;
                        else
                            state = State.Jump;
                        canSpecialCancel = false;
                        hitted = false;
                    }
                }
                #endregion
                #region  jab
                if (attackState.type == AttackType.Jab)
                {
                    if (animManager.frameIndex == 1)
                        Position.X += sign * attackState.displacement.X;
                    if (isOnGround)
                    {
                        if (crouching && !isStandHitting && !isCloseHitting)
                        {
                            animManager.animation = "crouchingJab";
                            isCrouchHitting = true;
                        }
                        else if (!isCrouchHitting)
                            if (close)
                            {
                                animManager.animation = "closeStandingJab";
                                isCloseHitting = true;
                            }
                            else if (!isCloseHitting)
                            {
                                animManager.animation = "standingJab";
                                isStandHitting = true;
                            }
                    }
                    else
                    {
                        if (neutralJumping)
                            animManager.animation = "neutralJumpingJab";
                        else
                            animManager.animation = "jumpingJab";
                        isJumping = true;
                    }

                    if (animManager.animEnded || (isJumping && isOnGround))
                    {
                        isStandHitting = false;
                        isCloseHitting = false;
                        isJumping = false;
                        isCrouchHitting = false;
                        animManager.ResetFrameCount();
                        if (isOnGround)
                            state = State.Idle;
                        else
                            state = State.Jump;
                        canSpecialCancel = false;
                        hitted = false;
                    }
                }
                #endregion
                #region short
                if (attackState.type == AttackType.Short)
                {
                    if (animManager.frameIndex == 1)
                        Position.X += sign * attackState.displacement.X;
                    if (isOnGround)
                    {
                        if (crouching && !isStandHitting && !isCloseHitting)
                        {
                            animManager.animation = "crouchingShort";
                            isCrouchHitting = true;
                        }
                        else if (!isCrouchHitting)
                            if (close)
                            {
                                animManager.animation = "closeStandingShort";
                                isCloseHitting = true;
                            }
                            else if (!isCloseHitting)
                            {
                                isStandHitting = true;
                                animManager.animation = "standingShort";
                            }
                    }
                    else
                    {
                        if (neutralJumping)
                            animManager.animation = "neutralJumpingShort";
                        else
                            animManager.animation = "jumpingShort";
                        isJumping = true;
                    }

                    if (animManager.animEnded || (isJumping && isOnGround))
                    {
                        isStandHitting = false;
                        isCloseHitting = false;
                        isJumping = false;
                        isCrouchHitting = false;
                        animManager.ResetFrameCount();
                        if (isOnGround)
                            state = State.Idle;
                        else
                            state = State.Jump;
                        canSpecialCancel = false;
                        hitted = false;
                    }
                }
                #endregion
            }
            #endregion

            #region jump
            else if (state == State.ForwardJump)
            {
                animManager.animation = "forwardJump";
            }
            else if (state == State.Jump)
            {
                animManager.animation = "jump";
            }
                #endregion
            
        }

        public void Collision(GameTime gameTime)
        {
            #region collision bottom
            if (Position.Y > Stage.bottom)
            {
                Position.Y = Stage.bottom;
                isOnGround = true;
                airHit = false;
                velocity.Y = 0;
                velocity.X = 0;
            }
            #endregion

            #region collision left
            if (CollisionBox.Left < 0)
            {
                #region sign1
                if (sign == 1) 
                {
                    Position.X += -CollisionBox.Left+2;
                    if (Stage.movingStage)
                    {
                        if (Stage.fightersRelativePosition < (int)Static.Size.X - 100 && Stage.position < (int)Static.Size.X / 2)
                        {
                            int speed = isOnGround ? (int)backGroundSpeed : (int)jumpWidthVel;
                            Stage.position += speed;
                            Position.X -= speed;
                        }
                    }
                }
                #endregion
                #region sign -1
                else if (sign == -1) 
                {
                    Position.X += -CollisionBox.Left-2;
                    //velocity.X = 0;
                    if (Stage.movingStage)
                    {
                        if (Stage.fightersRelativePosition < (int)Static.Size.X - 100 && Stage.position < (int)Static.Size.X / 2)
                        {
                            int speed = isOnGround ? (int)groundSpeed : (int)jumpWidthVel;
                            Stage.position += speed;
                            Position.X -= speed;
                        }
                    }

                }
                #endregion
            }
            #endregion

            #region collision right
            if (CollisionBox.Right > (int)Static.Size.X)
            {
                #region sign = 1
                if (sign == 1)
                {
                    Position.X += (int)Static.Size.X- CollisionBox.Right +2;
                    if (Stage.movingStage)
                    {
                        if (Stage.fightersRelativePosition < (int)Static.Size.X - 100 && Stage.position > -(int)Static.Size.X/2)
                        {
                            int speed = isOnGround ? (int)groundSpeed : (int)jumpWidthVel;
                            Stage.position -= speed;
                            Position.X += speed;
                        }
                    }
                }
                #endregion

                #region sign = -1
                if (sign == -1)
                {
                    Position.X += (int)Static.Size.X - CollisionBox.Right - 2;
                    if (Stage.movingStage)
                    {
                        if (Stage.fightersRelativePosition < (int)Static.Size.X- 100 && Stage.position > -(int)Static.Size.X/2)
                        {
                            int speed = isOnGround ? (int)backGroundSpeed : (int)jumpWidthVel;
                            Stage.position -= speed;
                            Position.X += speed;
                        }
                    }

                }
                #endregion
            }
            #endregion
        }


        #region jump methods
        public void NeutralJump()
        {
            state = State.Jump;
            isOnGround = false;
            velocity.Y -= jumpHeightVel;
        }
        public void ForwardJump()
        {
            state = State.ForwardJump;

            isOnGround = false;
            velocity.Y -= jumpHeightVel;
            velocity.X += jumpWidthVel*sign;
        }
        public void BackwardJump()
        {
            state = State.Jump;

            isOnGround = false;
            velocity.Y -= jumpHeightVel;
            velocity.X -= jumpWidthVel*sign;
        }
        #endregion

        #region onHit methods
        public void GetHit(int hitStun, ImpactZone impactZone)
        {
            if(!resetHit)
                wasHit = true;

            animManager.ResetFrameCount();
            if (isOnGround)
            {
                if (impactZone == ImpactZone.High)
                {
                    animManager.ChangeAnimation("faceHit", new FaceHitAnim(hitStun));
                    animManager.animation = "faceHit";
                    state = State.Hit;
                }
                else
                {
                    
                    animManager.ChangeAnimation("hit", new HitAnim(hitStun));
                    animManager.animation = "hit";
                    state = State.Hit;
                }
                
            }
            else
            {
                airHit = true;
                animManager.ChangeAnimation("airHit", new AirHitAnim(1000));
                animManager.animation = "airHit";
                state = State.AirHit;
            }
            
        }
        public void Blocks(int blockStun)
        {
            if(blockStun>1)
                blockStuned = true;
            animManager.ResetFrameCount();
            if (blocksHigh)
            {
                animManager.ChangeAnimation("highBlock", new HighBlockAnim(blockStun));
                animManager.animation = "highBlock";
                state = State.HighBlock;
            }
            else if (blocksLow) 
            {
                animManager.ChangeAnimation("lowBlock", new LowBlockAnim(blockStun));
                animManager.animation = "lowBlock";
                state = State.LowBlock;
            }
            
        }
        public void GetKnockedDown()
        {
            wasHit = true;
            knockedDown = true;
            animManager.ResetFrameCount();
            if (isOnGround)
            {
                animManager.ChangeAnimation("faceHit", new FaceHitAnim(1000));
                animManager.animation = "faceHit";
            }
            
            else
            {
                
                animManager.ChangeAnimation("airHit", new AirHitAnim(1000));
                animManager.animation = "airHit";
            }
            state = State.KnockDown;
        }
        public void GetThrown()
        {
            wasHit = true;
            thrown = true;
            
            throwDir = sign ;

            animManager.ResetFrameCount();
            animManager.ChangeAnimation("throw", new GetThrownAnim());
            animManager.animation = "throw";
            
            state = State.Thrown;
        }
        #endregion

        public void SetAnims()
        {
            animManager = new AnimationManager(Art.Ryu, 10, 10, this);
            animManager.timeToUpdate = 0.1f;
            animManager.position = this.Position;
            animManager.isLooping = true;

            #region move
            animManager.AddAnimation("idle", new IdleAnim());
            animManager.AddAnimation("walk", new WalkAnim());
            animManager.AddAnimation("crouch", new CrouchAnim());
            
            animManager.AddAnimation("jump", new JumpAnim());
            animManager.AddAnimation("forwardJump", new ForwardJumpAnim());
            #endregion

            #region hit-block
            animManager.AddAnimation("faceHit", new FaceHitAnim(1));
            animManager.AddAnimation("airHit", new AirHitAnim(1));
            animManager.AddAnimation("hit", new HitAnim(1));
            animManager.AddAnimation("knockedDown", new KnockedDownAnim());
            animManager.AddAnimation("thrown", new GetThrownAnim());
            animManager.AddAnimation("recover", new RecoverAnim(1));

            animManager.AddAnimation("highBlock", new HighBlockAnim(1));
            animManager.AddAnimation("lowBlock", new LowBlockAnim(1));

            animManager.AddAnimation("standUp", new StandUpAnim());
            #endregion

            #region dragon
            animManager.AddAnimation("lightDragon", new LightShoryuAnim());
            animManager.AddAnimation("mediumDragon", new MediumShoryuAnim());
            animManager.AddAnimation("hardDragon", new HardShoryuAnim());
            #endregion

            #region tatsu
            animManager.AddAnimation("lightTatsu", new LightTatsuAnim());
            animManager.AddAnimation("mediumTatsu", new MediumTatsuAnim());
            animManager.AddAnimation("hardTatsu", new HardTatsuAnim());
            #endregion

            #region Hado
            animManager.AddAnimation("lightHado", new LightHadoAnim());

            #endregion

            #region Jab
            animManager.AddAnimation("standingJab", new StandingJabAnim());
            animManager.AddAnimation("closeStandingJab", new CloseStandingJabAnim());
            animManager.AddAnimation("jumpingJab", new JumpingJabAnim());
            animManager.AddAnimation("neutralJumpingJab", new NeutralJumpingJabAnim());
            animManager.AddAnimation("crouchingJab", new CrouchingJabAnim());
            #endregion

            #region Strong
            animManager.AddAnimation("standingStrong", new StandingStrongAnim());
            animManager.AddAnimation("closeStandingStrong", new CloseStandingStrongAnim());
            animManager.AddAnimation("jumpingStrong", new JumpingStrongAnim());
            animManager.AddAnimation("neutralJumpingStrong", new NeutralJumpingStrongAnim());
            animManager.AddAnimation("crouchingStrong", new CrouchingStrongAnim());
            #endregion

            #region Fierce
            animManager.AddAnimation("standingFierce", new StandingFierceAnim());
            animManager.AddAnimation("closeStandingFierce", new CloseStandingFierceAnim());
            animManager.AddAnimation("jumpingFierce", new JumpingFierceAnim());
            animManager.AddAnimation("neutralJumpingFierce", new NeutralJumpingFierceAnim());
            animManager.AddAnimation("crouchingFierce", new CrouchingFierceAnim());
            #endregion

            #region Short
            animManager.AddAnimation("standingShort", new StandingShortAnim());
            animManager.AddAnimation("closeStandingShort", new CloseStandingShortAnim());
            animManager.AddAnimation("crouchingShort", new CrouchingShortAnim());
            animManager.AddAnimation("jumpingShort", new JumpingShortAnim());
            animManager.AddAnimation("neutralJumpingShort", new NeutralJumpingShortAnim());
            #endregion

            #region Forward
            animManager.AddAnimation("standingForward", new StandingForwardAnim());
            animManager.AddAnimation("closeStandingForward", new CloseStandingForwardAnim());
            animManager.AddAnimation("crouchingForward", new CrouchingForwardAnim());
            animManager.AddAnimation("jumpingForward", new JumpingForwardAnim());
            animManager.AddAnimation("neutralJumpingForward", new NeutralJumpingForwardAnim());
            #endregion

            #region Roundhouse
            animManager.AddAnimation("standingRoundhouse", new StandingRoundhouseAnim());
            animManager.AddAnimation("closeStandingRoundhouse", new CloseStandingRoundhouseAnim());
            animManager.AddAnimation("crouchingRoundhouse", new CrouchingRoundhouseAnim());
            animManager.AddAnimation("jumpingRoundhouse", new JumpingRoundhouseAnim());
            animManager.AddAnimation("neutralJumpingRoundhouse", new NeutralJumpingRoundhouseAnim());
            #endregion

            #region throw
            animManager.AddAnimation("tryThrow", new StartThrowAnim());
            animManager.AddAnimation("forwardThrow", new ForwardThrowAnim());
            #endregion

            animManager.animation = "idle";  
        }

        public void ResetBools()
        {
        recovering = false;
        wasHit = false;
        crouching = false;
        blocked = false;
        blockStuned = false;
        knockedDown = false;
        isOnGround = true;
        blocksHigh = false;
        blocksLow = false;
        guardProced = false;
        neutralJumping = false;
        close = false;
        isJumping = false;
        isStandHitting = false;
        isCrouchHitting = false;
        isCloseHitting = false;
        isCommandHitting = false;
        resetHit = false;
        canThrow = false;
        isThrowing = false;
        thrown = false;
        throwDir = 1;
        justThrew = false;
        isTryingToThrow = false;
        canKaraCancel = false;
        technical = false;
        counterHit = false;
        airHit = false;
        lastFrame = false;
        canSpecialCancel = false;
        hitted = false;
        }

        public void ImmediateActionOnWakeUp()
        {

            if (buffer.moveBackward)
            {
                blocksHigh = true;
                state = State.HighBlock;
            }
            if (buffer.moveCrouchBackward)
            {
                blocksLow = true;
                state = State.LowBlock;
            }
            if (buffer.shoryuMotion)
            {
                state = State.Attack;
                attackState.strength = buffer.strength;
                animManager.animation = "lightDragon";

                Message message = new Message("REVERSAL", new Vector2(400, 200), Color.White, 100);
            }
        }

        public void SpecialCancelTimer()
        {
            if (cancelWindow > 0)
                cancelWindow--;
            if (cancelWindow <= 0)
            {
                canSpecialCancel = false;
                cancelWindow = maxCancelWindow;
            }
        }


    }
}
