using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class GetThrownAnim : Animation
    {
        public GetThrownAnim()
        {
            isLooping = false;
            timeToUpdate = 0.10f;

            animations = new Rectangle[5];
            animations[0] = new Rectangle(0, 986, 49, 96);
            animations[1] = new Rectangle(48, 973, 70, 110);
            animations[2] = new Rectangle(116, 973, 103, 110);
            animations[3] = new Rectangle(218, 973, 125, 110);
            animations[4] = new Rectangle(343, 973, 193, 110);

            hurtBox = new Rectangle[5];
            collisionBox = new Rectangle[5];
            hitBox = new Rectangle[5];
            guardProcBox = new Rectangle[5]; 
        }
    }
}
