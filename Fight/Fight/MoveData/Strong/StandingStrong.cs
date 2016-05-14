using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class StandingStrong : MoveBase
    {
        public StandingStrong()
        {
            advHit = -1;
            advBlock = -4;
            pushBack = new Vector2(5, 0);
            zone = AttackZone.HighLow;
            knockDown = false;
            damage = 80;
            chipDamage = 0;
            strength = Strength.Medium;
            specialCancel = true;


            startUp = 5;
            active = 4;
            recover = 14;
            onLandingRecover = 0;
        }

    }
}
