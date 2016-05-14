using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class CrouchingForwardAnim : Animation
    {

        public CrouchingForwardAnim()
        {
            startUp = MoveList.crouchingForward.startUp;
            active = MoveList.crouchingForward.active;
            recovery = MoveList.crouchingForward.recover;

            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp+active+recovery];
            for(int i = 0;i<startUp;i++)
                animations[i] = new Rectangle(846, 416, 50, 57);

            for (int i = 0; i < active; i++)
                animations[i + startUp] = new Rectangle(898, 425, 92, 48);

            for (int i = 0; i < recovery; i++)
                animations[i + startUp + active] = new Rectangle(991, 416, 52, 56);


            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                hurtBox[i] = new Rectangle(855, 421, 36, 46);

            for (int i = 0; i < active; i++)
                hurtBox[i + startUp] = new Rectangle(913, 431, 49, 39);

            for (int i = 0; i < recovery; i++)
                hurtBox[i + startUp + active] = new Rectangle(1004, 422, 32, 47);


            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                collisionBox[i] = new Rectangle(863, 425, 19, 41);

            for (int i = 0; i < active; i++)
                collisionBox[i + startUp] = new Rectangle(925, 434, 19, 37);

            for (int i = 0; i < recovery; i++)
                collisionBox[i + startUp + active] = new Rectangle(1009, 428, 20, 42);


            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                hitBox[i] = Rectangle.Empty;
                guardProcBox[i] = new Rectangle(873, 440, 52, 27);
            }

            for (int i = 0; i < active; i++)
            {
                hitBox[i + startUp] = new Rectangle(931, 440, 59, 31);
                guardProcBox[i + startUp] = new Rectangle(928, 434, 71, 37);
            }

            for (int i = 0; i < recovery; i++)
            {
                hitBox[i + startUp + active] = Rectangle.Empty;
                guardProcBox[i + startUp + active] = new Rectangle(1006, 434, 56, 36);
            }

            isLooping = false;
        }
    }
}
