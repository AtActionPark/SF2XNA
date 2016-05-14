using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class ForwardThrowAnim : Animation
    {

        public ForwardThrowAnim()
        {

            isLooping = false;
            timeToUpdate = 0.15f;
            inverse = true;

            animations = new Rectangle[5];
            animations[0] = new Rectangle(850, 636, 49, 82);
            animations[1] = new Rectangle(905, 634, 54, 84);
            animations[2] = new Rectangle(964, 638, 43, 79);
            animations[3] = new Rectangle(1011, 640, 53, 77);
            animations[4] = new Rectangle(1068, 642, 59, 76);

            hurtBox = new Rectangle[5];
            hurtBox[0] = new Rectangle(858, 638, 37, 75);
            hurtBox[1] = new Rectangle(907, 636, 44, 75);
            hurtBox[2] = new Rectangle(972, 643, 29, 71);
            hurtBox[3] = new Rectangle(1021, 649, 37, 62);
            hurtBox[4] = new Rectangle(1092, 660, 27, 51);

            collisionBox = new Rectangle[5];
            collisionBox[0] = new Rectangle(894, 626, 22, 69);
            collisionBox[1] = new Rectangle(847, 649, 21, 58);
            collisionBox[2] = new Rectangle(992, 647, 18, 59);
            collisionBox[3] = new Rectangle(1008, 652, 21, 52);
            collisionBox[4] = new Rectangle(1044, 680, 17, 51);


            hitBox = new Rectangle[5];
            guardProcBox = new Rectangle[5]; 
        }
    }
}
