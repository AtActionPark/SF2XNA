using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class StandingFierce : MoveBase
    {
        public StandingFierce()
        {
            advHit = 0;
            advBlock = 4;

            pushBack = new Vector2(5, 0);
            zone = AttackZone.HighLow;
            knockDown = false;
            damage = 120;
            chipDamage = 0;
            strength = Strength.Hard;

            startUp = 8;
            active = 3;
            recover = 15;
            onLandingRecover = 0;
        }

    }
}
