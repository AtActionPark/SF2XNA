using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;




namespace Fight
{
    public static class Static
    {
        public static bool pause = true;
        public static bool freeze = true;
        public static bool activateIA = true;
        public static int pauseCountdown = 0;
        public static int freezeCountdown = 0;
        public static Vector2 Size = new Vector2(800, 480);
        

        public static void Update()
        {
            if (pauseCountdown > 0)
            {
                pause = true;
                pauseCountdown--;
            }
                
            if(pauseCountdown<=0)
                pause = false;

            if (freezeCountdown > 0)
            {
                freeze = true;
                freezeCountdown--;
            }

            if (freezeCountdown <= 0)
                freeze = false;

            if (Input.WasKeyPressed(Keys.T))
                activateIA = !activateIA;
        }
    }

}
