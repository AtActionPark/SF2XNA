using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class CrouchingFierce:MoveBase
    {
        public CrouchingFierce()
        {
            advBlock = -18;
            advHit = -13;

            hitStun = active + recover - 1 + advHit;
            blockStun = active + recover - 1 + advBlock;
            pushBack = new Vector2(5, 0);
            zone = AttackZone.HighLow;
            knockDown = false;
            damage = 90;
            chipDamage = 0;
            strength = Strength.Hard;
            specialCancel = true;

            startUp = 4;
            active = 8;
            recover = 28;
            onLandingRecover = 0;
        }

    }
}
