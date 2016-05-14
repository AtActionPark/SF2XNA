using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class LightTatsu:MoveBase
    {
        public LightTatsu()
        {
            advHit = 4;
            advBlock = -2;

            pushBack = new Vector2(1, 0);
            zone = AttackZone.HighLow;
            knockDown = false;
            damage = 50;
            chipDamage = 5;
            strength = Strength.Light;
            doubleAttack = true;

            startUp = 11;
            active = 15;
            recover = 12;
            onLandingRecover = 5;

            displacement = new Vector2(3, 0);
        }

    }
}
