using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class NeutralJumpingFierceAnim : Animation
    {

        public NeutralJumpingFierceAnim()
        {
            startUp = MoveList.neutralJumpingFierce.startUp;
            active = MoveList.neutralJumpingFierce.active;
            recovery = MoveList.neutralJumpingFierce.recover;

            isLooping = false;
            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp+active+recovery];
            for(int i = 0;i<startUp;i++)
                animations[i] = new Rectangle(7, 544, 41, 69);

            for (int i = 0; i < active; i++)
                animations[i + startUp] = new Rectangle(52, 544, 52, 68);

            for (int i = 0; i < recovery; i++)
                animations[i + startUp + active] = new Rectangle(108, 544, 34, 69);


            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                hurtBox[i] = new Rectangle(13, 548, 32, 62);

            for (int i = 0; i < active; i++)
                hurtBox[i + startUp] = new Rectangle(56, 550, 36, 55);

            for (int i = 0; i < recovery; i++)
                hurtBox[i + startUp + active] = new Rectangle(110, 546, 27, 64);


            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                collisionBox[i] = new Rectangle(17, 553, 22, 48);

            for (int i = 0; i < active; i++)
                collisionBox[i + startUp] = new Rectangle(59, 559, 20, 45);

            for (int i = 0; i < recovery; i++)
                collisionBox[i + startUp + active] = new Rectangle(114, 556, 16, 49);


            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                hitBox[i] = Rectangle.Empty;
                guardProcBox[i] = new Rectangle(29, 564, 42, 19);
            }

            for (int i = 0; i < active; i++)
            {
                hitBox[i + startUp] = new Rectangle(77, 567, 27, 23);
                guardProcBox[i + startUp] = new Rectangle(72, 561, 42, 33);
            }

            for (int i = 0; i < recovery; i++)
            {
                hitBox[i + startUp + active] = Rectangle.Empty;
                guardProcBox[i + startUp + active] = new Rectangle(124, 563, 29, 29);
            }

            
            
        }
    }
}
