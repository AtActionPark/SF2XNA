using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class StandingForward:MoveBase
    {
        public StandingForward()
        {
            advBlock = -5;
            advHit = -2;

            pushBack = new Vector2(10, 0);
            zone = AttackZone.HighLow;
            knockDown = false;
            damage = 80;
            chipDamage = 0;
            strength = Strength.Medium;

            startUp = 8;
            active = 2;
            recover = 17;
            onLandingRecover = 0;
            displacement = new Vector2(10, 0);
        }

    }
}
