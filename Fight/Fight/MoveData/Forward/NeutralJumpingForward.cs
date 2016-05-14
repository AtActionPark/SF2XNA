using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class NeutralJumpingForward:MoveBase
    {
        public NeutralJumpingForward()
        {
            advBlock = 2;
            advHit = 5;

            pushBack = new Vector2(5, 0);
            zone = AttackZone.HighLow;
            knockDown = false;
            damage = 80;
            chipDamage = 0;
            strength = Strength.Medium;

            startUp = 6;
            active = 10;
            recover = 1000;
            onLandingRecover = 0;
            jumpingAttack = true;
        }

    }
}
