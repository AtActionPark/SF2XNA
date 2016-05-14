using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class MediumShoryu:MoveBase
    {
        public MediumShoryu()
        {
            hitStun = 40;
            blockStun = 20;
            pushBack = new Vector2(1, 19);
            zone = AttackZone.HighLow;
            knockDown = true;
            damage = 130;
            chipDamage = 5;
            strength = Strength.Medium;
            doubleAttack = true;

            startUp = 3;
            active = 14;
            recover = 25;
            onLandingRecover = 18;

            displacement = new Vector2(1, -15);
        }

    }
}
