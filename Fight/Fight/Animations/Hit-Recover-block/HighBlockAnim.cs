using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class HighBlockAnim : Animation
    {
        public HighBlockAnim(int blockStun)
        {
            timeToUpdate = 1 / 60f;
            isLooping = false;

            animations = new Rectangle[blockStun];
            for (int i = 0; i < blockStun; i++)
                animations[i] = new Rectangle(1210, 15, 45, 85);

            hurtBox = new Rectangle[blockStun];
            for(int i = 0;i<blockStun;i++)
                hurtBox[i] = new Rectangle(1217, 20, 28, 77);

            collisionBox = new Rectangle[blockStun];
            for (int i = 0; i < blockStun; i++)
                collisionBox[i] = new Rectangle(1223, 31, 21, 66);


            hitBox = new Rectangle[blockStun];
            guardProcBox = new Rectangle[blockStun];

        }
    }
}
