using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class WalkAnim : Animation
    {
        public WalkAnim()
        {
            timeToUpdate = 0.1f;
            isLooping = true;

            animations = new Rectangle[5];
            animations[0] = new Rectangle(203, 18, 47, 79);
            animations[1] = new Rectangle(250, 18, 47, 79);
            animations[2] = new Rectangle(299, 18, 47, 79);
            animations[3] = new Rectangle(349, 18, 47, 79);
            animations[4] = new Rectangle(399, 18, 47, 79);

            hurtBox = new Rectangle[5];
            hurtBox[0] = new Rectangle(211, 24, 31, 73);
            hurtBox[1] = new Rectangle(254, 20, 34, 77);
            hurtBox[2] = new Rectangle(306, 18, 33, 79);
            hurtBox[3] = new Rectangle(359, 18, 27, 79);
            hurtBox[4] = new Rectangle(407, 18, 30, 79);

            collisionBox = new Rectangle[5];
            collisionBox[0] = new Rectangle(216, 32, 21, 65);
            collisionBox[1] = new Rectangle(261, 32, 21, 65);
            collisionBox[2] = new Rectangle(312, 32, 21, 65);
            collisionBox[3] = new Rectangle(362, 32, 21, 65);
            collisionBox[4] = new Rectangle(411, 32, 21, 65);

            hitBox = new Rectangle[5];
            guardProcBox = new Rectangle[5];
        }
    }
}
