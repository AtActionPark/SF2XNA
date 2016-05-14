using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class CrouchingFierceAnim : Animation
    {
        public CrouchingFierceAnim()
        {
            startUp = MoveList.crouchingFierce.startUp;
            active = MoveList.crouchingFierce.active;
            recovery = MoveList.crouchingFierce.recover;

            isLooping = false;
            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                    animations[i] = new Rectangle(399, 408, 46, 65);
                else
                    animations[i] = new Rectangle(450, 392, 50, 82);
            }

            for (int i = 0; i < active; i++)
                animations[i + startUp] = new Rectangle(505, 362, 47, 111);

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 2)
                    animations[i + startUp + active] = new Rectangle(555, 392, 50, 81);
                else
                    animations[i + startUp + active] = new Rectangle(608, 407, 45, 66);
            }



            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                    hurtBox[i] = new Rectangle(410, 412, 30, 55);
                else
                    hurtBox[i] = new Rectangle(460, 401, 38, 65);
            }


            for (int i = 0; i < active; i++)
                hurtBox[i + startUp] = new Rectangle(518, 386, 32, 85);

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 2)
                    hurtBox[i + startUp + active] = new Rectangle(567, 395, 29, 76);
                else
                    hurtBox[i + startUp + active] = new Rectangle(619, 410, 30, 60);
            }



            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                    collisionBox[i] = new Rectangle(416, 419, 14, 47);
                else
                    collisionBox[i] = new Rectangle(468, 407, 16, 60);
            }


            for (int i = 0; i < active; i++)
                collisionBox[i + startUp] = new Rectangle(529, 402, 16, 68);

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 2)
                    collisionBox[i + startUp + active] = new Rectangle(573, 418, 16, 50);
                else
                    collisionBox[i + startUp + active] = new Rectangle(624, 423, 18, 44);
            }



            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                {
                    hitBox[i] = Rectangle.Empty;
                    guardProcBox[i] = new Rectangle(424, 393, 26, 53);
                }
                else
                {
                    hitBox[i] = Rectangle.Empty;
                    guardProcBox[i] = new Rectangle(485, 375, 20, 53);
                }

            }

            for (int i = 0; i < active; i++)
            {
                hitBox[i + startUp] = new Rectangle(534, 362, 18, 51);
                guardProcBox[i + startUp] = new Rectangle(531, 357, 28, 63);
            }

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 2)
                {
                    hitBox[i + startUp + active] = Rectangle.Empty;
                    guardProcBox[i + startUp + active] = new Rectangle(591, 383, 17, 49);
                }
                else
                {
                    hitBox[i + startUp + active] = Rectangle.Empty;
                    guardProcBox[i + startUp + active] = new Rectangle(632, 398, 27, 46);
                }
            }

            
            
        }
    }
}
