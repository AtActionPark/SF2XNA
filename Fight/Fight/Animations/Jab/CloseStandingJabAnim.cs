using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class CloseStandingJabAnim : Animation
    {

        public CloseStandingJabAnim()
        {
            startUp = MoveList.closeStandingJab.startUp;
            active = MoveList.closeStandingJab.active;
            recovery = MoveList.closeStandingJab.recover;

            isLooping = false;
            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp+active+recovery];
            for(int i = 0;i<startUp;i++)
                animations[i] = new Rectangle(464, 133, 44, 82);

            for (int i = 0; i < active; i++)
                animations[i + startUp] = new Rectangle(512, 127, 47, 88);

            for (int i = 0; i < recovery; i++)
                animations[i + startUp + active] = new Rectangle(563, 133, 45, 82);


            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                hurtBox[i] = new Rectangle(469, 136, 29, 75);

            for (int i = 0; i < active; i++)
                hurtBox[i + startUp] = new Rectangle(527, 131, 28, 81);

            for (int i = 0; i < recovery; i++)
                hurtBox[i + startUp + active] = new Rectangle(572, 138, 29, 75);


            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                collisionBox[i] = new Rectangle(473, 142, 18, 70);

            for (int i = 0; i < active; i++)
                collisionBox[i + startUp] = new Rectangle(531, 140, 17, 71);

            for (int i = 0; i < recovery; i++)
                collisionBox[i + startUp + active] = new Rectangle(577, 144, 17, 66);


            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                hitBox[i] = Rectangle.Empty;
                guardProcBox[i] = new Rectangle(491, 135, 23, 34);
            }

            for (int i = 0; i < active; i++)
            {
                hitBox[i + startUp] = new Rectangle(539, 123, 22, 39);
                guardProcBox[i + startUp] = new Rectangle(538, 121, 32, 45);
            }

            for (int i = 0; i < recovery; i++)
            {
                hitBox[i + startUp + active] = Rectangle.Empty;
                guardProcBox[i + startUp + active] = new Rectangle(586, 130, 30, 47);
            }

            
            
        }
    }
}
