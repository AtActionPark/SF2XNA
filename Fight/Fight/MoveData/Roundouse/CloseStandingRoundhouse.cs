using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class CloseStandingRoundhouse:MoveBase
    {
        public CloseStandingRoundhouse()
        {
            advBlock = -1;
            advHit = 4;

            pushBack = new Vector2(2, 0);
            zone = AttackZone.HighLow;
            knockDown = false;
            damage = 50;
            chipDamage = 0;
            strength = Strength.Hard;

            startUp = 8;
            active = 24;
            recover = 15;
            onLandingRecover = 0;
            doubleAttack = true;
        }

    }
}
