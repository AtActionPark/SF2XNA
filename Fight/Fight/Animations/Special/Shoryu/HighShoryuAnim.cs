using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class HighShoryuAnim : Animation
    {
        public HighShoryuAnim()
        {
            startUp = MoveList.highShoryu.startUp;
            active = MoveList.highShoryu.active;
            recovery = MoveList.highShoryu.recover;

            isLooping = false;
            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp+active+recovery];
            for (int i = 0; i < startUp; i++)
            {
                if(i<startUp/2)
                    animations[i] = new Rectangle(625, 505, 48, 101);
                else
                    animations[i] = new Rectangle(671, 505, 49, 101);
            }

            for (int i = 0; i < active; i++)
            {
                if(i<3)
                    animations[i + startUp] = new Rectangle(722, 505, 53, 108);
                else 
                    animations[i + startUp] = new Rectangle(777, 505, 41, 110); 
            }

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 3)
                     animations[i + startUp + active] = new Rectangle(821, 505, 35, 110);
                else if (i<2*recovery/3)
                    animations[i + startUp + active] = new Rectangle(855, 505, 36, 110);
                else
                    animations[i + startUp + active] = new Rectangle(899, 505, 45, 110);
            }

            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                    hurtBox[i] = new Rectangle(635, 553, 24, 69);
                else
                    hurtBox[i] = new Rectangle(683, 550, 28, 60);
            }

            for (int i = 0; i < active; i++)
            {
                if (i < 3)
                    hurtBox[i + startUp] = new Rectangle(735, 542, 24, 67);
                else 
                    hurtBox[i + startUp] = new Rectangle(783, 541, 14, 71);   
            }

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 3)
                    hurtBox[i + startUp + active] = new Rectangle(829, 543, 18, 65);
                else if (i < 2*recovery / 3)
                    hurtBox[i + startUp + active] = new Rectangle(862, 530, 23, 79);
                else
                    hurtBox[i + startUp + active] = new Rectangle(900, 531, 32, 80);
            }

            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                    collisionBox[i] = new Rectangle(641, 572, 15, 39);
                else
                    collisionBox[i] = new Rectangle(693, 560, 15, 50);
            }

            for (int i = 0; i < active; i++)
            {
                if (i < 3)
                    collisionBox[i + startUp] = new Rectangle(743, 558, 15, 52);
                else 
                    collisionBox[i + startUp] = new Rectangle(791, 554, 14, 55);
            }

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 3)
                    collisionBox[i + startUp + active] = new Rectangle(835, 550, 14, 50);
                else if (i<2*recovery/3)
                    collisionBox[i + startUp + active] = new Rectangle(868, 554, 15, 53);
                else
                    collisionBox[i + startUp + active] = new Rectangle(907, 557, 16, 54);
            }

            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                hitBox[i] = Rectangle.Empty;
                guardProcBox[i] = new Rectangle(639+52, 566, 74, 14);
            }

            for (int i = 0; i < active; i++)
            {
                if (i < 3)
                {
                    hitBox[i + startUp] = new Rectangle(759, 542, 14, 29);
                    guardProcBox[i + startUp] = new Rectangle(740, 566, 74, 14);
                }
                else
                {
                    hitBox[i + startUp] = new Rectangle(798, 507, 16, 57);
                    guardProcBox[i + startUp] = new Rectangle(789, 566, 74, 14);
                }
            }

            for (int i = 0; i < recovery; i++)
            {
                //hitBox[i + startUp] = new Rectangle(839, 512, 12, 60);
                hitBox[i + startUp + active] = Rectangle.Empty;
                guardProcBox[i + startUp + active] = Rectangle.Empty;
            }

            displacement = new Vector2[startUp + active + recovery];
            for (int i = 0; i < startUp + active + recovery;i++ )
                displacement[i] = Vector2.Zero;

            displacement[9] = MoveList.lightShoryu.displacement;


        }
    }
}
