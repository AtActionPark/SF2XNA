using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class JumpingJabAnim : Animation
    {

        public JumpingJabAnim()
        {
            startUp = MoveList.jumpingJab.startUp;
            active = MoveList.jumpingJab.active;
            recovery = MoveList.jumpingJab.recover;

            isLooping = false;
            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp+active+recovery];
            for(int i = 0;i<startUp;i++)
                animations[i] = new Rectangle(380, 541, 36, 72);

            for (int i = 0; i < active; i++)
                animations[i + startUp] = new Rectangle(420, 541, 41, 71);

            for (int i = 0; i < recovery; i++)
                animations[i + startUp + active] = new Rectangle(380, 541, 36, 72);


            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                hurtBox[i] = new Rectangle(383, 546, 29, 65);

            for (int i = 0; i < active; i++)
                hurtBox[i + startUp] = new Rectangle(425, 552, 33, 52);

            for (int i = 0; i < recovery; i++)
                hurtBox[i + startUp + active] = new Rectangle(383, 546, 29, 65);


            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                collisionBox[i] = new Rectangle(388, 555, 20, 55);

            for (int i = 0; i < active; i++)
                collisionBox[i + startUp] = new Rectangle(431, 557, 20, 46);

            for (int i = 0; i < recovery; i++)
                collisionBox[i + startUp + active] = new Rectangle(388, 555, 20, 55);


            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                hitBox[i] = Rectangle.Empty;
                guardProcBox[i] = new Rectangle(401, 558, 26, 50);
            }

            for (int i = 0; i < active; i++)
            {
                hitBox[i + startUp] = new Rectangle(442, 563, 21, 45);
                guardProcBox[i + startUp] = new Rectangle(441, 558, 31, 58);
            }

            for (int i = 0; i < recovery; i++)
            {
                hitBox[i + startUp + active] = Rectangle.Empty;
                guardProcBox[i + startUp + active] = new Rectangle(401, 558, 26, 50);
            }

            
            
        }
    }
}
