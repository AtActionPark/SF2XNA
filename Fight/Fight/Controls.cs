using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Fight
{
    class Controls
    {
        Keys leftK;
        Keys rightK;
        Keys downK;
        Keys upK;
        Keys lpunchK;
        Keys lkickK;
        Keys mpunchK;
        Keys mkickK;
        Keys hpunchK;
        Keys hkickK;

        Buttons leftB;
        Buttons rightB;
        Buttons downB;
        Buttons upB;
        Buttons lpunchB;
        Buttons lkickB;
        Buttons mpunchB;
        Buttons mkickB;
        Buttons hpunchB;
        Buttons hkickB;

        Fighter fighter;

        //switch values depending on player position
        public bool backWard
        {
            get
            {
                return ((fighter.sign == 1) ? (Input.IsKeyDown(leftK) || Input.IsButtonDown(leftB, fighter.playerIndex)) : (Input.IsKeyDown(rightK) || Input.IsButtonDown(rightB, fighter.playerIndex)));
            }
        }
        public bool forWard
        {
            get
            {
                return ((fighter.sign == 1) ? (Input.IsKeyDown(rightK) || Input.IsButtonDown(rightB, fighter.playerIndex)) : (Input.IsKeyDown(leftK) || Input.IsButtonDown(leftB, fighter.playerIndex)));
            }
        }

        public bool left
        {
            get { return Input.IsKeyDown(leftK) || Input.IsButtonDown(leftB, fighter.playerIndex); }
        }
        public bool right
        {
            get { return Input.IsKeyDown(rightK) || Input.IsButtonDown(rightB, fighter.playerIndex); }
        }
        public bool down
        {
            get { return Input.IsKeyDown(downK) || Input.IsButtonDown(downB, fighter.playerIndex); }
        }
        public bool up
        {
            get { return Input.IsKeyDown(upK) || Input.IsButtonDown(upB, fighter.playerIndex); }
        }
        public bool lpunch
        {
            get { return Input.WasKeyPressed(lpunchK) || Input.WasButtonPressed(lpunchB, fighter.playerIndex); }
        }
        public bool lkick
        {
            get { return Input.WasKeyPressed(lkickK) || Input.WasButtonPressed(lkickB, fighter.playerIndex); }
        }
        public bool mpunch
        {
            get { return Input.WasKeyPressed(mpunchK) || Input.WasButtonPressed(mpunchB, fighter.playerIndex); }
        }
        public bool mkick
        {
            get { return Input.WasKeyPressed(mkickK) || Input.WasButtonPressed(mkickB, fighter.playerIndex); }
        }
        public bool hpunch
        {
            get { return Input.WasKeyPressed(hpunchK) || Input.WasButtonPressed(hpunchB, fighter.playerIndex); }
        }
        public bool hkick
        {
            get { return Input.WasKeyPressed(hkickK) || Input.WasButtonPressed(hkickB, fighter.playerIndex); }
        }

        //controls definition
        public Controls(Fighter fighter)
        {
            this.fighter = fighter;
            if (fighter.playerIndex == PlayerIndex.One)
            {
                leftK = Keys.Left;
                rightK = Keys.Right;
                upK = Keys.Up;
                downK = Keys.Down;

                lpunchK = Keys.A;
                lkickK = Keys.Z;
                mpunchK = Keys.Q;
                mkickK = Keys.S;
                hpunchK = Keys.W;
                hkickK = Keys.X;

                leftB = Buttons.LeftThumbstickLeft;
                rightB = Buttons.LeftThumbstickRight;
                upB = Buttons.LeftThumbstickUp;
                downB = Buttons.LeftThumbstickDown;

                lpunchB = Buttons.X;
                lkickB = Buttons.A;
                mpunchB = Buttons.Y;
                mkickB = Buttons.B;
                hpunchB = Buttons.RightShoulder;
                hkickB = Buttons.RightTrigger;
            }
            else 
            {
                leftK = Keys.J;
                rightK = Keys.L;
                upK = Keys.I;
                downK = Keys.K;

                lpunchK = Keys.T;
                lkickK = Keys.Y;
                mpunchK = Keys.G;
                mkickK = Keys.H;
                hpunchK = Keys.B;
                hkickK = Keys.N;

                leftB = Buttons.LeftThumbstickLeft;
                rightB = Buttons.LeftThumbstickRight;
                upB = Buttons.LeftThumbstickUp;
                downB = Buttons.LeftThumbstickDown;

                lpunchB = Buttons.X;
                lkickB = Buttons.A;
                mpunchB = Buttons.Y;
                mkickB = Buttons.B;
                hpunchB = Buttons.RightShoulder;
                hkickB = Buttons.RightTrigger;
            }
        }

        
       
    }
}
