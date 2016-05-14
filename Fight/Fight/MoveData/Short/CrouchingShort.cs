using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class CrouchingShort:MoveBase
    {
        public CrouchingShort()
        {
            advBlock =-1;
            advHit = 2;

            pushBack = new Vector2(10, 0);
            zone = AttackZone.Low;
            impact = ImpactZone.Low;
            knockDown = false;
            damage = 20;
            chipDamage = 0;
            strength = Strength.Light;
            specialCancel = true;

            startUp = 4;
            active = 3;
            recover = 9;
            onLandingRecover = 0;
        }

    }
}
