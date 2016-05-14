using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class StandingRoundhouseAnim : Animation
    {

        public StandingRoundhouseAnim()
        {
            startUp = MoveList.standingRoundhouse.startUp;
            active = MoveList.standingRoundhouse.active;
            recovery = MoveList.standingRoundhouse.recover;

            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp+active+recovery];
            for (int i = 0; i < startUp; i++)
            {
                if(i<startUp/2)
                    animations[i] = new Rectangle(193, 263, 47, 83);
                else
                    animations[i] = new Rectangle(245, 261, 56, 84);
            }


            for (int i = 0; i < active; i++)
            {
                animations[i + startUp] = new Rectangle(305, 261, 70, 85);
            }


            for (int i = 0; i < recovery; i++)
            {
                if(i<recovery/2)
                    animations[i + startUp + active] = new Rectangle(381, 267, 60, 78);
                else
                    animations[i + startUp + active] = new Rectangle(444, 266, 47, 79);
            }
                


            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                    hurtBox[i] = new Rectangle(198, 266, 32, 73);
                else
                    hurtBox[i] = new Rectangle(253, 262, 39, 80);
            }


            for (int i = 0; i < active; i++)
            {
                hurtBox[i + startUp] = new Rectangle(310, 273, 51, 67);
            }


            for (int i = 0; i < recovery; i++)
            {
                if(i<recovery/2)
                    hurtBox[i + startUp + active] = new Rectangle(386, 268, 45, 74);
                else
                    hurtBox[i + startUp + active] = new Rectangle(446, 266, 32, 72);
            }
                


            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if(i<startUp/2)
                    collisionBox[i] = new Rectangle(205, 274, 21, 66);
                else
                    collisionBox[i] = new Rectangle(260, 276, 23, 64);
            }


            for (int i = 0; i < active; i++)
            {
                collisionBox[i + startUp] = new Rectangle(321, 272, 24, 67);
            }


            for (int i = 0; i < recovery; i++)
            {
                if(i<recovery/2)
                    collisionBox[i + startUp + active] = new Rectangle(391, 278, 26, 63);
                else
                    collisionBox[i + startUp + active] = new Rectangle(452, 273, 22, 66);
            }
                


            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                {
                    hitBox[i] = Rectangle.Empty;
                    guardProcBox[i] = new Rectangle(224, 264, 22, 40);
                }
                else
                {
                    hitBox[i] = Rectangle.Empty;
                    guardProcBox[i] = new Rectangle(275, 259, 33, 49);
                }
                
            }

            for (int i = 0; i < active; i++)
            {
                hitBox[i + startUp] = new Rectangle(336, 261, 38, 46);
                guardProcBox[i + startUp] = new Rectangle(330, 256, 53, 62);
            }

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 2)
                {
                    hitBox[i + startUp + active] = Rectangle.Empty;
                    guardProcBox[i + startUp + active] = new Rectangle(408, 262, 36, 50);
                }
                else
                {
                    hitBox[i + startUp + active] = Rectangle.Empty;
                    guardProcBox[i + startUp + active] = new Rectangle(467, 268, 29, 40);
                }

            }

            isLooping = false;
            //displacement[2] = MoveList.standingRoundhouse.displacement;
        }
    }
}
