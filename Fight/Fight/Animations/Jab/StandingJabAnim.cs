using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class StandingJabAnim : Animation
    {

        public StandingJabAnim()
        {
            startUp = MoveList.standingJab.startUp;
            active = MoveList.standingJab.active;
            recovery = MoveList.standingJab.recover;

            isLooping = false;
            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp+active+recovery];
            for(int i = 0;i<startUp;i++)
                animations[i] = new Rectangle(0, 133, 48, 80);

            for (int i = 0; i < active; i++)
                animations[i+startUp] = new Rectangle(49, 133, 61, 80);

            for (int i = 0; i < recovery; i++)
                animations[i+startUp+active] = new Rectangle(114, 133, 48, 80);


            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                hurtBox[i] = new Rectangle(5, 133, 38, 80);

            for (int i = 0; i < active; i++)
                hurtBox[i + startUp] = new Rectangle(54, 133, 38, 80);

            for (int i = 0; i < recovery; i++)
                hurtBox[i + startUp + active] = new Rectangle(119, 133, 38, 80);


            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                collisionBox[i] = new Rectangle(10, 143, 28, 70);

            for (int i = 0; i < active; i++)
                collisionBox[i + startUp] = new Rectangle(59, 143, 28, 70);

            for (int i = 0; i < recovery; i++)
                collisionBox[i + startUp + active] = new Rectangle(124, 143, 28, 70);


            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                hitBox[i] = Rectangle.Empty;
                guardProcBox[i] = new Rectangle(15, 144, 87, 16);
            }

            for (int i = 0; i < active; i++)
            {
                hitBox[i + startUp] = new Rectangle(85, 145, 24, 11);
                guardProcBox[i + startUp] = new Rectangle(65, 144, 87, 16);
            }

            for (int i = 0; i < recovery; i++)
            {
                hitBox[i + startUp + active] = Rectangle.Empty;
                guardProcBox[i + startUp + active] = new Rectangle(128, 144, 87, 16);
            }

            
            
        }
    }
}
