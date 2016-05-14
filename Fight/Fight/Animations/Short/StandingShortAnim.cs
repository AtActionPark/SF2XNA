using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class StandingShortAnim : Animation
    {

        public StandingShortAnim()
        {
            startUp = MoveList.standingShort.startUp;
            active = MoveList.standingShort.active;
            recovery = MoveList.standingShort.recover;

            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp+active+recovery];
            for(int i = 0;i<startUp;i++)
                animations[i] = new Rectangle(6, 260, 49, 86);

            for (int i = 0; i < active; i++)
                animations[i + startUp] = new Rectangle(60, 257, 69, 89);

            for (int i = 0; i < recovery; i++)
                animations[i + startUp + active] = new Rectangle(134, 260, 50, 86);


            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                hurtBox[i] = new Rectangle(10, 263, 32, 78);

            for (int i = 0; i < active; i++)
                hurtBox[i + startUp] = new Rectangle(66, 260, 48, 81);

            for (int i = 0; i < recovery; i++)
                hurtBox[i + startUp + active] = new Rectangle(137, 263, 35, 81);


            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                collisionBox[i] = new Rectangle(14, 267, 16, 72);

            for (int i = 0; i < active; i++)
                collisionBox[i + startUp] = new Rectangle(71, 267, 24, 75);

            for (int i = 0; i < recovery; i++)
                collisionBox[i + startUp + active] = new Rectangle(143, 269, 23, 71);


            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                hitBox[i] = Rectangle.Empty;
                guardProcBox[i] = new Rectangle(26, 264, 37, 48);
            }

            for (int i = 0; i < active; i++)
            {
                hitBox[i + startUp] = new Rectangle(88, 258, 43, 43);
                guardProcBox[i + startUp] = new Rectangle(95, 260, 38, 59);
            }

            for (int i = 0; i < recovery; i++)
            {
                hitBox[i + startUp + active] = Rectangle.Empty;
                guardProcBox[i + startUp + active] = new Rectangle(156, 267, 34, 54);
            }

            isLooping = false;
        }
    }
}
