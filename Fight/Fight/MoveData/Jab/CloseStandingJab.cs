using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class CloseStandingJab:MoveBase
    {
        public CloseStandingJab()
        {
            advBlock = 2;
            advHit = 5;

            hitStun = active+recover-1+advHit;
            blockStun = active + recover - 1 + advBlock;
            pushBack = new Vector2(5, 0);
            zone = AttackZone.HighLow;
            knockDown = false;
            damage = 30;
            chipDamage = 0;
            strength = Strength.Light;
            specialCancel = true;

            startUp = 3;
            active = 3;
            recover = 6;
            onLandingRecover = 0;
        }

    }
}
