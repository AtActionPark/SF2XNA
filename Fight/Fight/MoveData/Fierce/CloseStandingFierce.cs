using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class CloseStandingFierce : MoveBase
    {
        public CloseStandingFierce()
        {
            advHit = -15;
            advBlock = -10;

            pushBack = new Vector2(0, 0);
            zone = AttackZone.HighLow;
            knockDown = false;
            damage = 120;
            chipDamage = 0;
            strength = Strength.Hard;

            startUp = 5;
            active = 7;
            recover = 26;
            onLandingRecover = 0;
        }

    }
}
