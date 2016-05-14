using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class MoveBase
    {
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
        public bool specialCancel;

        public int onLandingRecover;
        public bool doubleAttack;
        public bool jumpingAttack;

        public Vector2 displacement;
    }
}
