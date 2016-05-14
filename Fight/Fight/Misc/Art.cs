using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Fight
{
    public static class Art
    {
        public static Texture2D StageBase;
        public static Texture2D StageAnim1;
        public static Texture2D StageAnim2;
        public static Texture2D StageAnim3;
        public static Texture2D WhitePixel;
        public static Texture2D FontSheet;
        public static Texture2D Ryu;
        public static Texture2D VSLogo;
        public static string teststring;
        public static SpriteFont Font;

        public static void Load(ContentManager Content)
        {
            StageBase = Content.Load<Texture2D>("Stage/stageBase");
            StageAnim1 = Content.Load<Texture2D>("Stage/stageAnim1");
            StageAnim2 = Content.Load<Texture2D>("Stage/stageAnim2");
            StageAnim3 = Content.Load<Texture2D>("Stage/stageAnim3");
            WhitePixel = Content.Load<Texture2D>("Misc/WhitePixel");
            FontSheet = Content.Load<Texture2D>("Misc/FontSheet");
            Ryu = Content.Load<Texture2D>("SpriteSheet/Ryu2");
            VSLogo = Content.Load<Texture2D>("Misc/VSLogo");
            Font = Content.Load<SpriteFont>("Font/SpriteFont1");
        }
    }
}
