using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class CrouchingRoundhouse:MoveBase
    {
        public CrouchingRoundhouse()
        {
            advBlock = 2;
            advHit = 5;

            pushBack = new Vector2(10, 0);
            zone = AttackZone.Low;
            impact = ImpactZone.Low;
            knockDown = true;
            damage = 90;
            chipDamage = 0;
            strength = Strength.Hard;

            startUp = 5;
            active = 4;
            recover = 28;
            onLandingRecover = 0;
        }

    }
}
