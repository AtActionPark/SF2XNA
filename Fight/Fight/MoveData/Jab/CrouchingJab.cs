using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class CrouchingJab:MoveBase
    {
        public CrouchingJab()
        {
            advBlock = 2;
            advHit = 5;

            pushBack = new Vector2(5, 0);
            zone = AttackZone.HighLow;
            impact = ImpactZone.Low;
            knockDown = false;
            damage = 30;
            chipDamage = 0;
            strength = Strength.Light;
            specialCancel = true;

            startUp = 3;
            active = 2;
            recover = 7;
            onLandingRecover = 0;
        }

    }
}
