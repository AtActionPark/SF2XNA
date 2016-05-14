using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Fight
{
    class FightersManager
    {
        Fighter Fighter1;
        Fighter Fighter2;

        public string result = "";
        Vector2 hitPosition;
        bool drawHit = false;
        bool drawBlockedHit = false;
        float drawHitMaxNbOfFrames = 10;
        float drawHitNbOfFrames =0;
        bool changeDrawOrder = false;
        int couterFrameAdv;

        public FightersManager()
        {
            Fighter1 = new Fighter(new Vector2(100, 460),  PlayerIndex.One);
            Fighter1.buffer = new Buffer(Fighter1);
            Fighter1.name = "Player1";
            Fighter2 = new Fighter(new Vector2(700, 460),  PlayerIndex.Two);
            Fighter2.buffer = new Buffer(Fighter2);
            Fighter2.name = "Player2";
            Fighter2.sign = -1;
            Fighter2.IA = new IA(Fighter2, Fighter1);
        }

        public void Update(GameTime gameTime)
        {
            Stage.fightersRelativePosition = (int)Math.Abs(Fighter1.Position.X - Fighter2.Position.X);

            if(Input.WasKeyPressed(Keys.V))
                Static.drawHitbox = !Static.drawHitbox;

            if (!Fighter1.isThrowing && !Fighter2.isThrowing && !Fighter1.thrown && !Fighter2.thrown)
            {
                CheckSign();
            }

            Fighter1.Update(gameTime);
            Fighter2.Update(gameTime);

            //if throwing, dont check collision so one fighter can go through the other
            if(!Fighter1.isThrowing&&!Fighter2.isThrowing)
                Collision();

            //if double hit, dont check (we have to check 1 fighter before the other so there is an imbalance)
            if (CheckTrade())
                return;

            #region Hit
            if (AnalyseHit(Fighter1, Fighter2) || AnalyseHit(Fighter2, Fighter1) || AnalyseProjectiles(Fighter1, Fighter2) || AnalyseProjectiles(Fighter2, Fighter1))
            {
                drawHit = true;
                drawHitNbOfFrames = drawHitMaxNbOfFrames;
            }

            drawHitNbOfFrames--;
            if (drawHitNbOfFrames < 0)
            {
                drawHit = false;
            }
            #endregion

            #region close
            if (Fighter1.sign == 1)
            {
                Fighter1.close = Fighter1.CollisionBox.Right > Fighter2.CollisionBox.Left - 30;
                Fighter2.close = Fighter1.close;
            }
            else
            {
                Fighter2.close = Fighter2.CollisionBox.Right > Fighter1.CollisionBox.Left - 30;
                Fighter1.close = Fighter2.close;
            }
            #endregion

            #region canThrow
            Fighter1.canThrow = Fighter1.close && !Fighter1.wasHit && Fighter2.state != State.KnockDown && Fighter2.state != State.StandUp && Fighter2.state != State.Hit && !Fighter2.blockStuned && !Fighter2.isTryingToThrow;
            Fighter2.canThrow = Fighter2.close && Fighter1.state != State.KnockDown && Fighter1.state != State.StandUp && Fighter1.state != State.Hit && !Fighter1.blockStuned && !Fighter1.isTryingToThrow;
            #endregion

            #region technical
            if (Fighter1.isTryingToThrow && Fighter1.close && Fighter2.isTryingToThrow && Fighter2.close)
            {
                Fighter1.state = State.Technical;
                Fighter1.animManager.ResetFrameCount();
                Fighter1.isTryingToThrow = false;
                Fighter2.state = State.Technical;
                Fighter2.animManager.ResetFrameCount();
                Fighter2.isTryingToThrow = false;

                Message message = new Message("technical", new Vector2((800 - (int)Art.Font.MeasureString("Double Hit!").X) / 2, 150), Color.White, 30);
            }
            #endregion

            result = "F1 "+Fighter1.state + " F2 " + Fighter2.state + Fighter1.hitted;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            #region hitbox

            if (Static.drawHitbox)
            {
                Fighter1.DrawGuardProcBox(spriteBatch);
                Fighter2.DrawGuardProcBox(spriteBatch);

                Fighter1.DrawHurtBox(spriteBatch);
                Fighter2.DrawHurtBox(spriteBatch);

                Fighter1.DrawCollisionBox(spriteBatch);
                Fighter2.DrawCollisionBox(spriteBatch);

                Fighter1.DrawHitBox(spriteBatch);
                Fighter2.DrawHitBox(spriteBatch);
            }
            #endregion

            #region UI

            Message message1, message2;
            if (Fighter1.comboNb > 0)
            {
                message1 = new Message(" " + (Fighter1.comboNb+1) + " hits Combo", new Vector2(70,60), Color.White,50, true);
            }
            if (Fighter2.comboNb > 0)
            {
                message1 = new Message(" " + (Fighter1.comboNb + 1) + " hits Combo", new Vector2(70, 60), Color.White, 50, true);
            }

            spriteBatch.Draw(Art.WhitePixel, new Rectangle(78, 18, 644, 24), Color.White);
            spriteBatch.Draw(Art.VSLogo, new Vector2(382, 20), Color.White);

            Fighter1.DrawHitPoints(spriteBatch);
            spriteBatch.DrawString(Art.Font, " " + Fighter1.name, new Vector2(70, 40), Color.White);
            Fighter2.DrawHitPoints(spriteBatch);
            spriteBatch.DrawString(Art.Font, " " + Fighter2.name, new Vector2(710 - (int)Art.Font.MeasureString(Fighter2.name).X, 40), Color.White);

            Fighter1.DrawBuffer(spriteBatch);
            Fighter2.DrawBuffer(spriteBatch);
            #endregion

            #region fighters
            if (!changeDrawOrder)
            {
                Fighter1.DrawAnim(spriteBatch);
                Fighter2.DrawAnim(spriteBatch);
            }
            else
            {
                Fighter2.DrawAnim(spriteBatch);
                Fighter1.DrawAnim(spriteBatch);
            }
            Fighter1.DrawProjectiles(spriteBatch);
            Fighter2.DrawProjectiles(spriteBatch);

            if(drawHit)
                DrawHit(spriteBatch, hitPosition);
            #endregion
        }

        public void Collision()
        {
            if (Fighter2.CollisionBox == Rectangle.Empty || Fighter1.CollisionBox == Rectangle.Empty)
                return;

            //collide box intersect
            if (Fighter1.CollisionBox.Intersects(Fighter2.CollisionBox))
            {
                float depth = Fighter1.CollisionBox.GetHorizontalIntersectionDepth(Fighter2.CollisionBox);
                Fighter1.Position.X += depth / 2;
                Fighter2.Position.X -= depth / 2;
            }
        }

        public bool AnalyseHit(Fighter f1, Fighter f2)
        {
            f2.guardProced = false;
            f2.blocked = false;
            f1.counterHit = false;
            couterFrameAdv = 0;


            #region drawingOrder
            if (f1 == Fighter1)
                changeDrawOrder = true;
            else
                changeDrawOrder = false;
            #endregion
            
            #region throw
            if (f1.isThrowing)
            {
                if (f1.justThrew)
                {
                    f2.HitPoints -= 100;
                    f2.thrownPosition = f2.Position;
                    f1.justThrew = false;
                    f2.GetThrown();
                }
                if(f2.thrown)
                    f2.Position = f2.thrownPosition;
            }
            #endregion

            //if f1 doesnt attack, no need to continue
            if (f1.state != State.Attack)
                return false;

            #region guardProc
            bool attackMiss = !f1.HitBox.Intersects(f2.HurtBox) ;
            //f1 attacks and his procguardbox intersects f2, f2 will block if he backs
            if (f1.GuardProcBox.Intersects(f2.HurtBox) && attackMiss)
            {
                f2.guardProced = true;
            }
            #endregion

            #region resetHit
            f2.resetHit = false;
            f1.attackState.Update(f1);
            //if (f1.attackState.doubleAttack && f1.animManager.frameIndex > f1.attackState.startUp + f1.attackState.active / 3 && f1.animManager.frameIndex < f1.attackState.startUp + 2*f1.attackState.active / 3)
            if (f1.attackState.doubleAttack && f1.animManager.frameIndex > f1.attackState.startUp && f1.animManager.frameIndex < f1.attackState.startUp + f1.attackState.active && f1.HitBox == Rectangle.Empty)
            {
                f2.resetHit = true;
                f2.wasHit = false;
                f1.hitted = false;
                
            }
            #endregion

            //f1 attacks untargetable target
            if (f2.state == State.StandUp || f2.state == State.KnockDown)
                return false;

            //f1 attacks but doesnt hit, stop
            if (attackMiss)
                return false;
            //invul
            if (f2.HurtBox == null || f2.HurtBox == Rectangle.Empty)
                return false;

            drawBlockedHit = false;
            f1.attackState.Update(f1);

            bool hitIsBlocked = (f2.blocksHigh && (f1.attackState.zone == AttackZone.High || f1.attackState.zone == AttackZone.HighLow)
                || f2.blocksLow && (f1.attackState.zone == AttackZone.Low || f1.attackState.zone == AttackZone.HighLow)
                ||f2.blockStuned);

            
            #region unblocked hit
            if (!hitIsBlocked)
            {
                if (!f1.hitted)
                {
                    if (f2.startUp)
                    {
                        f1.counterHit = true;
                        Message message = new Message(" Counter Hit!",
                            (f1 == Fighter1) ? new Vector2(70, 60) : new Vector2(720 - (int)Art.Font.MeasureString("Counter Hit! ").X, 60), Color.Red, 30);
                        if (f1.attackState.strength == Strength.Light)
                            couterFrameAdv = 1;
                        else if (f1.attackState.strength == Strength.Medium || f1.attackState.strength == Strength.Hard)
                            couterFrameAdv = 3;
                    }

                    f2.HitPoints -= f1.counterHit? (int)(f1.attackState.damage*1.25f) : f1.attackState.damage;

                    f1.hitted = true;
                    if (f2.state == State.Hit)
                        f1.comboNb++;

                    else

                        f1.comboNb = 0;

                }

                if (f1.attackState.specialCancel)
                    f1.canSpecialCancel = true;

                if(!f2.wasHit || f2.resetHit)
                    //impact freeze?
                    Freeze(5);
               
                f2.GetHit(f1.attackState.hitStun + couterFrameAdv + (f1.counterHit? 2:0), f1.attackState.impact);

                if (f1.attackState.knockDown)
                    f2.isOnGround = false;

                f2.velocity.Y = -f1.attackState.pushBack.Y;
                if (f1.attackState.knockDown)
                    f2.GetKnockedDown();
            }
            #endregion
            #region blocked hit
            else
            {
                if (!f2.blockStuned)
                    f2.HitPoints -= f1.attackState.chipDamage;

                if (f1.attackState.specialCancel)
                    f1.canSpecialCancel = true;
                drawBlockedHit = true;
                
                f2.blockStuned = true;
                f2.blocked = true;
                f2.Blocks(f1.attackState.blockStun);
            }

            #endregion

            #region pushBack
            bool f2inCorner = f2.Position.X + f2.HurtBox.Width / 2 > Static.Size.X - 5 || f2.Position.X-f2.HurtBox.Width / 2 < 5;

            if(!f2inCorner)
                f2.velocity.X = -f1.attackState.pushBack.X * f2.sign;
            if(f1.isOnGround && f2inCorner)
                f1.velocity.X = -f1.attackState.pushBack.X * f1.sign;
            #endregion

            CalculateHitPosition(f1,f2);
            return true;
        }

        public bool AnalyseProjectiles(Fighter f1, Fighter f2)
        {
            f2.projGuardProced = false;
            f2.blocked = false;

            if (f1.projectiles.Count()< 1)
                return false;

            //f1 attacks untargetable target
            if (f2.state == State.StandUp || f2.state == State.KnockDown)
                return false;

            foreach (Projectile proj in f1.projectiles)
            {
                if (proj.toRemove || proj.removed)
                    continue;

                #region guardProc
                bool attackMiss = !proj.HitBox.Intersects(f2.HurtBox);
                //f1 attacks and his procguardbox intersects f2, f2 will block if he backs
                if (proj.GuardProcBox.Intersects(f2.HurtBox))
                {
                    f2.projGuardProced = true;
                }
                #endregion

                foreach (Projectile proj2 in f2.projectiles)
                {
                    if (proj.HitBox.Intersects(proj2.HitBox))
                    {
                        proj.Die();
                        proj2.Die();
                    }
                    continue;
                }

                if (proj.toRemove)
                    continue;

                if (attackMiss)
                    continue;

                #region drawingOrder
                if (f1 == Fighter1)
                    changeDrawOrder = true;
                else
                    changeDrawOrder = false;
                #endregion

                if (proj.HitBox.Intersects(f2.HurtBox))
                {
                    bool hitIsBlocked = (f2.blocksHigh || f2.blocksLow || f2.blockStuned);

                    #region on Hit
                    if (!hitIsBlocked)
                    {
                        if (!f1.hitted)
                        {
                            f2.HitPoints -= proj.projAttackState.damage;
                            f1.hitted = true;
                            if (f2.state == State.Hit)
                                f1.comboNb++;
                            else
                                f1.comboNb = 0;
                        }
                        if (!f2.wasHit || f2.resetHit)
                            //impact freeze?
                            Freeze(5);

                        f2.GetHit(proj.projAttackState.hitStun, proj.projAttackState.impact);
                        proj.Die();
                        if (!f2.isOnGround)
                        {
                            f2.velocity.Y = -10;
                            f2.GetKnockedDown();
                        }
                        
                    }
                    #endregion

                    #region on block
                    else
                    {
                        if ( !f2.blocked)
                            f2.HitPoints -= proj.projAttackState.chipDamage;
                        drawBlockedHit = true;
                        f2.Blocks(proj.projAttackState.blockStun);
                        //f2.blockStuned = true;
                        f2.blocked = true;
                        proj.Die();
                    }

                    #endregion
                    
                    CalculateHitPosition(proj, f2);
                    return true;
                }
            }
            return false;
        }

        public void Freeze(int Frames)
        {
            Static.freezeCountdown += Frames;
        }

        public void CalculateHitPosition(Fighter f1, Fighter f2)
        {
            int x, y;
            if (f1.sign == 1)
            {
                x = f1.HitBox.Right - (f1.HitBox.Right - f2.HurtBox.Left) / 2;
            }
            else
            {
                x = f1.HitBox.Left + (f2.HurtBox.Right - f1.HitBox.Left) / 2;
            }
            y = f1.HitBox.Top + f1.HitBox.Height / 2;
            hitPosition = new Vector2(x, y);
        }
        public void CalculateHitPosition(Projectile proj, Fighter f2)
        {
            int x, y;
            if (proj.sign == 1)
            {
                x = proj.HitBox.Right - (proj.HitBox.Right - f2.HurtBox.Left) / 2;
            }
            else
            {
                x = proj.HitBox.Left + (f2.HurtBox.Right - proj.HitBox.Left) / 2;
            }
            y = proj.HitBox.Top + proj.HitBox.Height / 2;
            hitPosition = new Vector2(x, y);
        }

        public void DrawHit(SpriteBatch spriteBatch, Vector2 start)
        {
            if(!drawBlockedHit)
                spriteBatch.Draw(Art.FontSheet, start, new Rectangle(110, 0, 11, 11), Color.White);
            else
                spriteBatch.Draw(Art.FontSheet, start, new Rectangle(121, 0, 11, 11), Color.White);
        }

        public void CheckSign()
        {
            if (Fighter1.sign == 1)
            {
                if (Fighter1.Position.X <= Fighter2.Position.X)
                {
                    if (Fighter1.isOnGround && !Fighter1.knockedDown&& Fighter1.state != State.Attack)
                        Fighter1.sign = 1;
                    if (Fighter2.isOnGround && !Fighter2.knockedDown&& Fighter2.state != State.Attack)
                        Fighter2.sign = -1;
                }
                else
                {
                    if (Fighter1.isOnGround && !Fighter1.knockedDown&& Fighter1.state != State.Attack)
                        Fighter1.sign = -1;
                    if (Fighter2.isOnGround && !Fighter2.knockedDown&& Fighter2.state != State.Attack)
                        Fighter2.sign = 1;
                }
            }
            else
            {
                if (Fighter1.Position.X < Fighter2.Position.X)
                {
                    if (Fighter1.isOnGround && !Fighter1.knockedDown&& Fighter1.state != State.Attack)
                        Fighter1.sign = 1;
                    if (Fighter2.isOnGround && !Fighter2.knockedDown&& Fighter2.state != State.Attack)
                        Fighter2.sign = -1;
                }
                else
                {
                    if (Fighter1.isOnGround && !Fighter1.knockedDown&& Fighter1.state != State.Attack)
                        Fighter1.sign = -1;
                    if (Fighter2.isOnGround && !Fighter2.knockedDown&& Fighter2.state != State.Attack)
                        Fighter2.sign = 1;
                }
            }
        }

        public bool CheckTrade()
        {
            if (Fighter1.state != State.Attack || Fighter2.state != State.Attack)
                return false;
            if (Fighter1.HitBox.Intersects(Fighter2.HurtBox) && Fighter2.HitBox.Intersects(Fighter1.HurtBox))
            {
                #region f1
                if (!Fighter1.wasHit)
                    Fighter1.HitPoints -= Fighter1.attackState.damage;

                if (!Fighter1.wasHit || Fighter1.resetHit)
                    //impact freeze?
                    Freeze(5);

                Fighter1.GetHit(Fighter2.attackState.hitStun, Fighter2.attackState.impact);
                //if (f1.attackState.type == AttackType.Dragon)
                if (Fighter2.attackState.knockDown)
                    Fighter1.isOnGround = false;

                Fighter1.velocity.Y = -Fighter2.attackState.pushBack.Y;
                if (Fighter2.attackState.knockDown)
                    Fighter1.GetKnockedDown();
                #endregion
                #region f2
                if (!Fighter2.wasHit)
                    Fighter2.HitPoints -= Fighter2.attackState.damage;

                if (!Fighter2.wasHit || Fighter2.resetHit)
                    //impact freeze?
                    Freeze(5);

                Fighter2.GetHit(Fighter1.attackState.hitStun, Fighter1.attackState.impact);
                //if (f1.attackState.type == AttackType.Dragon)
                if (Fighter1.attackState.knockDown)
                    Fighter2.isOnGround = false;

                Fighter2.velocity.Y = -Fighter2.attackState.pushBack.Y;
                if (Fighter1.attackState.knockDown)
                    Fighter2.GetKnockedDown();
                #endregion

                Message message = new Message("Double Hit!", new Vector2((800-(int)Art.Font.MeasureString("Double Hit!").X)/2, 150), Color.White, 30);
                return true;
            }
            return false;
        }
    }
}
