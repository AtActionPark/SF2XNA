using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class FaceHitAnim : Animation
    {
        public FaceHitAnim(int HitStun)
        {
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
                animations[i] = new Rectangle(215, 752, 52, 82);
            for (int i = div4; i < 2*div4; i++)
                animations[i] = new Rectangle(270, 752, 55, 82);
            for (int i = 2 * div4; i < 3*div4; i++)
                animations[i] = new Rectangle(326, 752, 62, 82);
            for (int i = 3 * div4; i < 4 * div4 + reste; i++)
                animations[i] = new Rectangle(391, 752, 45, 82);


            hurtBox = new Rectangle[HitStun];
            for (int i = 0; i < div4; i++)
                hurtBox[i] = new Rectangle(218, 761, 30, 72);
            for (int i = div4; i < 2 * div4; i++)
                hurtBox[i] = new Rectangle(274, 759, 30, 76);
            for (int i = 2 * div4; i < 3 * div4; i++)
                hurtBox[i] = new Rectangle(328, 758, 33,76);
            for (int i = 3 * div4; i < 4 * div4 + reste; i++)
                hurtBox[i] = new Rectangle(393, 759, 30, 76);


            collisionBox = new Rectangle[HitStun];
            for (int i = 0; i < div4; i++)
                collisionBox[i] = new Rectangle(224, 777, 21, 56);
            for (int i = div4; i < 2 * div4; i++)
                collisionBox[i] = new Rectangle(281, 777, 21, 56);
            for (int i = 2 * div4; i < 3 * div4; i++)
                collisionBox[i] = new Rectangle(338, 777, 21, 56);
            for (int i = 3 * div4; i < 4 * div4 + reste; i++)
                collisionBox[i] = new Rectangle(399, 777, 21, 56);


            hitBox = new Rectangle[HitStun];
            guardProcBox = new Rectangle[HitStun];
        }
    }
}
