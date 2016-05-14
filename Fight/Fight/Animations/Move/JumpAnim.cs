using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class JumpAnim : Animation
    {
        public JumpAnim()
        {
            isLooping = false;
            timeToUpdate = 0.15f;

            animations = new Rectangle[5];

            animations[0] = new Rectangle(501, 8, 37, 92);
            animations[1] = new Rectangle(544, 17, 31, 81);
            animations[2] = new Rectangle(581, 17, 33, 81);
            animations[3] = new Rectangle(618, 17, 31, 81);
            animations[4] = new Rectangle(656, 8, 34, 92);

            hurtBox = new Rectangle[5];

            hurtBox[0] = new Rectangle(505, 21, 29, 70);
            hurtBox[1] = new Rectangle(545, 25, 28, 68);
            hurtBox[2] = new Rectangle(583, 20, 28, 63);
            hurtBox[3] = new Rectangle(620, 27, 27, 66);
            hurtBox[4] = new Rectangle(657, 22, 29, 71);

            collisionBox = new Rectangle[5];

            collisionBox[0] = new Rectangle(509, 36, 25, 53);
            collisionBox[1] = new Rectangle(548, 37, 25, 53);
            collisionBox[2] = new Rectangle(586, 37, 25, 53);
            collisionBox[3] = new Rectangle(623, 35, 25, 53);
            collisionBox[4] = new Rectangle(661, 35, 25, 53);


            hitBox = new Rectangle[5];
            guardProcBox = new Rectangle[5];
        }
    }
}
