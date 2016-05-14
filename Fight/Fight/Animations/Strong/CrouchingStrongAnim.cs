using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class CrouchingStrongAnim : Animation
    {
        public CrouchingStrongAnim()
        {
            startUp = MoveList.crouchingStrong.startUp;
            active = MoveList.crouchingStrong.active;
            recovery = MoveList.crouchingStrong.recover;

            isLooping = false;
            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp+active+recovery];
            for(int i = 0;i<startUp;i++)
                animations[i] = new Rectangle(179, 418, 48, 56);

            for (int i = 0; i < active; i++)
                animations[i + startUp] = new Rectangle(230, 416, 63, 57);

            for (int i = 0; i < recovery; i++)
            {
                if(i<recovery/2)
                    animations[i + startUp + active] = new Rectangle(295, 418, 49, 55);
                else
                    animations[i + startUp + active] = new Rectangle(347, 417, 46, 57);
            }


            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                hurtBox[i] = new Rectangle(193, 424, 30, 47);

            for (int i = 0; i < active; i++)
                hurtBox[i + startUp] = new Rectangle(247, 421, 36, 47);

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 2)
                    hurtBox[i + startUp + active] = new Rectangle(308, 424, 31, 46);
                else
                    hurtBox[i + startUp + active] = new Rectangle(358, 421, 30, 49);
            }


            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                collisionBox[i] = new Rectangle(199, 431, 17, 40);

            for (int i = 0; i < active; i++)
                collisionBox[i + startUp] = new Rectangle(250, 428, 15, 37);

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 2)
                    collisionBox[i + startUp + active] = new Rectangle(314, 429, 18, 43);
                else
                    collisionBox[i + startUp + active] = new Rectangle(364, 428, 18, 44);
            }


            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                hitBox[i] = Rectangle.Empty;
                guardProcBox[i] = new Rectangle(210, 426, 36, 14);
            }

            for (int i = 0; i < active; i++)
            {
                hitBox[i + startUp] = new Rectangle(259, 421, 34, 20);
                guardProcBox[i + startUp] = new Rectangle(254, 417, 56, 25);
            }

            for (int i = 0; i < recovery; i++)
            {
                hitBox[i + startUp + active] = Rectangle.Empty;
                if(i<recovery/2)
                    guardProcBox[i + startUp + active] = new Rectangle(322, 420, 44, 20);
                else
                    guardProcBox[i + startUp + active] = new Rectangle(378, 422, 47, 18);
            }

            
            
        }
    }
}
