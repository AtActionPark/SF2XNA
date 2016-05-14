using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class CloseStandingForwardAnim : Animation
    {

        public CloseStandingForwardAnim()
        {
            startUp = MoveList.closeStandingForward.startUp;
            active = MoveList.closeStandingForward.active;
            recovery = MoveList.closeStandingForward.recover;

            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if(i<startUp/2)
                    animations[i] = new Rectangle(684, 259, 52, 86);
                else
                    animations[i] = new Rectangle(740, 261, 51, 84);
            }

            for (int i = 0; i < active; i++)
                animations[i + startUp] = new Rectangle(795, 254, 55, 91);

            for (int i = 0; i < recovery; i++)
            {
                if(i<recovery/2)
                    animations[i + startUp + active] = new Rectangle(854, 262, 51, 83);
                else
                    animations[i + startUp + active] = new Rectangle(909, 259, 52, 85);
            }
                


            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                    hurtBox[i] = new Rectangle(690, 269, 41, 71);
                else
                    hurtBox[i] = new Rectangle(750, 264, 34, 75);
            }

            for (int i = 0; i < active; i++)
                hurtBox[i + startUp] = new Rectangle(816, 256, 32, 82);

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 2)
                    hurtBox[i + startUp + active] = new Rectangle(871, 266, 31, 74);
                else
                    hurtBox[i + startUp + active] = new Rectangle(917, 266, 40, 74);
            }


            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                    collisionBox[i] = new Rectangle(697, 273, 22, 67);
                else
                    collisionBox[i] = new Rectangle(759, 274, 17, 63);
            }

            for (int i = 0; i < active; i++)
                collisionBox[i + startUp] = new Rectangle(819, 269, 19, 72);

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 2)
                    collisionBox[i + startUp + active] = new Rectangle(874, 276, 16, 63);
                else
                    collisionBox[i + startUp + active] = new Rectangle(923, 279, 19, 65);
            }


            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                    guardProcBox[i] = new Rectangle(718, 273, 35, 39);
                else
                    guardProcBox[i] = new Rectangle(771, 274, 33, 45);
                hitBox[i] = Rectangle.Empty;
            }

            for (int i = 0; i < active; i++)
            {
                hitBox[i + startUp] = new Rectangle(837, 269, 14, 45);
                guardProcBox[i + startUp] = new Rectangle(831, 264, 42, 50);
            }

            for (int i = 0; i < recovery; i++)
            {
                
                if (i < recovery/ 2)
                    guardProcBox[i + startUp + active] = new Rectangle(885, 266, 34, 46);
                else
                    guardProcBox[i + startUp + active] = new Rectangle(936, 268, 36, 47);
                hitBox[i + startUp + active] = Rectangle.Empty;
            }

            isLooping = false;
        }
    }
}
