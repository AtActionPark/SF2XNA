using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class HighShoryu:MoveBase
    {
        public HighShoryu()
        {
            hitStun = 40;
            blockStun = 20;
            pushBack = new Vector2(1, 19);
            zone = AttackZone.HighLow;
            knockDown = true;
            damage = 20;
            chipDamage = 5;

            startUp = 3;
            active = 14;
            recover = 28;
            onLandingRecover = 38;

            displacement = new Vector2(0, -12);
        }

    }
}
