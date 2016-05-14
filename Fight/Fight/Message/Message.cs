using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fight
{
    public class Message
    {
        public string message;
        public Vector2 position;
        public Color color;
        public int time;
        public bool toRemove = false;

        public Message(string message, Vector2 position, Color color, int time)
        {
            this.message = message;
            this.position = position;
            this.color = color;
            this.time = time;

            MessageManager.Messages.Add(this);
        }
        public Message(string message, Vector2 position, Color color, int time, bool remove)
        {
            this.message = message;
            this.position = position;
            this.color = color;
            this.time = time;

            MessageManager.Messages.Clear();
            MessageManager.Messages.Add(this);
        }

        public void Update()
        {
            time--;
            if (time < 0)
                toRemove = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (message != null)
                spriteBatch.DrawString(Art.Font, message, position, color);
        }
    }
}
