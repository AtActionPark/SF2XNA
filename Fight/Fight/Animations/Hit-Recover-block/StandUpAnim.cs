using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class StandUpAnim : Animation
    {
        public StandUpAnim()
        {
            timeToUpdate = 0.15f;
            isLooping = false;

            animations = new Rectangle[4];
            animations[0] = new Rectangle(774, 738, 52, 99);
            animations[1] = new Rectangle(831, 733, 52, 103);
            animations[2] = new Rectangle(889, 733, 55, 103);
            animations[3] = new Rectangle(948, 733, 43, 103);

            hurtBox = new Rectangle[4];
            hurtBox[0] = new Rectangle(778, 770, 34, 63);
            hurtBox[1] = new Rectangle(832, 742, 27, 91);
            hurtBox[2] = new Rectangle(896, 761, 36, 69);
            hurtBox[3] = new Rectangle(957, 740, 27, 69);

            collisionBox = new Rectangle[4];
            collisionBox[0] = new Rectangle(781, 776, 26, 56);
            collisionBox[1] = new Rectangle(831, 756, 33, 74);
            collisionBox[2] = new Rectangle(902, 766, 28, 66);
            collisionBox[3] = new Rectangle(960, 752, 18, 78);

            hitBox = new Rectangle[4];

            guardProcBox = new Rectangle[4];


        }
    }
}
