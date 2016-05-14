using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class CloseStandingRoundhouseAnim : Animation
    {

        public CloseStandingRoundhouseAnim()
        {
            startUp = MoveList.closeStandingRoundhouse.startUp;
            active = MoveList.closeStandingRoundhouse.active;
            recovery = MoveList.closeStandingRoundhouse.recover;

            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp+active+recovery];
            for (int i = 0; i < startUp; i++)
            {
                animations[i] = new Rectangle(968, 261, 48, 84);
            }


            for (int i = 0; i < active; i++)
            {
                if(i<active/3)
                    animations[i + startUp] = new Rectangle(1019, 247, 83, 98);
                else if (i<2*active/3)
                    animations[i + startUp] = new Rectangle(1106, 236, 53, 110);
                else
                    animations[i + startUp] = new Rectangle(1163, 242, 81, 103);
            }


            for (int i = 0; i < recovery; i++)
            {
                animations[i + startUp + active] = new Rectangle(1250, 253, 48, 92);
            }


            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                hurtBox[i] = new Rectangle(987, 263, 24, 79);
            }

            for (int i = 0; i < active; i++)
            {
                if(i<active/3)
                    hurtBox[i + startUp] = new Rectangle(1048, 255, 37, 82);
                else if (i<2*active/3)
                    hurtBox[i + startUp] = new Rectangle(1135, 242, 21, 90);
                else
                    hurtBox[i + startUp] = new Rectangle(1189, 251, 42, 91);
            }


            for (int i = 0; i < recovery; i++)
            {
                hurtBox[i + startUp + active] = new Rectangle(1271, 264, 24, 76);
            }
                


            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                collisionBox[i] = new Rectangle(989, 270, 15, 71);
            }


            for (int i = 0; i < active; i++)
            {
                if(i<active/3)
                    collisionBox[i + startUp] = new Rectangle(1052, 271, 15, 69);
                else if (i<2*active/3)
                    collisionBox[i + startUp] = new Rectangle(1135, 265, 13, 72);
                else
                    collisionBox[i + startUp] = new Rectangle(1194, 269, 15, 72);
            }


            for (int i = 0; i < recovery; i++)
            {
                collisionBox[i + startUp + active] = new Rectangle(1274, 280, 12, 58);
            }
                


            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {

                hitBox[i] = Rectangle.Empty;
                guardProcBox[i] = new Rectangle(991, 266, 30, 67);
            }

            for (int i = 0; i < active; i++)
            {
                if (i < active / 3)
                {
                    hitBox[i + startUp] = new Rectangle(1071, 254, 31, 54);
                    guardProcBox[i + startUp] = new Rectangle(1057, 251, 46, 88);
                }
                else if (i<2*active/3)
                {
                    hitBox[i + startUp] = Rectangle.Empty;
                    guardProcBox[i + startUp] = new Rectangle(1139, 238, 23, 99);

                }
                else
                {
                    hitBox[i + startUp] = new Rectangle(1208, 248, 36, 55);
                    guardProcBox[i + startUp] = new Rectangle(1199, 241, 49, 103);
                }
            }

            for (int i = 0; i < recovery; i++)
            {
                hitBox[i + startUp + active] = Rectangle.Empty;
                guardProcBox[i + startUp + active] = new Rectangle(1275, 250, 27, 88);
            }

            isLooping = false;
        }
    }
}
