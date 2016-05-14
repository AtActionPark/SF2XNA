using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class CloseStandingForward : MoveBase
    {
        public CloseStandingForward()
        {
            advBlock = -7;
            advHit = -2;

            pushBack = new Vector2(10, 0);
            zone = AttackZone.HighLow;
            knockDown = false;
            damage = 80;
            chipDamage = 0;

            startUp = 3;
            active = 5;
            recover = 16;
            onLandingRecover = 0;
        }

    }
}
