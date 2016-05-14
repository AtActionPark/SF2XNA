using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class NeutralJumpingRoundhouseAnim : Animation
    {

        public NeutralJumpingRoundhouseAnim()
        {
            startUp = MoveList.neutralJumpingRoundhouse.startUp;
            active = MoveList.neutralJumpingRoundhouse.active;
            recovery = MoveList.neutralJumpingRoundhouse.recover;

            isLooping = false;
            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp+active+recovery];
            for(int i = 0;i<startUp;i++)
                animations[i] = new Rectangle(243, 529, 37, 84);

            for (int i = 0; i < active; i++)
                animations[i + startUp] = new Rectangle(284, 524, 53, 89);

            for (int i = 0; i < recovery; i++)
                animations[i + startUp + active] = new Rectangle(340, 523, 38, 90);

            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                hurtBox[i] = new Rectangle(248, 538, 27, 65);

            for (int i = 0; i < active; i++)
                hurtBox[i + startUp] = new Rectangle(289, 531, 35, 73);

            for (int i = 0; i < recovery; i++)
                hurtBox[i + startUp + active] = new Rectangle(343, 532, 25, 75);


            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
                collisionBox[i] = new Rectangle(252, 549, 15, 57);

            for (int i = 0; i < active; i++)
                collisionBox[i + startUp] = new Rectangle(290, 540, 15, 67);

            for (int i = 0; i < recovery; i++)
                collisionBox[i + startUp + active] = new Rectangle(346, 541, 16, 59);


            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                hitBox[i] = Rectangle.Empty;
                guardProcBox[i] = new Rectangle(260, 553, 38, 28);
            }

            for (int i = 0; i < active; i++)
            {
                hitBox[i] = new Rectangle(290, 552, 48, 24);
                guardProcBox[i + startUp] = new Rectangle(299, 550, 59, 28);
            }

            for (int i = 0; i < recovery; i++)
            {
                hitBox[i + startUp + active] = Rectangle.Empty;
                guardProcBox[i + startUp + active] = new Rectangle(349, 546, 40, 34);
            }

            
            
        }
    }
}
