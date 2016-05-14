using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class RecoverAnim : Animation
    {
        public RecoverAnim(int frames)
        {
            if (frames == 0)
            {
                frames = 1;
            }

            timeToUpdate = 1 / 60f;
            isLooping = false;

            int div4 = (int)frames / 4;
            int reste = frames - 4 * div4;
           
            animations = new Rectangle[frames];
            for (int i = 0; i < div4; i++)
            animations[i] = new Rectangle(0, 15, 50, 82);
            for (int i = div4; i < 2 * div4; i++)
            animations[i] = new Rectangle(50, 15, 50, 82);
            for (int i = 2 * div4; i < 3 * div4; i++)
            animations[i] = new Rectangle(100, 15, 50, 82);
            for (int i = 3 * div4; i < 4 * div4 + reste; i++)
            animations[i] = new Rectangle(150, 15, 50, 82);

            hurtBox = new Rectangle[frames];
            for (int i = 0; i < div4; i++)
            hurtBox[i] = new Rectangle(5, 15, 35, 82);
            for (int i = div4; i < 2 * div4; i++)
            hurtBox[i] = new Rectangle(55, 15, 35, 82);
            for (int i = 2 * div4; i < 3 * div4; i++)
            hurtBox[i] = new Rectangle(105, 15, 35, 82);
            for (int i = 3 * div4; i < 4 * div4 + reste; i++)
            hurtBox[i] = new Rectangle(155, 15, 35, 82);

            collisionBox = new Rectangle[frames];
            for (int i = 0; i < div4; i++)
            collisionBox[i] = new Rectangle(10, 30, 25, 65);
            for (int i = div4; i < 2 * div4; i++)
            collisionBox[i] = new Rectangle(60, 30, 25, 65);
            for (int i = 2 * div4; i < 3 * div4; i++)
            collisionBox[i] = new Rectangle(110, 30, 25, 65);
            for (int i = 3 * div4; i < 4 * div4 + reste; i++)
            collisionBox[i] = new Rectangle(160, 30, 25, 65);

            hitBox = new Rectangle[frames];
            guardProcBox = new Rectangle[frames];
        }
    }
}
