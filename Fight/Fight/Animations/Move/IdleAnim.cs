using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class IdleAnim : Animation
    {
        public IdleAnim()
        {
            timeToUpdate = 0.1f;
            isLooping = true;

            animations = new Rectangle[4];
            animations[0] = new Rectangle(0, 15, 50, 82);
            animations[1] = new Rectangle(50, 15, 50, 82);
            animations[2] = new Rectangle(100, 15, 50, 82);
            animations[3] = new Rectangle(150, 15, 50, 82);

            hurtBox = new Rectangle[4];
            hurtBox[0] = new Rectangle(5, 15, 35, 82);
            hurtBox[1] = new Rectangle(55, 15, 35, 82);
            hurtBox[2] = new Rectangle(105, 15, 35, 82);
            hurtBox[3] = new Rectangle(155, 15, 35, 82);

            collisionBox = new Rectangle[4];
            collisionBox[0] = new Rectangle(10, 30, 25, 65);
            collisionBox[1] = new Rectangle(60, 30, 25, 65);
            collisionBox[2] = new Rectangle(110, 30, 25, 65);
            collisionBox[3] = new Rectangle(160, 30, 25, 65);

            hitBox = new Rectangle[4];
            guardProcBox = new Rectangle[4];
        }

    }
}
