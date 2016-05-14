using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class CrouchAnim : Animation
    {
        public CrouchAnim()
        {
            timeToUpdate = 0.1f;
            isLooping = true;

            animations = new Rectangle[1];
            animations[0] = new Rectangle(1159, 43, 45, 57);


            hurtBox = new Rectangle[1];
            hurtBox[0] = new Rectangle(1169, 45, 30, 54);


            collisionBox = new Rectangle[1];
            collisionBox[0] = new Rectangle(1173, 56, 22, 42);


            hitBox = new Rectangle[1];
            guardProcBox = new Rectangle[1];

        }
    }
}
