using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class StandingJab:MoveBase
    {
        public StandingJab()
        {
            advBlock = 2;
            advHit = 5;

            pushBack = new Vector2(5, 0);
            zone = AttackZone.HighLow;
            knockDown = false;
            damage = 30;
            chipDamage = 0;
            strength = Strength.Light;
            specialCancel = true;

            startUp = 4;
            active = 3;
            recover = 6;
            onLandingRecover = 0;
        }

    }
}
