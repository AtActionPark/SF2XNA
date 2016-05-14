using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class JumpingForward:MoveBase
    {
        public JumpingForward()
        {
            advBlock = 2;
            advHit = 5;

            pushBack = new Vector2(5, 0);
            zone = AttackZone.HighLow;
            knockDown = false;
            damage = 70;
            chipDamage = 0;
            strength = Strength.Medium;

            startUp = 6;
            active = 6;
            recover = 1000;
            onLandingRecover = 0;
            jumpingAttack = true;
        }

    }
}
