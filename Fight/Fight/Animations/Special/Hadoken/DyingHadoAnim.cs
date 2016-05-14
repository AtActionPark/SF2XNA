using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class DyingHadoAnim : Animation
    {
        public DyingHadoAnim()
        {
            isLooping = false;
            timeToUpdate = 0.05f;

            animations = new Rectangle[4];
            animations[0] = new Rectangle(700, 636, 24, 58);
            animations[1] = new Rectangle(732, 636, 24, 58);
            animations[2] = new Rectangle(759, 636, 34, 59);
            animations[3] = new Rectangle(798, 637, 44, 58);

            hurtBox = new Rectangle[6];
            hurtBox[0] = new Rectangle(700, 636, 24, 58);
            hurtBox[1] = new Rectangle(732, 636, 24, 58);
            hurtBox[2] = new Rectangle(759, 636, 34, 59);
            hurtBox[3] = new Rectangle(798, 637, 44, 58);

            collisionBox = new Rectangle[6];

            hitBox = new Rectangle[6];
            hitBox[0] = new Rectangle(700, 636, 24, 58);
            hitBox[1] = new Rectangle(732, 636, 24, 58);
            hitBox[2] = new Rectangle(759, 636, 34, 59);
            hitBox[3] = new Rectangle(798, 637, 44, 58);

            guardProcBox = new Rectangle[6];
            guardProcBox[0] = new Rectangle(700, 636, 24, 58);
            guardProcBox[1] = new Rectangle(732, 636, 24, 58);
            guardProcBox[2] = new Rectangle(759, 636, 34, 59);
            guardProcBox[3] = new Rectangle(798, 637, 44, 58);
        }
    }
}
