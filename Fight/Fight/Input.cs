using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Fight
{
    public static class Input
    {
        static KeyboardState keyboardState, oldState;
        static GamePadState gamePadState1, oldGamePadState1;
        static GamePadState gamePadState2, oldGamePadState2;

        public static void Update()
        {
            oldState = keyboardState;
            oldGamePadState1 = gamePadState1;
            oldGamePadState2 = gamePadState2;

            keyboardState = Keyboard.GetState();
            gamePadState1 = GamePad.GetState(PlayerIndex.One);
            gamePadState2 = GamePad.GetState(PlayerIndex.Two);
        }

        public static bool IsKeyDown(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }

        public static bool WasKeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key) && !oldState.IsKeyDown(key);
        }

        public static bool NoPressedKey()
        {
            return keyboardState.GetPressedKeys().Length == 0;
        }


        public static bool IsButtonDown(Buttons button, PlayerIndex playerIndex)
        {
            if(playerIndex == PlayerIndex.One)
                return gamePadState1.IsButtonDown(button);
            else
                return gamePadState2.IsButtonDown(button);
        }

        public static bool WasButtonPressed(Buttons button, PlayerIndex playerIndex)
        {
            if(playerIndex == PlayerIndex.One)
                return gamePadState1.IsButtonDown(button) && !oldGamePadState1.IsButtonDown(button);
            else
                return gamePadState2.IsButtonDown(button) && !oldGamePadState2.IsButtonDown(button);
        }

        public static bool NoPressedButtons()
        {
            return keyboardState.GetPressedKeys().Length == 0;
        }
    }
}
