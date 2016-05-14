using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class LightHadoAnim : Animation
    {
        public LightHadoAnim()
        {
            startUp = MoveList.lightHado.startUp;
            active = MoveList.lightHado.active;
            recovery = MoveList.lightHado.recover;

            isLooping = false;
            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp /4)
                    animations[i] = new Rectangle(4, 631, 52, 87);
                else if (i < 2*startUp / 4)
                    animations[i] = new Rectangle(60, 632, 67, 86);
                else if (i < 3*startUp / 4)
                    animations[i] = new Rectangle(130, 641, 67, 76);
                else
                    animations[i] = new Rectangle(202, 641, 91, 76);
            }

            for (int i = 0; i < recovery; i++)
            {
                animations[i + startUp] = new Rectangle(297, 632, 80, 86);
            }

           

            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 4)
                    hurtBox[i] = new Rectangle(13, 639, 36, 73);
                else if (i < 2 * startUp / 4)
                    hurtBox[i] = new Rectangle(68, 647, 43, 67);
                else if (i < 3 * startUp / 4)
                    hurtBox[i] = new Rectangle(144, 646, 38, 68);
                else
                    hurtBox[i] = new Rectangle(213, 648, 52, 65);
            }

            for (int i = 0; i < recovery; i++)
            {
                hurtBox[i + startUp] = new Rectangle(310, 644, 58, 72);
            }


            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 4)
                    collisionBox[i] = new Rectangle(21, 647, 18, 68);
                else if (i < 2 * startUp / 4)
                    collisionBox[i] = new Rectangle(73, 656, 23, 55);
                else if (i < 3 * startUp / 4)
                    collisionBox[i] = new Rectangle(153, 659, 18, 54);
                else
                    collisionBox[i] = new Rectangle(236, 659, 19, 55);
            }

            for (int i = 0; i < recovery; i++)
            {
                collisionBox[i + startUp] = new Rectangle(331, 659, 20, 56);
            }

            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 4)
                    guardProcBox[i] = new Rectangle(13, 639, 36, 73);
                else if (i < 2 * startUp / 4)
                    guardProcBox[i] = new Rectangle(68, 647, 43, 67);
                else if (i < 3 * startUp / 4)
                    guardProcBox[i] = new Rectangle(144, 646, 38, 68);
                else
                    guardProcBox[i] = new Rectangle(213, 648, 52, 65);
            }
            for (int i = 0; i <recovery; i++)
                guardProcBox[i] = new Rectangle(297, 632, 80, 86); ;
            hitBox = new Rectangle[startUp + active + recovery];
        }
    }
}
