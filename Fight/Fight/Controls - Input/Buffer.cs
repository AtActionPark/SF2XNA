using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Fight
{
    public enum Move {Left,Right,UpLeft,UpRight,DownLeft,DownRight,Up, Down, Backward, Forward,UpBackward, UpForward, DownBackward,DownForward, LPunch, LKick,MPunch,MKick,HPunch,HKick,ForwardThrow, None}

    public enum Strength { Light, Medium, Hard }

    public class Buffer
    {
        int bufferSize = 30;
        List<Move>[] buffer;
        List<Move>[] drawBuffer;
        Fighter fighter;

        Controls control;
        public Strength strength;

        //move
        public bool moveBackward;
        public bool moveForward;
        public bool moveCrouchForward;
        public bool moveCrouchBackward;
        public bool moveCrouch;
        public bool neutralJump;
        public bool backwardJump;
        public bool forwardJump;
        public bool crouch;
        //hit
        public bool lpunch;
        public bool lkick;
        public bool mpunch;
        public bool mkick;
        public bool hpunch;
        public bool hkick;

        public bool shoryuMotion;
        public bool hadoMotion;
        public bool doubleHadoMotion;
        public bool tatsuMotion;

        public bool forwardThrow;
        public int leniency =5;
        public int normalLeniency = 1;
        

        //create a new buffer with specific key binding
        public Buffer(Fighter fighter)
        {
            this.fighter = fighter;
            control = new Controls(fighter);

            buffer = new List<Move>[bufferSize];
            drawBuffer = new List<Move>[bufferSize];
            for (int i = 0; i < bufferSize; i++)
            {
                buffer[i] = new List<Move>();
                drawBuffer[i] = new List<Move>();
            }
        }

        public void Update(int sign, PlayerIndex playerIndex)
        {
            //shift every value to the left, erasing the oldest one
            for (int i = 0; i < bufferSize - 1; i++)
            {
                buffer[i] = buffer[i + 1].ToList();
                if(!Input.NoPressedKey())
                    drawBuffer[i] = drawBuffer[i + 1].ToList();
            }
            //clear buffer's last position
            buffer[bufferSize - 1].Clear();
            if (!Input.NoPressedKey())
                drawBuffer[bufferSize - 1].Clear();

            //last value is entered via priority input
            #region input


            if (control.up && control.left)
                buffer[bufferSize - 1].Add(Move.UpLeft);
            else if (control.up && control.right)
                buffer[bufferSize - 1].Add(Move.UpRight);
            else if (control.down && control.left)
                buffer[bufferSize - 1].Add(Move.DownLeft);
            else if (control.down && control.right)
                buffer[bufferSize - 1].Add(Move.DownRight);
            else if (control.left)
                buffer[bufferSize - 1].Add(Move.Left);
            else if (control.right)
                buffer[bufferSize - 1].Add(Move.Right);

            if (control.lpunch && control.lkick)
                buffer[bufferSize - 1].Add(Move.ForwardThrow);
            if (control.lpunch)
                buffer[bufferSize - 1].Add(Move.LPunch);
            if (control.lkick)
                buffer[bufferSize - 1].Add(Move.LKick);
            if (control.mpunch)
                buffer[bufferSize - 1].Add(Move.MPunch);
            if (control.mkick)
                buffer[bufferSize - 1].Add(Move.MKick);
            if (control.hpunch)
                buffer[bufferSize - 1].Add(Move.HPunch);
            if (control.hkick)
                buffer[bufferSize - 1].Add(Move.HKick);

            if (control.backWard && control.up)
                buffer[bufferSize - 1].Add(Move.UpBackward);
            else if (control.backWard && control.down)
                buffer[bufferSize - 1].Add(Move.DownBackward);
            else if (control.forWard && control.up)
                buffer[bufferSize - 1].Add(Move.UpForward);
            else if (control.forWard && control.down)
                buffer[bufferSize - 1].Add(Move.DownForward);

            if (!buffer[bufferSize - 1].Contains(Move.UpForward) && !buffer[bufferSize - 1].Contains(Move.DownForward))
            {
                if (control.forWard)
                    buffer[bufferSize - 1].Add(Move.Forward);
            }

            if (!buffer[bufferSize - 1].Contains(Move.UpBackward) && !buffer[bufferSize - 1].Contains(Move.DownBackward))
            {
                if (control.backWard)
                    buffer[bufferSize - 1].Add(Move.Backward);
            }

            if (!buffer[bufferSize - 1].Contains(Move.DownBackward) && !buffer[bufferSize - 1].Contains(Move.DownForward))
            {
                if (control.down)
                    buffer[bufferSize - 1].Add(Move.Down);
            }

            if (!buffer[bufferSize - 1].Contains(Move.UpBackward) && !buffer[bufferSize - 1].Contains(Move.UpForward))
            {
                if (control.up)
                    buffer[bufferSize - 1].Add(Move.Up);
            }
            
            if(Input.NoPressedKey() || Input.NoPressedButtons())
                buffer[bufferSize - 1].Add(Move.None);
            #endregion

            //only update drawing buffer when a key is pressed
            if (!Input.NoPressedKey())
                drawBuffer[bufferSize-1] = buffer[bufferSize-1].ToList();

            moveForward = false;
            moveBackward = false;
            moveCrouch = false;
            moveCrouchBackward = false;
            moveCrouchForward = false;

            lpunch = false;
            lkick = false;

            mpunch = false;
            mkick = false;

            hpunch = false;
            hkick = false;

            neutralJump = false;
            backwardJump = false;
            forwardJump = false;
            shoryuMotion = false;
            hadoMotion = false;
            tatsuMotion = false;
            doubleHadoMotion = false;

            forwardThrow = false;
            //crouch = false;
            Analyse();
        }

        //check the content of the buffer for specific sequences
        public bool Analyse()
        {
            crouch = buffer[bufferSize - 1].Contains(Move.Down) || buffer[bufferSize - 1].Contains(Move.DownBackward) || buffer[bufferSize - 1].Contains(Move.DownForward);
            
            //check for shoryu motion
            if (BufferContains(Move.LPunch, leniency) || BufferContains(Move.MPunch, leniency) || BufferContains(Move.HPunch, leniency))
                for (int i = bufferSize-2; i > 0; i--)
                    if (buffer[i].Contains(Move.DownForward))
                        for (int j = i-1; j > 0; j--)
                            if (buffer[j].Contains(Move.Down))
                                for (int k = j-1; k > 0; k--)
                                    if (buffer[k].Contains(Move.Forward))
                                    {
                                        if (BufferContains(Move.HPunch, leniency))
                                            strength = Strength.Hard;
                                        else if (BufferContains(Move.MPunch, leniency))
                                            strength = Strength.Medium;
                                        else if (BufferContains(Move.LPunch, leniency))
                                            strength = Strength.Light;
                                        shoryuMotion = true;
                                        return true;
                                    }
            //check for hado motion
            if (BufferContains(Move.LPunch, leniency) || BufferContains(Move.MPunch, leniency) || BufferContains(Move.HPunch, leniency))
                for (int i = bufferSize - 2; i > 0; i--)
                    if (buffer[i].Contains(Move.Forward))
                        for (int j = i - 1; j > 0; j--)
                            if (buffer[j].Contains(Move.DownForward))
                                for (int k = j - 1; k > 0; k--)
                                    if (buffer[k].Contains(Move.Down))
                                    {
                                        if (buffer[bufferSize - 1].Contains(Move.HPunch))
                                            strength = Strength.Hard;
                                        else if (buffer[bufferSize - 1].Contains(Move.MPunch))
                                            strength = Strength.Medium;
                                        else if (buffer[bufferSize - 1].Contains(Move.LPunch))
                                            strength = Strength.Light;
                                        hadoMotion = true;
                                        return true;
                                    }

            //check for tatsu motion
            if (BufferContains(Move.LKick, leniency) || BufferContains(Move.MKick, leniency) || BufferContains(Move.HKick, leniency))
                for (int i = bufferSize - 2; i > 0; i--)
                    if (buffer[i].Contains(Move.Backward))
                        for (int j = i - 1; j > 0; j--)
                            if (buffer[j].Contains(Move.DownBackward))
                                for (int k = j - 1; k > 0; k--)
                                    if (buffer[k].Contains(Move.Down))
                                    {
                                        if (buffer[bufferSize - 1].Contains(Move.HKick))
                                            strength = Strength.Hard;
                                        else if (buffer[bufferSize - 1].Contains(Move.MKick))
                                            strength = Strength.Medium;
                                        else if (buffer[bufferSize - 1].Contains(Move.LKick))
                                            strength = Strength.Light;
                                        tatsuMotion = true;
                                        return true;
                                    }

            //check for forward Throw
            if (buffer[bufferSize - 1].Contains(Move.ForwardThrow)||
               ( buffer[bufferSize - 1].Contains(Move.LPunch)&& buffer[bufferSize - 2].Contains(Move.LKick))||
                (buffer[bufferSize - 2].Contains(Move.LPunch) && buffer[bufferSize - 1].Contains(Move.LKick)))
            {
                forwardThrow = true;
                return true;
            }

            //check for hkick
            if (BufferContains(Move.HKick, normalLeniency))
            {
                hkick = true;
                return true;
            }
            //check for hpunch
            if (BufferContains(Move.HPunch, normalLeniency))
            {
                hpunch = true;
                return true;
            }
            //check for mkick
            if (BufferContains(Move.MKick, normalLeniency))
            {
                mkick = true;
                return true;
            }
            //check for mpunch
            if (BufferContains(Move.MPunch, normalLeniency))
            {
                mpunch = true;
                return true;
            }
            //check for lkick
            if (BufferContains(Move.LKick, normalLeniency))
            {
                lkick = true;
                return true;
            }
            //check for lpunch
            if (BufferContains(Move.LPunch, normalLeniency))
                {
                    lpunch = true;
                    return true;
                }
            //check for neutralJump
            if (buffer[bufferSize - 1].Contains(Move.Up))
            {
                neutralJump = true;
                return true;
            }
            //check for rightJump
            if (buffer[bufferSize - 1].Contains(Move.UpForward))
            {
                forwardJump = true;
                return true;
            }
            //check for leftJump
            if (buffer[bufferSize - 1].Contains( Move.UpBackward))
            {
                backwardJump = true;
                return true;
            }
                    
            //check for moveLeft
            if (buffer[bufferSize - 1].Contains(Move.Backward))
                {
                    moveBackward = true;
                    return true;
                }

            //check for moveRight
            if (buffer[bufferSize - 1].Contains(Move.Forward))
                {
                    moveForward = true;
                    return true;
                }
            //check for crouch
            if (buffer[bufferSize - 1].Contains( Move.Down))
            {
                moveCrouch = true;
                return true;
            }
            //check for crouchBackward
            if (buffer[bufferSize - 1].Contains(Move.DownBackward))
            {
                moveCrouchBackward = true;
                return true;
            }
            //check for crouchForward
            if (buffer[bufferSize - 1].Contains(Move.DownForward))
            {
                moveCrouchForward = true;
                return true;
            }

            return false;
        }

        //draw all buffer values 
        public void Draw(SpriteBatch spriteBatch, Vector2 start, PlayerIndex playerIndex)
        {
                int bufferstart = 10;
                for (int i = 0; i < bufferSize-bufferstart; i++)
                {
                    int incr = 22;
                    int dec = 0;
                    #region move
                    if (drawBuffer[i + bufferstart].Contains(Move.Right))
                    {
                        spriteBatch.Draw(Art.FontSheet, start + new Vector2(dec, i * incr), new Rectangle(24, 120, 24, 24), Color.White);
                        dec += incr;
                    }

                    if (drawBuffer[i + bufferstart].Contains(Move.Left))
                    {
                        spriteBatch.Draw(Art.FontSheet, start + new Vector2(dec, i * incr), new Rectangle(0, 120, 24, 24), Color.White);
                        dec += incr;
                    }

                    if (drawBuffer[i + bufferstart].Contains(Move.Up))
                    {
                        spriteBatch.Draw(Art.FontSheet, start + new Vector2(dec, i * incr), new Rectangle(24, 96, 24, 24), Color.White);
                        dec += incr;
                    }

                    if (drawBuffer[i + bufferstart].Contains(Move.Down))
                    {
                        spriteBatch.Draw(Art.FontSheet, start + new Vector2(dec, i * incr), new Rectangle(0, 96, 24, 24), Color.White);
                        dec += incr;
                    }

                    if (drawBuffer[i + bufferstart].Contains(Move.UpRight))
                    {
                        spriteBatch.Draw(Art.FontSheet, start + new Vector2(dec, i * incr), new Rectangle(24, 168, 24, 24), Color.White);
                        dec += incr;
                    }

                    if (drawBuffer[i + bufferstart].Contains(Move.UpLeft))
                    {
                        spriteBatch.Draw(Art.FontSheet, start + new Vector2(dec, i * incr), new Rectangle(0, 168, 24, 24), Color.White);
                        dec += incr;
                    }

                    if (drawBuffer[i + bufferstart].Contains(Move.DownLeft))
                    {
                        spriteBatch.Draw(Art.FontSheet, start + new Vector2(dec, i * incr), new Rectangle(0, 144, 24, 24), Color.White);
                        dec += incr;
                    }

                    if (drawBuffer[i + bufferstart].Contains(Move.DownRight))
                    {
                        spriteBatch.Draw(Art.FontSheet, start + new Vector2(dec, i * incr), new Rectangle(24, 144, 24, 24), Color.White);
                        dec += incr;
                    }
                    #endregion     
                    #region hit
                    if (drawBuffer[i + bufferstart].Contains(Move.LPunch))
                    {
                        spriteBatch.Draw(Art.FontSheet, start + new Vector2(dec, i * incr), new Rectangle(0, 33, 24, 24), Color.White);
                        dec += incr;
                    }

                    if (drawBuffer[i + bufferstart].Contains(Move.LKick))
                    {
                        spriteBatch.Draw(Art.FontSheet, start + new Vector2(dec, i * incr), new Rectangle(0, 57, 24, 24), Color.White);
                        dec += incr;
                    }
                    if (drawBuffer[i + bufferstart].Contains(Move.MPunch))
                    {
                        spriteBatch.Draw(Art.FontSheet, start + new Vector2(dec, i * incr), new Rectangle(24, 33, 24, 24), Color.White);
                        dec += incr;
                    }

                    if (drawBuffer[i + bufferstart].Contains(Move.MKick))
                    {
                        spriteBatch.Draw(Art.FontSheet, start + new Vector2(dec, i * incr), new Rectangle(24, 57, 24, 24), Color.White);
                        dec += incr;
                    }
                    if (drawBuffer[i + bufferstart].Contains(Move.HPunch))
                    {
                        spriteBatch.Draw(Art.FontSheet, start + new Vector2(dec, i * incr), new Rectangle(48, 33, 24, 24), Color.White);
                        dec += incr;
                    }

                    if (drawBuffer[i + bufferstart].Contains(Move.HKick))
                    {
                        spriteBatch.Draw(Art.FontSheet, start + new Vector2(dec, i * incr), new Rectangle(48, 57, 24, 24), Color.White);
                        dec += incr;
                    }
                    #endregion
                    
                }

        }

        public bool BufferContains(Move move, int leniency)
        {
            for (int i = 0; i < leniency; i++)
                if (buffer[bufferSize -1 - i].Contains(move))
                    return true;
            return false;
        }
    }
}
