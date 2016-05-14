using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Fight.Animations
{
    class LightTatsuAnim : Animation
    {
        public LightTatsuAnim()
        {
            startUp = MoveList.lightTatsu.startUp;
            active = MoveList.lightTatsu.active;
            recovery = MoveList.lightTatsu.recover;

            isLooping = false;
            timeToUpdate = 1 / 60f;

            animations = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if(i <startUp/2)
                    animations[i] = new Rectangle(950, 500, 43, 126);
                else
                    animations[i] = new Rectangle(997, 490, 41, 124);
            }

            for (int i = 0; i < active; i++)
            {
                if(i<active/4)
                    animations[i + startUp] = new Rectangle(1043, 490, 66, 124);
                else if(i<2*active/4)
                    animations[i + startUp] = new Rectangle(1112, 489, 48, 124);
                else if (i < 3*active / 4)
                    animations[i + startUp] = new Rectangle(1162, 489, 68, 124);
                else
                    animations[i + startUp] = new Rectangle(1232, 489, 45, 125);
            }

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 3)
                    animations[i + startUp + active] = new Rectangle(1282, 489, 46, 124);
                else if (i < 2 * recovery / 3)
                    animations[i + startUp + active] = new Rectangle(1332, 501, 39, 124);
                else
                    animations[i + startUp + active] = new Rectangle(1373, 487, 44, 126);
            }


            hurtBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                    hurtBox[i] = new Rectangle(955, 524, 31, 82);
                else
                    hurtBox[i] = new Rectangle(1005, 495, 29, 60);
            }

            for (int i = 0; i < active; i++)
            {
                if (i < active / 4)
                    hurtBox[i + startUp] = new Rectangle(1055, 494, 45, 57);
                else if (i < 2 * active / 4)
                    hurtBox[i + startUp] = new Rectangle(1120, 491, 36, 61);
                else if (i < 3 * active / 4)
                    hurtBox[i + startUp] = new Rectangle(1163, 492, 52, 56);
                else
                    hurtBox[i + startUp] = new Rectangle(1239, 490, 33, 60);
            }

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 3)
                    hurtBox[i + startUp + active] = new Rectangle(1290, 498, 32, 66);
                else if (i < 2 * recovery / 3)
                    hurtBox[i + startUp + active] = new Rectangle(1336, 534, 27, 77);
                else
                    hurtBox[i + startUp + active] = new Rectangle(1380, 539, 29, 72);
            }


            collisionBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                    collisionBox[i] = new Rectangle(962, 528, 16, 72);
                else
                    collisionBox[i] = new Rectangle(1012, 505, 14, 49);
            }

            for (int i = 0; i < active; i++)
            {
                if (i < active / 4)
                    collisionBox[i + startUp] = new Rectangle(1060, 495, 18, 60);
                else if (i < 2 * active / 4)
                    collisionBox[i + startUp] = new Rectangle(1124, 493, 19, 60);
                else if (i < 3 * active / 4)
                    collisionBox[i + startUp] = new Rectangle(1190, 500, 19, 48);
                else
                    collisionBox[i + startUp] = new Rectangle(1247, 494, 19, 55);
            }

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 3)
                    collisionBox[i + startUp + active] = new Rectangle(1293, 502, 26, 54);
                else if (i < 2 * recovery / 3)
                    collisionBox[i + startUp + active] = new Rectangle(1340, 543, 19, 62);
                else
                    collisionBox[i + startUp + active] = new Rectangle(1387, 548, 13, 62);
            }

            guardProcBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                if (i < startUp / 2)
                    guardProcBox[i] = new Rectangle(971, 537, 43, 34);
                else
                    guardProcBox[i] = new Rectangle(1018, 516, 40, 63);
            }

            for (int i = 0; i < active; i++)
            {
                if (i < active / 4)
                    guardProcBox[i + startUp] = new Rectangle(1071, 504, 46, 69);
                else if (i < 2 * active / 4)
                    guardProcBox[i + startUp] = new Rectangle(1134, 506, 45, 77);
                else if (i < 3 * active / 4)
                    guardProcBox[i + startUp] = new Rectangle(1195, 507, 41, 66);
                else
                    guardProcBox[i + startUp] = new Rectangle(1257, 505, 36, 76);
            }

            for (int i = 0; i < recovery; i++)
            {
                if (i < recovery / 3)
                    guardProcBox[i + startUp + active] = new Rectangle(1308, 511, 29, 65);
                else if (i < 2 * recovery / 3)
                    guardProcBox[i + startUp + active] = new Rectangle(1353, 544, 24, 58);
                else
                    guardProcBox[i + startUp + active] = new Rectangle(1395, 542, 31, 60);
            }


            hitBox = new Rectangle[startUp + active + recovery];
            for (int i = 0; i < startUp; i++)
            {
                hitBox[i] = Rectangle.Empty;
            }

            for (int i = 0; i < active; i++)
            {
                if (i < active / 4)
                    hitBox[i + startUp] = new Rectangle(1066, 524, 44, 20);
                else if (i < 2 * active / 4)
                    hitBox[i + startUp] = Rectangle.Empty;
                else if (i < 3 * active / 4)
                    hitBox[i + startUp] = new Rectangle(1162, 522, 42, 20);
                else
                    hitBox[i + startUp] = Rectangle.Empty;
            }

            for (int i = 0; i < recovery; i++)
            {
                hitBox[i + startUp + active] = Rectangle.Empty;
            }

            

            displacement = new Vector2[startUp + active + recovery];
            for (int i = 0; i < startUp + active + recovery; i++)
                displacement[i] = MoveList.lightTatsu.displacement;


        }
    }
}
