using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class JumpingForwardAnim : Animation
    {

        public JumpingForwardAnim()
        {
            startUp = MoveList.jumpingForward.startUp;
            active = MoveList.jumpingForward.active;
            recovery = MoveList.jumpingForward.recover;

            isLooping = false;
            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp+active+recovery];
            for(int i = 0;i<startUp;i++)
                animations[i] = new Rectangle(465, 547, 41, 67);

            for (int i = 0; i < active; i++)
                animations[i + startUp] = new Rectangle(510, 547, 64, 67);

            for (int i = 0; i < recovery; i++)
                animations[i + startUp + active] = new Rectangle(576, 547, 39, 67);


            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                hurtBox[i] = new Rectangle(472, 550, 32, 60);

            for (int i = 0; i < active; i++)
                hurtBox[i + startUp] = new Rectangle(513, 551, 51, 53);

            for (int i = 0; i < recovery; i++)
                hurtBox[i + startUp + active] = new Rectangle(579, 549, 31, 61);


            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                collisionBox[i] = new Rectangle(474, 552, 23, 52);

            for (int i = 0; i < active; i++)
                collisionBox[i + startUp] = new Rectangle(517, 556, 26, 50);

            for (int i = 0; i < recovery; i++)
                collisionBox[i + startUp + active] = new Rectangle(582, 549, 21, 57);


            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                hitBox[i] = Rectangle.Empty;
                guardProcBox[i] = new Rectangle(491, 577, 23, 26);
            }

            for (int i = 0; i < active; i++)
            {
                hitBox[i+startUp] = new Rectangle(528, 570, 45, 36);
                guardProcBox[i + startUp] = new Rectangle(531, 576, 54, 32);
            }

            for (int i = 0; i < recovery; i++)
            {
                hitBox[i + startUp + active] = Rectangle.Empty;
                guardProcBox[i + startUp + active] = new Rectangle(593, 578, 28, 38);
            }

            
            
        }
    }
}
