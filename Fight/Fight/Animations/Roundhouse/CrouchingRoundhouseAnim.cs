using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class CrouchingRoundhouseAnim : Animation
    {

        public CrouchingRoundhouseAnim()
        {
            startUp = MoveList.crouchingRoundhouse.startUp;
            active = MoveList.crouchingRoundhouse.active;
            recovery = MoveList.crouchingRoundhouse.recover;

            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                animations[i] = new Rectangle(1048, 418, 52, 55);
            }

            for (int i = 0; i < active; i++)
                animations[i + startUp] = new Rectangle(1098, 420, 76, 53);

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 3)
                    animations[i + startUp + active] = new Rectangle(1178, 420, 52, 54);
                else if (i < 2*recovery / 3)
                    animations[i + startUp + active] = new Rectangle(1233, 418, 48, 56);
                else
                    animations[i + startUp + active] = new Rectangle(1286, 416, 44, 58);
            }



            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                hurtBox[i] = new Rectangle(1068, 423, 24, 44);
            }

            for (int i = 0; i < active; i++)
                hurtBox[i + startUp] = new Rectangle(1113, 422, 46, 49);

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 3)
                    hurtBox[i + startUp + active] = new Rectangle(1193, 424, 32, 44);
                else if (i < 2 * recovery / 3)
                    hurtBox[i + startUp + active] = new Rectangle(1237, 422, 34, 46);
                else
                    hurtBox[i + startUp + active] = new Rectangle(1292, 422, 28, 47);
            }


            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                collisionBox[i] = new Rectangle(1069, 427, 18, 41);
            }

            for (int i = 0; i < active; i++)
                collisionBox[i + startUp] = new Rectangle(1117, 424, 20, 47);

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 3)
                    collisionBox[i + startUp + active] = new Rectangle(1198, 430, 18, 38);
                else if (i < 2 * recovery / 3)
                    collisionBox[i + startUp + active] = new Rectangle(1243, 430, 18, 37);
                else
                    collisionBox[i + startUp + active] = new Rectangle(1299, 431, 18, 38);
            }


            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                guardProcBox[i] = new Rectangle(1075, 442, 44, 25);
                hitBox[i] = Rectangle.Empty;
            }

            for (int i = 0; i < active; i++)
            {
                hitBox[i + startUp] = new Rectangle(1124, 435, 50, 35);
                guardProcBox[i + startUp] = new Rectangle(1123, 432, 68, 41);
            }

            for (int i = 0; i < recovery; i++)
            {

                if (i < recovery / 3)
                    guardProcBox[i + startUp + active] = new Rectangle(1203, 433, 29, 38);
                else if (i < 2 * recovery / 3)
                    guardProcBox[i + startUp + active] = new Rectangle(1251, 437, 33, 33);
                else
                    guardProcBox[i + startUp + active] = new Rectangle(1309, 436, 27, 33);
                hitBox[i + startUp + active] = Rectangle.Empty;
            }

            isLooping = false;
        }
    }
}
