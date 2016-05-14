using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class KnockedDownAnim : Animation
    {
        public KnockedDownAnim()
        {
            timeToUpdate = 0.1f;
            isLooping = false;

            animations = new Rectangle[4];
            animations[0] = new Rectangle(507, 758, 56, 79);
            animations[1] = new Rectangle(561, 758, 54, 79);
            animations[2] = new Rectangle(614, 758, 79, 79);
            animations[3] = new Rectangle(692, 758, 80, 79);

            hurtBox = new Rectangle[4];
            hurtBox[0] = new Rectangle(515, 770, 44, 60);
            hurtBox[1] = new Rectangle(571, 762, 40, 71);
            hurtBox[2] = new Rectangle(617, 790, 74, 35);
            hurtBox[3] = new Rectangle(700, 807, 60, 26);

            collisionBox = new Rectangle[4];
            collisionBox[0] = new Rectangle(513, 769, 44, 62);
            collisionBox[1] = new Rectangle(568, 766, 44, 68);
            collisionBox[2] = new Rectangle(622, 794, 55, 36);
            collisionBox[3] = new Rectangle(707, 806, 48, 26);

            hitBox = new Rectangle[4];
            guardProcBox = new Rectangle[4];

        }
    }
}
