using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class JumpingRoundhouse:MoveBase
    {
        public JumpingRoundhouse()
        {
            advBlock = 2;
            advHit = 5;

            pushBack = new Vector2(5, 0);
            zone = AttackZone.HighLow;
            knockDown = false;
            damage = 100;
            chipDamage = 0;
            strength = Strength.Hard;

            startUp = 7;
            active = 7;
            recover = 1000;
            onLandingRecover = 0;
            jumpingAttack = true;
        }

    }
}
