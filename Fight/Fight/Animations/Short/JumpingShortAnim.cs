using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class JumpingShortAnim : Animation
    {

        public JumpingShortAnim()
        {
            startUp = MoveList.jumpingShort.startUp;
            active = MoveList.jumpingShort.active;
            recovery = MoveList.jumpingShort.recover;

            isLooping = false;
            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp+active+recovery];
            for(int i = 0;i<startUp;i++)
                animations[i] = new Rectangle(199, 532, 35, 83);

            for (int i = 0; i < active; i++)
                animations[i + startUp] = new Rectangle(147, 529, 47, 86);

            for (int i = 0; i < recovery; i++)
                animations[i + startUp + active] = new Rectangle(199, 532, 35, 83);


            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                hurtBox[i] = new Rectangle(204, 539, 25, 64);

            for (int i = 0; i < active; i++)
                hurtBox[i + startUp] = new Rectangle(152, 533, 36, 72);

            for (int i = 0; i < recovery; i++)
                hurtBox[i + startUp + active] = new Rectangle(204, 539, 25, 64);


            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                collisionBox[i] = new Rectangle(208, 548, 15, 49);

            for (int i = 0; i < active; i++)
                collisionBox[i + startUp] = new Rectangle(155, 540, 21, 66);

            for (int i = 0; i < recovery; i++)
                collisionBox[i + startUp + active] = new Rectangle(208, 548, 15, 49);



            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                hitBox[i] = Rectangle.Empty;
                guardProcBox[i] = new Rectangle(217, 539, 20, 47);
            }

            for (int i = 0; i < active; i++)
            {
                hitBox[i + startUp] = new Rectangle(167, 530, 27, 50);
                guardProcBox[i + startUp] = new Rectangle(168, 530, 32, 40);
            }

            for (int i = 0; i < recovery; i++)
            {
                hitBox[i + startUp + active] = Rectangle.Empty;
                guardProcBox[i + startUp + active] = new Rectangle(217, 539, 20, 47);
            }

            
            
        }
    }
}
