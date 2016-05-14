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
        public static Texture2D Stage1;
        public static Texture2D WhitePixel;
        public static Texture2D FontSheet;
        public static Texture2D Ryu;
        public static Texture2D VSLogo;
        public static string teststring;

        public static void Load(ContentManager Content)
        {
            Stage1 = Content.Load<Texture2D>("animatedStage");
            WhitePixel = Content.Load<Texture2D>("WhitePixel");
            FontSheet = Content.Load<Texture2D>("FontSheet");
            Ryu = Content.Load<Texture2D>("Ryu2");
            VSLogo = Content.Load<Texture2D>("VSLogo");
        }
    }
}
