using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class AirHitAnim : Animation
    {
        public AirHitAnim(int HitStun)
        {


            timeToUpdate = 1 / 60f;
            isLooping = false;

            animations = new Rectangle[HitStun];
            for (int i = 0; i < HitStun; i++)
                animations[i] = new Rectangle(507, 758, 56, 79);



            hurtBox = new Rectangle[HitStun];
            for (int i = 0; i < HitStun; i++)
                hurtBox[i] = Rectangle.Empty;



            collisionBox = new Rectangle[HitStun];
            for (int i = 0; i < HitStun; i++)
                collisionBox[i] = new Rectangle(513, 769, 44, 62);



            hitBox = new Rectangle[HitStun];
            guardProcBox = new Rectangle[HitStun];
        }
    }
}
