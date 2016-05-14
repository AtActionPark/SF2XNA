using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Fight
{
    public static class MessageManager
    {
        public static List<Message> Messages = new List<Message>();

        public static void Update()
        {
            foreach (Message message in Messages)
                message.Update();
            Messages = Messages.Where(x => !x.toRemove).ToList();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (Message message in Messages)
                message.Draw(spriteBatch);
        }
    }
}
