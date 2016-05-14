using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class StandingShort:MoveBase
    {
        public StandingShort()
        {
            advBlock = -1;
            advHit = 2;
            
            pushBack = new Vector2(10, 0);
            zone = AttackZone.HighLow;
            knockDown = false;
            damage = 40;
            chipDamage = 0;
            strength = Strength.Light;

            startUp = 5;
            active = 6;
            recover = 6;
            onLandingRecover = 0;
        }

    }
}
