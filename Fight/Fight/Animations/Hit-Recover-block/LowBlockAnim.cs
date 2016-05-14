using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class LowBlockAnim : Animation
    {
        public LowBlockAnim(int blockStun)
        {
            timeToUpdate = 1 / 60f;
            isLooping = false;

            animations = new Rectangle[blockStun];
            for (int i = 0; i < blockStun; i++)
                animations[i] = new Rectangle(1259, 36, 45, 64);

            hurtBox = new Rectangle[blockStun];
            for(int i = 0;i<blockStun;i++)
                hurtBox[i] = new Rectangle(1264, 40, 31, 57);

            collisionBox = new Rectangle[blockStun];
            for (int i = 0; i < blockStun; i++)
                collisionBox[i] = new Rectangle(1272, 54, 21, 43);


            hitBox = new Rectangle[blockStun];
            guardProcBox = new Rectangle[blockStun];

        }
    }
}
