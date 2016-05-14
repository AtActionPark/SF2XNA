using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class CloseStandingShortAnim : Animation
    {
        public CloseStandingShortAnim()
        {
            startUp = MoveList.closeStandingShort.startUp;
            active = MoveList.closeStandingShort.active;
            recovery = MoveList.closeStandingShort.recover;

            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp+active+recovery];
            for (int i = 0; i < startUp; i++)
            {
                animations[i] = new Rectangle(496, 262, 54, 82);
            }

            for (int i = 0; i < active; i++)
            {
                animations[i + startUp] = new Rectangle(549, 262, 78, 82);
            }


            for (int i = 0; i < recovery; i++)
            {
                animations[i + startUp + active] = new Rectangle(626, 262, 52, 82);
            }
                


            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                hurtBox[i] = new Rectangle(512, 262, 30, 82);

            for (int i = 0; i < active; i++)
                hurtBox[i + startUp] = new Rectangle(573, 262, 36, 82);

            for (int i = 0; i < recovery; i++)
                hurtBox[i + startUp + active] = new Rectangle(646, 262, 28, 82);


            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                collisionBox[i] = new Rectangle(518, 279, 19, 65);

            for (int i = 0; i < active; i++)
                collisionBox[i + startUp] = new Rectangle(579, 279, 19, 65);

            for (int i = 0; i < recovery; i++)
                collisionBox[i + startUp + active] = new Rectangle(650, 279, 19, 65);


            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                hitBox[i] = Rectangle.Empty;
                guardProcBox[i] = new Rectangle(517, 296, 85, 15);
            }

            for (int i = 0; i < active; i++)
            {
                hitBox[i + startUp] = new Rectangle(592, 292, 30, 31);
                guardProcBox[i+startUp] = new Rectangle(582, 296, 85, 15);
            }

            for (int i = 0; i < recovery; i++)
            {
                hitBox[i + startUp + active] = Rectangle.Empty;
                guardProcBox[i + startUp + active] = Rectangle.Empty;
            }

            isLooping = false;
        }
    }
}
