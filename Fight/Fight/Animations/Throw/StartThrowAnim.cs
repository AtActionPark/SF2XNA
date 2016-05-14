using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class StartThrowAnim : Animation
    {

        public StartThrowAnim()
        {
            isLooping = false;
            timeToUpdate =1/60f;
            inverse = true;
            int frame = 10;

            animations = new Rectangle[frame];
            for (int i = 0; i < frame; i++)
                animations[i] = new Rectangle(850, 636, 49, 82);

            hurtBox = new Rectangle[frame];
            for (int i = 0; i < frame; i++)
                hurtBox[i] = new Rectangle(858, 638, 37, 75);

            collisionBox = new Rectangle[frame];
            for (int i = 0; i < frame; i++)
                collisionBox[i] = new Rectangle(865, 646, 22, 69);


            hitBox = new Rectangle[frame];
            guardProcBox = new Rectangle[frame]; 
        }
    }
}
