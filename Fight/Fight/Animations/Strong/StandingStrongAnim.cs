using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class StandingStrongAnim : Animation
    {

        public StandingStrongAnim()
        {
            startUp = MoveList.standingStrong.startUp;
            active = MoveList.standingStrong.active;
            recovery = MoveList.standingStrong.recover;

            isLooping = false;
            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                    animations[i] = new Rectangle(168, 133, 45, 82);
                else
                    animations[i] = new Rectangle(216, 129, 53, 86);
            }

            for (int i = 0; i < active; i++)
                animations[i + startUp] = new Rectangle(274, 130, 73, 85);

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 2)
                    animations[i + startUp + active] = new Rectangle(349, 130, 55, 85);
                else
                    animations[i + startUp + active] = new Rectangle(409, 131, 46, 84);
            }



            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                    hurtBox[i] = new Rectangle(178, 136, 28, 76);
                else
                    hurtBox[i] = new Rectangle(232, 133, 29, 75);
            }


            for (int i = 0; i < active; i++)
                hurtBox[i + startUp] = new Rectangle(294, 133, 43, 79);

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 2)
                    hurtBox[i + startUp + active] = new Rectangle(368, 132, 30, 77);
                else
                    hurtBox[i + startUp + active] = new Rectangle(418, 135, 28, 75);
            }



            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                    collisionBox[i] = new Rectangle(182, 141, 18, 71);
                else
                    collisionBox[i] = new Rectangle(238, 140, 18, 73);
            }


            for (int i = 0; i < active; i++)
                collisionBox[i + startUp] = new Rectangle(297, 139, 21, 71);

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 2)
                    collisionBox[i + startUp + active] = new Rectangle(372, 137, 18, 70);
                else
                    collisionBox[i + startUp + active] = new Rectangle(422, 139, 15, 72);
            }



            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                {
                    hitBox[i] = Rectangle.Empty;
                    guardProcBox[i] = new Rectangle(196, 138, 27, 23);
                }
                else
                {
                    hitBox[i] = Rectangle.Empty;
                    guardProcBox[i] = new Rectangle(253, 140, 25, 22);
                }

            }

            for (int i = 0; i < active; i++)
            {
                hitBox[i + startUp] = new Rectangle(310, 140, 38, 16);
                guardProcBox[i + startUp] = new Rectangle(308, 135, 54, 23);
            }

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 2)
                {
                    hitBox[i + startUp + active] = Rectangle.Empty;
                    guardProcBox[i + startUp + active] = new Rectangle(380, 133, 30, 29);
                }
                else
                {
                    hitBox[i + startUp + active] = Rectangle.Empty;
                    guardProcBox[i + startUp + active] = new Rectangle(433, 135, 27, 32);
                }
            }

            
            
        }
    }
}
