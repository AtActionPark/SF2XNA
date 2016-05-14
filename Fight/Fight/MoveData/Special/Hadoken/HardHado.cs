using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class HardHado:MoveBase
    {
        public HardHado()
        {
            advBlock = -6;
            advHit = -2;

            pushBack = new Vector2(1, 15);
            zone = AttackZone.HighLow;
            knockDown = true;
            damage = 100;
            chipDamage = 5;
            strength = Strength.Hard;
            velocity = new Vector2(10, 0);

            startUp = 13;
            active = 0;
            recover = 45;

        }

    }
}
