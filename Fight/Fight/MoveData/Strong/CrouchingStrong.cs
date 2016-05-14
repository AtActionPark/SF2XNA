using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class CrouchingStrong:MoveBase
    {
        public CrouchingStrong()
        {
            advBlock = 2;
            advHit = 5;

            pushBack = new Vector2(5, 0);
            zone = AttackZone.HighLow;
            impact = ImpactZone.Low;
            knockDown = false;
            damage = 60;
            chipDamage = 0;
            strength = Strength.Medium;
            specialCancel = true;

            startUp = 4;
            active = 4;
            recover = 8;
            onLandingRecover = 0;
        }

    }
}
