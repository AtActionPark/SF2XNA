using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Fight.MoveData;

namespace Fight
{
    public enum AttackType {Jab, Short,Strong,Forward,Fierce,Roundhouse, Dragon,Hado,Tatsu, Throw}

    public enum AttackZone { High, Low, HighLow };
    public enum ImpactZone { High, Low };

    public struct AttackState
    {
        public AttackType type;
        public int hitStun, blockStun;
        public int advHit, advBlock;
        public Vector2 pushBack;
        public AttackZone zone;
        public ImpactZone impact;
        public bool knockDown;
        public int damage, chipDamage;
        public Strength strength;

        public int startUp;
        public int active;
        public int recover;
        public bool specialCancel;

        public int onLandingrecover;
        public bool doubleAttack;
        public bool jumpingAttack;
        public Vector2 displacement;

        public AttackState(AttackType type, Fighter fighter)
        {
            this.type = type;
            hitStun = 10;
            blockStun = 0;
            pushBack = Vector2.Zero;
            zone = AttackZone.High;
            impact = ImpactZone.High;
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
            strength = Strength.Light;
            specialCancel= false;
            displacement = Vector2.Zero;
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
                        else if (!fighter.isCloseHitting)
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
                        else if (!fighter.isCloseHitting)
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
                        else if (!fighter.isCloseHitting)
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
                        else if (!fighter.isCloseHitting)
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
                        else if (!fighter.isCloseHitting)
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
            #region Fierce
            if (type == AttackType.Fierce)
            {
                if (fighter.isOnGround)
                {
                    if (fighter.crouching && !fighter.isStandHitting)
                        Copy(MoveList.crouchingFierce);
                    else if (!fighter.isCrouchHitting)
                        if (fighter.close)
                            Copy(MoveList.closeStandingFierce);
                        else if (!fighter.isCloseHitting)
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

            #region dragon
            else if (type == AttackType.Dragon)
            {
                if(strength == Strength.Hard)
                    Copy(MoveList.hardShoryu);
                else if (strength == Strength.Medium)
                    Copy(MoveList.mediumShoryu);
                else if (strength == Strength.Light)
                    Copy(MoveList.lightShoryu);
            }
            #endregion
            #region tatsu
            else if (type == AttackType.Tatsu)
            {
                if (strength == Strength.Hard)
                    Copy(MoveList.hardTatsu);
                else if (strength == Strength.Medium)
                    Copy(MoveList.mediumTatsu);
                else if (strength == Strength.Light)
                    Copy(MoveList.lightTatsu);
            }
            #endregion
            #region Hado
            else if (type == AttackType.Hado)
            {
                if (strength == Strength.Hard)
                    Copy(MoveList.hardHado);
                else if (strength == Strength.Medium)
                    Copy(MoveList.mediumHado);
                else if (strength == Strength.Light)
                    Copy(MoveList.lightHado);
            }
            #endregion

        }

        public void Copy (MoveBase move)
        {
            pushBack = move.pushBack;
            zone = move.zone;
            knockDown = move.knockDown;
            damage = move.damage;
            chipDamage = move.chipDamage;
            impact = move.impact;
            strength = move.strength;
            startUp = move.startUp;
            active = move.active;
            recover = move.recover;
            onLandingrecover = move.onLandingRecover;
            specialCancel = move.specialCancel;
            displacement = move.displacement;

            advHit = move.advHit;
            advBlock = move.advBlock;
            doubleAttack = move.doubleAttack;
            jumpingAttack = move.jumpingAttack;
            if (!jumpingAttack)
            {
                hitStun = active-2 + recover + advHit;
                blockStun = active-2 + recover + advBlock;
            }
            else
            {
                hitStun = active  - 2 + advHit;
                blockStun = active  - 2 + advBlock;
            }
            
            
        }
    }
}
