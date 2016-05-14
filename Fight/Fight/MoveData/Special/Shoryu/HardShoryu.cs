using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class HardShoryu:MoveBase
    {
        public HardShoryu()
        {
            hitStun = 40;
            blockStun = 20;
            pushBack = new Vector2(1, 19);
            zone = AttackZone.HighLow;
            knockDown = true;
            damage = 150;
            chipDamage = 5;
            strength = Strength.Hard;

            startUp = 3;
            active = 14;
            recover = 28;
            onLandingRecover = 18;

            displacement = new Vector2(2, -19);
        }

    }
}
