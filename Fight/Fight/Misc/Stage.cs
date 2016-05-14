using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Fight
{
    public static class Stage
    {
        static Texture2D textureBase;
        static Texture2D textureAnim;
        public static int position = 0;
        public static int fightersRelativePosition = 0;
        public static int bottom = 460;
        public static bool movingStage = true;
        public static int frame;
        public static int leftLimit;
        public static int rightLimit;

        public static void Load()
        {
            textureBase = Art.StageBase;
            textureAnim = Art.StageAnim1;
            leftLimit = -textureBase.Width / 4;
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureBase, new Vector2(position-textureBase.Width/4,0 ),  Color.White);
            spriteBatch.Draw(textureAnim, new Vector2(position - textureBase.Width / 4, 0), null, Color.White, 0, Vector2.Zero, 2.2f, SpriteEffects.None, 1);
        }

        public static void Update()
        {
            int fr = 10;
            frame++;
            if (frame < fr)
            {
                textureAnim = Art.StageAnim1;
            }
            if (frame > fr)
            {
                textureAnim = Art.StageAnim2;
            }
            if (frame > 2*fr)
            {
                textureAnim = Art.StageAnim3;
            }
            if (frame > 3*fr)
            {
                frame = 0;
            }
        }
    }
}
