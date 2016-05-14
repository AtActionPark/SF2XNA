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
        static Texture2D texture;
        public static int position = 0;
        public static int fightersRelativePosition = 0;
        public static int bottom = 460;
        public static bool movingStage = false;

        public static void Load()
        {
            texture = Art.Stage1;
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(position-texture.Width/4,0 ), Color.White);
        }
    }
}
