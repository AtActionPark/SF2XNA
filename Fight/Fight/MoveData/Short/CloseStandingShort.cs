using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class CloseStandingShort : MoveBase
    {
        public CloseStandingShort()
        {
            advBlock = -1;
            advHit = 2;
            
            pushBack = new Vector2(10, 0);
            zone = AttackZone.HighLow;
            impact = ImpactZone.Low;
            knockDown = false;
            damage = 40;
            chipDamage = 0;
            strength = Strength.Light;

            startUp = 5;
            active = 5;
            recover = 7;
            onLandingRecover = 0;
        }

    }
}
