using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class HitAnim : Animation
    {
        public HitAnim(int HitStun)
        {
            if (HitStun == 0)
                HitStun = 1;
            int div4 = (int)HitStun / 4;
            int reste;
            if (HitStun % 4 != 0)
                reste = HitStun - 4 * div4;
            else
                reste = 0;

            timeToUpdate = 1 / 60f;
            isLooping = false;

            animations = new Rectangle[HitStun];
            for (int i = 0; i < div4; i++)
                animations[i] = new Rectangle(3, 755, 46, 81);
            for (int i = div4; i < 2*div4; i++)
                animations[i] = new Rectangle(53, 756, 48, 80);
            for (int i = 2 * div4; i < 3*div4; i++)
                animations[i] = new Rectangle(105, 756, 51, 79);
            for (int i = 3 * div4; i < 4 * div4 + reste; i++)
                animations[i] = new Rectangle(160, 751, 47, 85);


            hurtBox = new Rectangle[HitStun];
            for (int i = 0; i < div4; i++)
                hurtBox[i] = new Rectangle(7, 765, 34, 66);
            for (int i = div4; i < 2 * div4; i++)
                hurtBox[i] = new Rectangle(57, 764, 33, 67);
            for (int i = 2 * div4; i < 3 * div4; i++)
                hurtBox[i] = new Rectangle(111, 764, 32, 71);
            for (int i = 3 * div4; i < 4 * div4 + reste; i++)
                hurtBox[i] = new Rectangle(164, 755, 34, 79);


            collisionBox = new Rectangle[HitStun];
            for (int i = 0; i < div4; i++)
                collisionBox[i] = new Rectangle(12, 776, 20, 58);
            for (int i = div4; i < 2 * div4; i++)
                collisionBox[i] = new Rectangle(62, 776, 17, 59);
            for (int i = 2 * div4; i < 3 * div4; i++)
                collisionBox[i] = new Rectangle(114, 778, 19, 55);
            for (int i = 3 * div4; i < 4 * div4 + reste; i++)
                collisionBox[i] = new Rectangle(171, 769, 19, 62);


            hitBox = new Rectangle[HitStun];
            guardProcBox = new Rectangle[HitStun];
        }
    }
}
