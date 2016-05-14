using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class CrouchingJabAnim : Animation
    {
        public CrouchingJabAnim()
        {
            startUp = MoveList.crouchingJab.startUp;
            active = MoveList.crouchingJab.active;
            recovery = MoveList.crouchingJab.recover;

            isLooping = false;
            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp+active+recovery];
            for(int i = 0;i<startUp;i++)
                animations[i] = new Rectangle(9, 419, 47, 55);

            for (int i = 0; i < active; i++)
                animations[i+startUp] = new Rectangle(61, 419, 62, 55);

            for (int i = 0; i < recovery; i++)
                animations[i + startUp + active] = new Rectangle(127, 419, 47, 55);


            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                hurtBox[i] = new Rectangle(20, 423, 29, 51);

            for (int i = 0; i < active; i++)
                hurtBox[i + startUp] = new Rectangle(72, 422, 37, 51);

            for (int i = 0; i < recovery; i++)
                hurtBox[i + startUp + active] = new Rectangle(135, 422, 34, 51);


            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                collisionBox[i] = new Rectangle(23, 427, 20, 46);

            for (int i = 0; i < active; i++)
                collisionBox[i + startUp] = new Rectangle(76, 426, 21, 47);

            for (int i = 0; i < recovery; i++)
                collisionBox[i + startUp + active] = new Rectangle(142, 429, 22, 44);


            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                hitBox[i] = Rectangle.Empty;
                guardProcBox[i] = new Rectangle(15, 144, 87, 16);
            }

            for (int i = 0; i < active; i++)
            {
                hitBox[i + startUp] = new Rectangle(94, 428, 28, 10);
                guardProcBox[i + startUp] = new Rectangle(87, 424, 42, 17);
            }

            for (int i = 0; i < recovery; i++)
            {
                hitBox[i + startUp + active] = Rectangle.Empty;
                guardProcBox[i + startUp + active] = new Rectangle(128, 144, 87, 16);
            }

            
            
        }
    }
}
