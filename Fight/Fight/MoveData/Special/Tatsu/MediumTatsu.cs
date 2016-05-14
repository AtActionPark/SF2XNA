using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class MediumTatsu:MoveBase
    {
        public MediumTatsu()
        {
            advHit = 4;
            advBlock = -2;

            pushBack = new Vector2(1, 0);
            zone = AttackZone.HighLow;
            knockDown = false;
            damage = 50;
            chipDamage = 5;
            strength = Strength.Medium;
            doubleAttack = true;

            startUp = 12;
            active = 25;
            recover = 18;
            onLandingRecover = 3;

            displacement = new Vector2(5, 0);
        }

    }
}
