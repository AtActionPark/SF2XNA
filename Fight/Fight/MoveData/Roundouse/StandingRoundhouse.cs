using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class StandingRoundhouse:MoveBase
    {
        public StandingRoundhouse()
        {
            advBlock = -6;
            advHit = -2;

            pushBack = new Vector2(10, 0);
            zone = AttackZone.HighLow;
            knockDown = false;
            damage = 110;
            chipDamage = 0;
            strength = Strength.Hard;

            startUp = 9;
            active = 4;
            recover = 20;
            onLandingRecover = 0;

            //displacement = new Vector2(50, 0);
        }

    }
}
