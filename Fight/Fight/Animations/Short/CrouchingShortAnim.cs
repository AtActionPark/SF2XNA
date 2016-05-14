using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class CrouchingShortAnim : Animation
    {

        public CrouchingShortAnim()
        {
            startUp = MoveList.crouchingShort.startUp;
            active = MoveList.crouchingShort.active;
            recovery = MoveList.crouchingShort.recover;

            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp+active+recovery];
            for(int i = 0;i<startUp;i++)
                animations[i] = new Rectangle(660, 415, 55, 58);

            for (int i = 0; i < active; i++)
                animations[i + startUp] = new Rectangle(714, 416, 70, 57);

            for (int i = 0; i < recovery; i++)
                animations[i + startUp + active] = new Rectangle(790, 416, 49, 57);


            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                hurtBox[i] = new Rectangle(670, 419, 33, 54);

            for (int i = 0; i < active; i++)
                hurtBox[i + startUp] = new Rectangle(725, 419, 44, 53);

            for (int i = 0; i < recovery; i++)
                hurtBox[i + startUp + active] = new Rectangle(799, 418, 34, 54);


            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                collisionBox[i] = new Rectangle(675, 424, 24, 45);

            for (int i = 0; i < active; i++)
                collisionBox[i + startUp] = new Rectangle(729, 421, 23, 48);

            for (int i = 0; i < recovery; i++)
                collisionBox[i + startUp + active] = new Rectangle(806, 421, 22, 49);


            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                hitBox[i] = Rectangle.Empty;
                guardProcBox[i] = new Rectangle(681, 439, 37, 33);
            }

            for (int i = 0; i < active; i++)
            {
                hitBox[i + startUp] = new Rectangle(739, 444, 44, 25);
                guardProcBox[i + startUp] = new Rectangle(737, 439, 57, 34);
            }

            for (int i = 0; i < recovery; i++)
            {
                hitBox[i + startUp + active] = Rectangle.Empty;
                guardProcBox[i + startUp + active] = new Rectangle(805, 438, 41, 32);
            }

            isLooping = false;
        }
    }
}
