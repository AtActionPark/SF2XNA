using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DataType
{
    public class BaseMove
    {
        //public AttackType type;
        public int hitStun;
        public int blockStun;
        //public Vector2 pushBack;
        //public AttackZone zone;
        public bool knockDown;
        public int damage;
        public int chipDamage;

        public int startUp;
        public int active;
        public int recover;

        public int onLandingrecover;

    }
}
