using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Fight.MoveData;

namespace Fight
{
    public enum AttackType {Jab, Short,Strong,Forward,Fierce,Roundhouse, Dragon, Throw}

    public enum AttackZone { High, Low, HighLow };

    public struct AttackState
    {
        public AttackType type;
        public int hitStun, blockStun;
        public int advHit, advBlock;
        public Vector2 pushBack;
        public AttackZone zone;
        public bool knockDown;
        public int damage, chipDamage;

        public int startUp;
        public int active;
        public int recover;

        public int onLandingrecover;
        public bool doubleAttack;
        public bool jumpingAttack;

        public AttackState(AttackType type, Fighter fighter)
        {
            this.type = type;
            hitStun = 0;
            blockStun = 0;
            pushBack = Vector2.Zero;
            zone = AttackZone.High;
            knockDown = false;
            damage = 0;
            chipDamage = 0;
            startUp = 0;
            active = 0;
            recover = 0;
            onLandingrecover = 0;
            advBlock = 0;
            advHit = 0;
            doubleAttack = false;
            jumpingAttack = false;
        }

        public void Update(Fighter fighter)
        {
            #region short
            if (type == AttackType.Short)
            {
                if (fighter.isOnGround)
                {
                    if (fighter.crouching && !fighter.isStandHitting)
                        Copy(MoveList.crouchingShort);
                    else if (!fighter.isCrouchHitting)
                        if (fighter.close)
                            Copy(MoveList.closeStandingShort);
                        else if (fighter.isCloseHitting)
                            Copy(MoveList.standingShort);
                }
                else
                {
                    if (fighter.neutralJumping)
                        Copy(MoveList.neutralJumpingShort);
                    else
                        Copy(MoveList.jumpingShort);
                }
            }
            #endregion
            #region jab
            if (type == AttackType.Jab)
            {
                if (fighter.isOnGround)
                {
                    if (fighter.crouching && !fighter.isStandHitting)
                        Copy(MoveList.crouchingJab);
                    else if (!fighter.isCrouchHitting)
                        if (fighter.close)
                            Copy(MoveList.closeStandingJab);
                        else if (fighter.isCloseHitting)
                            Copy(MoveList.standingJab);
                }
                else
                {
                    if (fighter.neutralJumping)
                        Copy(MoveList.neutralJumpingJab);
                    else
                        Copy(MoveList.jumpingJab);
                }
            }
            #endregion
            #region Forward
            if (type == AttackType.Forward)
            {
                if (fighter.isOnGround)
                {
                    if (fighter.crouching && !fighter.isStandHitting)
                        Copy(MoveList.crouchingForward);
                    else if (!fighter.isCrouchHitting)
                        if (fighter.close)
                            Copy(MoveList.closeStandingForward);
                        else if (fighter.isCloseHitting)
                            Copy(MoveList.standingForward);
                }
                else
                {
                    if (fighter.neutralJumping)
                        Copy(MoveList.neutralJumpingForward);
                    else
                        Copy(MoveList.jumpingForward);
                }
            }
            #endregion
            #region Strong
            if (type == AttackType.Strong)
            {
                if (fighter.isOnGround)
                {
                    if (fighter.crouching && !fighter.isStandHitting)
                        Copy(MoveList.crouchingStrong);
                    else if (!fighter.isCrouchHitting)
                        if (fighter.close)
                            Copy(MoveList.closeStandingStrong);
                        else if (fighter.isCloseHitting)
                            Copy(MoveList.standingStrong);
                }
                else
                {
                    if (fighter.neutralJumping)
                        Copy(MoveList.neutralJumpingStrong);
                    else
                        Copy(MoveList.jumpingStrong);
                }
            }
            #endregion
            #region Roundhouse
            if (type == AttackType.Roundhouse)
            {
                if (fighter.isOnGround)
                {
                    if (fighter.crouching && !fighter.isStandHitting)
                        Copy(MoveList.crouchingRoundhouse);
                    else if (!fighter.isCrouchHitting)
                        if (fighter.close)
                            Copy(MoveList.closeStandingRoundhouse);
                        else if (fighter.isCloseHitting)
                            Copy(MoveList.standingRoundhouse);
                }
                else
                {
                    if (fighter.neutralJumping)
                        Copy(MoveList.neutralJumpingRoundhouse);
                    else
                        Copy(MoveList.jumpingRoundhouse);
                }
            }
            #endregion
            #region short
            if (type == AttackType.Fierce)
            {
                if (fighter.isOnGround)
                {
                    if (fighter.crouching && !fighter.isStandHitting)
                        Copy(MoveList.crouchingFierce);
                    else if (!fighter.isCrouchHitting)
                        if (fighter.close)
                            Copy(MoveList.closeStandingFierce);
                        else if (fighter.isCloseHitting)
                            Copy(MoveList.standingFierce);
                }
                else
                {
                    if (fighter.neutralJumping)
                        Copy(MoveList.neutralJumpingFierce);
                    else
                        Copy(MoveList.jumpingFierce);
                }
            }
            #endregion

            else if (type == AttackType.Dragon)
                Copy(MoveList.lightShoryu);

        }

        public void Copy (MoveBase move)
        {
            pushBack = move.pushBack;
            zone = move.zone;
            knockDown = move.knockDown;
            damage = move.damage;
            chipDamage = 0;

            startUp = move.startUp;
            active = move.active;
            recover = move.recover;
            onLandingrecover = move.onLandingRecover;

            advHit = move.advHit;
            advBlock = move.advBlock;
            doubleAttack = move.doubleAttack;
            jumpingAttack = move.jumpingAttack;
            if (!jumpingAttack)
            {
                hitStun = active + recover - 1 + advHit;
                blockStun = active + recover - 1 + advBlock;
            }
            else
            {
                hitStun = active  - 1 + advHit;
                blockStun = active  - 1 + advBlock;
            }
            
            
        }
    }
}
