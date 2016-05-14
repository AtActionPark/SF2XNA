using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.MoveData
{
    public class JumpingShort:MoveBase
    {
        public JumpingShort()
        {
            advBlock = 2;
            advHit = 5;

            pushBack = new Vector2(5, 0);
            zone = AttackZone.HighLow;
            knockDown = false;
            damage = 40;
            chipDamage = 0;
            strength = Strength.Light;

            startUp = 4;
            active = 8;
            recover = 1000;
            onLandingRecover = 0;
            jumpingAttack = true;
        }

    }
}
