using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class MediumShoryuAnim : Animation
    {
        public MediumShoryuAnim()
        {
            startUp = MoveList.mediumShoryu.startUp;
            active = MoveList.mediumShoryu.active;
            recovery = MoveList.mediumShoryu.recover;

            isLooping = false;
            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp + active + recovery];
            animations[0] = new Rectangle(622, 557, 45, 57);
            animations[1] = new Rectangle(673, 540, 45, 73);
            animations[2] = new Rectangle(673, 540, 45, 73);
            animations[3] = new Rectangle(723, 530, 51, 83);

            for (int i = 1; i < active; i++)
            {
                animations[i + startUp] = new Rectangle(778, 503, 41, 111);
            }

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 3)
                    animations[i + startUp + active] = new Rectangle(822, 503, 34, 112);
                else if (i < 2 * recovery / 3)
                    animations[i + startUp + active] = new Rectangle(859, 504, 34, 112);
                else
                    animations[i + startUp + active] = new Rectangle(897, 503, 46, 111);
            }

            hurtBox = new Rectangle[startUp + active + recovery];

            //invul frames 1-4
            //hurtBox[0] = new Rectangle(631, 561, 32, 49);
            //hurtBox[1] = new Rectangle(683, 546, 31, 63);
            //hurtBox[2] = new Rectangle(683, 546, 31, 63);
            //hurtBox[3] = new Rectangle(738, 541, 30, 69);

            for (int i = 2; i < active; i++)
            {
                hurtBox[i + startUp] = new Rectangle(783, 527, 30, 80);
            }

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 3)
                    hurtBox[i + startUp + active] = new Rectangle(829, 530, 25, 82);
                else if (i < 2 * recovery / 3)
                    hurtBox[i + startUp + active] = new Rectangle(860, 527, 31, 84);
                else
                    hurtBox[i + startUp + active] = new Rectangle(900, 532, 35, 73);
            }

            collisionBox = new Rectangle[startUp + active + recovery];
            collisionBox[0] = new Rectangle(638, 567, 18, 44);
            collisionBox[1] = new Rectangle(690, 553, 19, 54);
            collisionBox[2] = new Rectangle(690, 553, 19, 54);
            collisionBox[3] = new Rectangle(743, 547, 17, 63);

            for (int i = 1; i < active; i++)
            {
                collisionBox[i + startUp] = new Rectangle(791, 534, 17, 69);
            }

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 3)
                    collisionBox[i + startUp + active] = new Rectangle(832, 537, 18, 66);
                else if (i < 2 * recovery / 3)
                    collisionBox[i + startUp + active] = new Rectangle(865, 535, 17, 65);
                else
                    collisionBox[i + startUp + active] = new Rectangle(905, 543, 21, 64);
            }

            hitBox = new Rectangle[startUp + active + recovery];
            guardProcBox = new Rectangle[startUp + active + recovery];
            {
                guardProcBox[0] = new Rectangle(651, 565, 30, 28);
                guardProcBox[1] = new Rectangle(698, 548, 39, 34);
                guardProcBox[2] = new Rectangle(698, 548, 39, 34);
                guardProcBox[3] = new Rectangle(759, 552, 39, 33);
                hitBox[3] = new Rectangle(761, 535, 14, 49);
            }

            for (int i = 1; i < active; i++)
            {
                guardProcBox[i + startUp] = new Rectangle(801, 515, 31, 53);
                hitBox[i + startUp] = new Rectangle(796, 504, 19, 56);
            }

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 3)
                    guardProcBox[i + startUp + active] = new Rectangle(840, 522, 26, 47);
                else if (i < 2 * recovery / 3)
                    guardProcBox[i + startUp + active] = new Rectangle(872, 519, 32, 46);
                else
                    guardProcBox[i + startUp + active] = new Rectangle(919, 524, 29, 46);
            }

            displacement = new Vector2[startUp + active + recovery];
            for (int i = 0; i < startUp + active + recovery; i++)
                displacement[i] = Vector2.Zero;

            displacement[5] = MoveList.mediumShoryu.displacement;


        }
    }
}
