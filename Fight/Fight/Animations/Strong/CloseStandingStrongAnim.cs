using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class CloseStandingStrongAnim : Animation
    {

        public CloseStandingStrongAnim()
        {
            startUp = MoveList.closeStandingStrong.startUp;
            active = MoveList.closeStandingStrong.active;
            recovery = MoveList.closeStandingStrong.recover;

            isLooping = false;
            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                    animations[i] = new Rectangle(616, 132, 43, 82);
                else
                    animations[i] = new Rectangle(666, 128, 49, 86);
            }

            for (int i = 0; i < active; i++)
            {
                if (i < active / 2)
                    animations[i + startUp] = new Rectangle(719, 129, 61, 85);
                else
                    animations[i + startUp] = new Rectangle(785, 129, 48, 85);
            }

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 3)
                    animations[i + startUp + active] = new Rectangle(839, 129, 61, 85);
                else if (i < 2 * recovery / 3)
                    animations[i + startUp + active] = new Rectangle(906, 129, 51, 85);
                else
                    animations[i + startUp + active] = new Rectangle(960, 133, 46, 81);
            }



            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                    hurtBox[i] = new Rectangle(621, 136, 32, 77);
                else
                    hurtBox[i] = new Rectangle(678, 132, 30, 78);
            }

            for (int i = 0; i < active; i++)
            {
                if (i < active / 2)
                    hurtBox[i + startUp] = new Rectangle(734, 132, 39, 77);
                else
                    hurtBox[i + startUp] = new Rectangle(797, 132, 34, 76);
            }

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 3)
                    hurtBox[i + startUp + active] = new Rectangle(851, 132, 43, 73);
                else if (i < 2 * recovery / 3)
                    hurtBox[i + startUp + active] = new Rectangle(919, 131, 29, 75);
                else
                    hurtBox[i + startUp + active] = new Rectangle(967, 136, 32, 69);
            }


            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                    collisionBox[i] = new Rectangle(629, 142, 16, 69);
                else
                    collisionBox[i] = new Rectangle(685, 139, 15, 71);
            }

            for (int i = 0; i < active; i++)
            {
                if (i < active / 2)
                    collisionBox[i + startUp] = new Rectangle(743, 139, 17, 69);
                else
                    collisionBox[i + startUp] = new Rectangle(807, 141, 18, 64);
            }

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 3)
                    collisionBox[i + startUp + active] = new Rectangle(860, 145, 21, 63);
                else if (i < 2 * recovery / 3)
                    collisionBox[i + startUp + active] = new Rectangle(924, 138, 16, 69);
                else
                    collisionBox[i + startUp + active] = new Rectangle(976, 146, 16, 60);
            }


            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                {
                    guardProcBox[i] = new Rectangle(641, 140, 24, 26);
                }
                else
                {
                    guardProcBox[i] = new Rectangle(693, 137, 30, 32);
                }
                hitBox[i] = Rectangle.Empty;
            }

            for (int i = 0; i < active; i++)
            {
                if (i < active / 2)
                {
                    guardProcBox[i + startUp] = new Rectangle(750, 133, 37, 38);
                    hitBox[i + startUp] = new Rectangle(755, 137, 25, 27);
                }
                else
                {
                    guardProcBox[i + startUp] = new Rectangle(813, 130, 29, 42);
                    hitBox[i + startUp] = new Rectangle(817, 132, 19, 36);
                }
            }

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 3)
                    guardProcBox[i + startUp + active] = new Rectangle(870, 132, 42, 30);
                else if (i < 2 * recovery / 3)
                    guardProcBox[i + startUp + active] = new Rectangle(924, 138, 39, 32);
                else
                    guardProcBox[i + startUp + active] = new Rectangle(985, 136, 24, 38);
                hitBox[i + startUp + active] = Rectangle.Empty;
            }

        }
    }
}
