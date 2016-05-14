using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class CrouchingForward : MoveBase
    {
        public CrouchingForward()
        {
            advBlock = -3;
            advHit = 0;

            pushBack = new Vector2(10, 0);
            zone = AttackZone.Low;
            impact = ImpactZone.Low;
            knockDown = false;
            damage = 60;
            chipDamage = 0;
            strength = Strength.Medium;
            specialCancel = true;

            startUp = 5;
            active = 5;
            recover = 12;
            onLandingRecover = 0;
        }

    }
}
