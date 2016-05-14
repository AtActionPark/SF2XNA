using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class CloseStandingStrong : MoveBase
    {
        public CloseStandingStrong()
        {
            advBlock = -3;
            advHit = 3;

            pushBack = new Vector2(5, 0);
            zone = AttackZone.HighLow;
            knockDown = false;
            damage = 80;
            chipDamage = 0;
            strength = Strength.Medium;
            specialCancel = true;

            startUp = 3;
            active = 3;
            recover = 21;
            onLandingRecover = 0;
        }

    }
}
