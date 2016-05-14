using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class MovingHadoAnim : Animation
    {
        public MovingHadoAnim()
        {
            isLooping = true;
            timeToUpdate = 0.05f;

            animations = new Rectangle[6];
            animations[0] = new Rectangle(464, 645, 34, 24);
            animations[1] = new Rectangle(551, 645, 33, 24);
            animations[2] = new Rectangle(621, 645, 36, 24);
            animations[3] = new Rectangle(484, 682, 36, 24);
            animations[4] = new Rectangle(558, 682, 33, 24);
            animations[5] = new Rectangle(620, 682, 33, 24);

            hurtBox = new Rectangle[6];
            hurtBox[0] = new Rectangle(464, 645, 34, 24);
            hurtBox[1] = new Rectangle(551, 645, 33, 24);
            hurtBox[2] = new Rectangle(621, 645, 36, 24);
            hurtBox[3] = new Rectangle(484, 682, 36, 24);
            hurtBox[4] = new Rectangle(558, 682, 33, 24);
            hurtBox[5] = new Rectangle(620, 682, 33, 24);

            collisionBox = new Rectangle[6];

            hitBox = new Rectangle[6];
            hitBox[0] = new Rectangle(464, 645, 34, 24);
            hitBox[1] = new Rectangle(551, 645, 33, 24);
            hitBox[2] = new Rectangle(621, 645, 36, 24);
            hitBox[3] = new Rectangle(484, 682, 36, 24);
            hitBox[4] = new Rectangle(558, 682, 33, 24);
            hitBox[5] = new Rectangle(620, 682, 33, 24);

            guardProcBox = new Rectangle[6];
            guardProcBox[0] = new Rectangle(464, 645, 54, 24);
            guardProcBox[1] = new Rectangle(551, 645, 53, 24);
            guardProcBox[2] = new Rectangle(621, 645, 56, 24);
            guardProcBox[3] = new Rectangle(484, 682, 56, 24);
            guardProcBox[4] = new Rectangle(558, 682, 53, 24);
            guardProcBox[5] = new Rectangle(620, 682, 53, 24);
        }
    }
}
