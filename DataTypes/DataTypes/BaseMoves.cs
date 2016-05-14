using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight
{
    public enum AttackType { StandingJab, StandingShort, Dragon }

    public enum AttackZone { High, Low, HighLow };

    public class BaseMoves
    {
        public AttackType type;
        public int hitStun, blockStun;
        public Vector2 pushBack;
        public AttackZone zone;
        public bool knockDown;
        public int damage, chipDamage;

        public int startUp;
        public int active;
        public int recover;

        public int onLandingrecover;
    }
}
