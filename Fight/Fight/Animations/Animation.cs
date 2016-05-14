using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Fight
{
    public abstract class Animation
    {
        public Rectangle[] hurtBox;
        public Rectangle[] hitBox;
        public Rectangle[] collisionBox;
        public Rectangle[] animations;
        public Rectangle[] guardProcBox;
        public bool isLooping;
        public bool inverse = false;

        public int startUp;
        public int active;
        public int recovery;

        public Vector2[] displacement;

        public float timeToUpdate = 0.1f;

        public Animation()
        {
            displacement = new Vector2[0];
        }
    }
}
