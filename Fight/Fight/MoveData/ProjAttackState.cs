using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Fight.MoveData;

namespace Fight
{

    public struct ProjAttackState
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
        public Vector2 velocity;

        public int startUp;
        public int active;
        public int recover;

        public int onLandingrecover;
        public bool doubleAttack;
        public bool jumpingAttack;

        public ProjAttackState(AttackType type, Fighter fighter)
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
            velocity = Vector2.Zero;
        }

        public void Update()
        {
            if (strength == Strength.Hard)
                Copy(MoveList.hardHado);
            else if (strength == Strength.Medium)
                Copy(MoveList.mediumHado);
            else if (strength == Strength.Light)
                Copy(MoveList.lightHado);
        }

        public void Copy (MoveBase move)
        {
            pushBack = move.pushBack;
            zone = move.zone;
            knockDown = move.knockDown;
            damage = move.damage;
            chipDamage = move.chipDamage;
            impact = move.impact;
            //strength = move.strength;
            startUp = move.startUp;
            active = move.active;
            recover = move.recover;
            onLandingrecover = move.onLandingRecover;
            velocity = move.velocity;

            advHit = move.advHit;
            advBlock = move.advBlock;
            doubleAttack = move.doubleAttack;
            jumpingAttack = move.jumpingAttack;

            hitStun = active  +recover- 2 + advHit;
            blockStun = active +recover - 2 + advBlock;
        }
    }
}
