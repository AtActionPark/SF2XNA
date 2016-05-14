using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class ForwardJumpAnim : Animation
    {
        public ForwardJumpAnim()
        {
            isLooping = false;
            timeToUpdate = 0.12f;

            animations = new Rectangle[7];
            animations[0] = new Rectangle(795, 7, 36, 93);
            animations[1] = new Rectangle(795, 7, 36, 93);
            animations[2] = new Rectangle(833, 8, 64, 92);
            animations[3] = new Rectangle(901, 8, 34, 92);
            animations[4] = new Rectangle(942, 8, 74, 92);
            animations[5] = new Rectangle(1020, 8, 45, 92);
            animations[6] = new Rectangle(1070, 8, 35, 92);

            hurtBox = new Rectangle[7];
            hurtBox[0] = new Rectangle(799, 20, 24, 64);
            hurtBox[1] = new Rectangle(799, 20, 24, 64);
            hurtBox[2] = new Rectangle(838, 40, 55, 31);
            hurtBox[3] = new Rectangle(904, 27, 26, 68);
            hurtBox[4] = new Rectangle(946, 38, 65, 32);
            hurtBox[5] = new Rectangle(1024, 25, 36, 61);
            hurtBox[6] = new Rectangle(1074, 17, 29, 77);

            collisionBox = new Rectangle[7];
            collisionBox[0] = new Rectangle(802, 23, 16, 54);
            collisionBox[1] = new Rectangle(802, 23, 16, 54);
            collisionBox[2] = new Rectangle(860, 44, 18, 27);
            collisionBox[3] = new Rectangle(906, 52, 22, 31);
            collisionBox[4] = new Rectangle(951, 44, 35, 27);
            collisionBox[5] = new Rectangle(1030, 31, 25, 36);
            collisionBox[6] = new Rectangle(1078, 21, 17, 65);

            hitBox = new Rectangle[7];
            guardProcBox = new Rectangle[7]; ;

        }
    }
}
