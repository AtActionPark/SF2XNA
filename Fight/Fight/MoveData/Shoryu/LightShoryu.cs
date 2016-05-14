using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class LightShoryu:MoveBase
    {
        public LightShoryu()
        {
            hitStun = 40;
            blockStun = 20;
            pushBack = new Vector2(1, 15);
            zone = AttackZone.HighLow;
            knockDown = true;
            damage = 20;
            chipDamage = 5;

            startUp = 3;
            active = 14;
            recover = 14;
            onLandingRecover = 10;

            displacement = new Vector2(0, -12);
        }

    }
}
