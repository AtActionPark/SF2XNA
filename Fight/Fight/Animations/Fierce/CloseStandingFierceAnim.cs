using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class CloseStandingFierceAnim : Animation
    {

        public CloseStandingFierceAnim()
        {
            startUp = MoveList.closeStandingFierce.startUp;
            active = MoveList.closeStandingFierce.active;
            recovery = MoveList.closeStandingFierce.recover;

            isLooping = false;
            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp+active+recovery];
            for (int i = 0; i < startUp; i++)
            {
                if(i<startUp/2)
                    animations[i] = new Rectangle(1012, 129, 42, 87);
                else
                    animations[i] = new Rectangle(1057, 128, 63, 87);
            }

            for (int i = 0; i < active; i++)
                animations[i + startUp] = new Rectangle(1125, 112, 56, 103);

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 2)
                    animations[i + startUp + active] = new Rectangle(1187, 127, 61, 87);
                else
                    animations[i + startUp + active] = new Rectangle(1250, 131, 47, 83);
            }
                


            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if(i<startUp/2)
                    hurtBox[i] = new Rectangle(1021, 132, 30, 77);
                else
                    hurtBox[i] = new Rectangle(1075, 131, 38, 77);
            }
               

            for (int i = 0; i < active; i++)
                hurtBox[i + startUp] = new Rectangle(1137, 128, 41, 77);

            for (int i = 0; i < recovery; i++)
            {
                if(i<recovery/2)
                    hurtBox[i + startUp + active] = new Rectangle(1200, 136, 39, 75);
                else
                    hurtBox[i + startUp + active] = new Rectangle(1259, 135, 34, 75);
            }
                


            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if(i<startUp/2)
                    collisionBox[i] = new Rectangle(1025, 136, 21, 73);
                else
                    collisionBox[i] = new Rectangle(1080, 141, 19, 69);
            }
                

            for (int i = 0; i < active; i++)
                collisionBox[i + startUp] = new Rectangle(1149, 140, 18, 70);

            for (int i = 0; i < recovery; i++)
            {
                if(i<recovery/2)
                    collisionBox[i + startUp + active] = new Rectangle(1208, 144, 18, 67);
                else
                    collisionBox[i + startUp + active] = new Rectangle(1268, 148, 14, 63);
            }
                


            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                {
                    hitBox[i] = Rectangle.Empty;
                    guardProcBox[i] = new Rectangle(1039, 121, 23, 52);
                }
                else
                {
                    hitBox[i] = Rectangle.Empty;
                    guardProcBox[i] = new Rectangle(1097, 116, 30, 55);
                }
                
            }

            for (int i = 0; i < active; i++)
            {
                hitBox[i + startUp] = new Rectangle(1159, 112, 24, 47);
                guardProcBox[i + startUp] = new Rectangle(1157, 107, 34, 68);
            }

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 2)
                {
                    hitBox[i + startUp + active] = Rectangle.Empty;
                    guardProcBox[i + startUp + active] = new Rectangle(1218, 112, 34, 63);
                }
                else
                {
                    hitBox[i + startUp + active] = Rectangle.Empty;
                    guardProcBox[i + startUp + active] = new Rectangle(1273, 122, 25, 54);
                }
            }

            
            
        }
    }
}
