using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;
using System.Text;

namespace HitBoxCreator
{
    public enum BoxType { Animation, Collision, Hurt, Hit, GuardProc }

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont Font;
        Texture2D texture;
        Texture2D whitePixel;
        KeyboardState keyboardState, oldState;
        KeyboardState keyboardDrawState, oldDrawState;
        MouseState mouseState, oldMouseState;
        MouseState mouseDrawState;
        float zoom = 1.0f;
        Vector2 position;
        Vector2 size = new Vector2(800, 480);
        BoxType boxType = BoxType.Animation;

        Point lastClickedPoint = Point.Zero;
        Point clickedPoint = Point.Zero;

        List<Rectangle> animationBoxes, hurtBoxes, hitBoxes, collisionBoxes, guardProcBoxes;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("ryu2");
            whitePixel = Content.Load<Texture2D>("WhitePixel");
            Font = Content.Load<SpriteFont>("Font1");
            oldMouseState = Mouse.GetState();
            oldState = Keyboard.GetState();

            animationBoxes = new List<Rectangle>();
            hurtBoxes = new List<Rectangle>();
            hitBoxes = new List<Rectangle>();
            collisionBoxes = new List<Rectangle>();
            guardProcBoxes = new List<Rectangle>();
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();

            Controls();
            

            if (position.X > 0)
                position.X = 0;
            if (position.Y > 0)
                position.Y = 0;

            if (position.X < -texture.Width*zoom+550)
                position.X = -texture.Width*zoom+550;
            if (position.Y < -texture.Height* zoom + 480)
                position.Y = -texture.Height * zoom + 480;

            if (zoom < 0.5f)
                zoom = 0.5f;

            oldState = keyboardState;
            oldMouseState = mouseState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null);
            
            spriteBatch.Draw(texture, position, null,  Color.White, 0f, Vector2.Zero, zoom, SpriteEffects.None, 0);

            DrawMouseRect();
            foreach(Rectangle rect in animationBoxes)
                DrawRect(rect, 2, Color.Black);
            foreach (Rectangle rect in collisionBoxes)
                DrawRect(rect, 2, Color.DarkGreen);
            foreach (Rectangle rect in hurtBoxes)
                DrawRect(rect, 2, Color.Green);
            foreach (Rectangle rect in hitBoxes)
                DrawRect(rect, 2, Color.Red);
            foreach (Rectangle rect in guardProcBoxes)
                DrawRect(rect, 2, Color.DarkRed);

            DrawHub();
            spriteBatch.End();

            Window.Title = "BoxType" + boxType;
            base.Draw(gameTime);
        }

        public void DrawHub()
        {
            spriteBatch.Draw(whitePixel, new Rectangle(550, 0, 250, 480), new Rectangle(0, 0, 1, 1), Color.Black);
            spriteBatch.DrawString(Font, "MoveCamera : Arrows", new Vector2(600, 50), Color.Red);
            spriteBatch.DrawString(Font, "Zoom +- : pageUp/pageDown", new Vector2(600, 70), Color.Red);
            spriteBatch.DrawString(Font, "DrawBox with mouse", new Vector2(600, 90), Color.Red);
            spriteBatch.DrawString(Font, "Change Box Type : 1-2-3-4", new Vector2(600, 110), Color.Red);
            spriteBatch.DrawString(Font, "Add Box : Enter", new Vector2(600, 130), Color.Red);

            spriteBatch.DrawString(Font, "Del last box : Z", new Vector2(600, 150), Color.Red);
            spriteBatch.DrawString(Font, "Move last box : K-L-M-O", new Vector2(600, 170), Color.Red);
            spriteBatch.DrawString(Font, "Write to file : W", new Vector2(600, 190), Color.Red);
        }

        public void DrawMouseRect()
        {
            keyboardDrawState = Keyboard.GetState();
            mouseDrawState = Mouse.GetState();

            if (mouseDrawState.LeftButton == ButtonState.Released)
            {
                lastClickedPoint = new Point(mouseDrawState.X, mouseDrawState.Y);
            }

            if (mouseDrawState.LeftButton == ButtonState.Pressed)
            {
                clickedPoint = new Point(mouseDrawState.X, mouseDrawState.Y);

                Point A = lastClickedPoint;
                Point B = clickedPoint;

                if (A.X > B.X)
                {
                   int temp = A.X;
                   A.X = B.X;
                   B.X = temp;
                }

                if (A.Y > B.Y)
                {
                    int temp = A.Y;
                    A.Y = B.Y;
                    B.Y = temp;
                }

                DrawRect(A, B, 2, Color.LightGray);

                if (keyboardDrawState.IsKeyDown(Keys.Enter) && oldDrawState.IsKeyUp(Keys.Enter))
                {
                    Rectangle rect = new Rectangle((int)Math.Ceiling((1 / zoom * A.X) - (position.X * 1 / zoom)),
                        (int)Math.Ceiling(1/zoom*A.Y)-(int)(position.Y*1/zoom),
                        (int)(1 / zoom * (B.X - A.X)),
                        (int)(1 / zoom * (B.Y - A.Y)));

                    if (boxType == BoxType.Animation)
                        animationBoxes.Add(rect);
                    else if (boxType == BoxType.Collision)
                        collisionBoxes.Add(rect);
                    else if (boxType == BoxType.Hurt)
                        hurtBoxes.Add(rect);
                    else if (boxType == BoxType.Hit)
                        hitBoxes.Add(rect);
                    else if (boxType == BoxType.GuardProc)
                        guardProcBoxes.Add(rect);
                }

                //oldMouseDrawState = mouseDrawState;
                oldDrawState = keyboardState;
            }   
        }

        public void DrawRect(Point a, Point b, int width, Color color)
        {
            //draw horizontal
            spriteBatch.Draw(whitePixel,
                new Rectangle(a.X,
                              a.Y,
                              Math.Abs(b.X - a.X), width),
                new Rectangle(0, 0, 1, 1),
                color);
            spriteBatch.Draw(whitePixel, new Rectangle(a.X, b.Y, Math.Abs(b.X - a.X), width), new Rectangle(0, 0, 1, 1), color);


            //draw vertical
            spriteBatch.Draw(whitePixel, 
                new Rectangle(a.X, 
                              a.Y, 
                              width, 
                              Math.Abs(b.Y - a.Y)),
                new Rectangle(0, 0, 1, 1), 
                color);

            spriteBatch.Draw(whitePixel, new Rectangle(b.X, a.Y, width, Math.Abs(b.Y - a.Y)), new Rectangle(0, 0, 1, 1), color);      
        }

        public void DrawRect(Rectangle rect, int width, Color color)
        {
            if (rect != Rectangle.Empty)
                DrawRect(new Point((int)Math.Ceiling(zoom * (rect.X) + position.X),
                                   (int)Math.Ceiling(zoom * (rect.Y) + position.Y)),
                         new Point((int)Math.Ceiling(zoom*(rect.X + rect.Width) + position.X),
                                   (int)Math.Ceiling(zoom*(rect.Y + rect.Height) + position.Y)),
                         (int)(width),
                         color);
        }

        private void Reset()
        {
            position = Vector2.Zero;
            zoom = 1;
        }

        private void Controls()
        {
            if (keyboardState.GetPressedKeys().Count() == 0)
                return;

            if (keyboardState.IsKeyDown(Keys.PageUp) && oldState.IsKeyUp(Keys.PageUp))
                zoom += 0.2f;

            if (keyboardState.IsKeyDown(Keys.PageDown) && oldState.IsKeyUp(Keys.PageDown))
                zoom -= 0.2f;

            if (keyboardState.IsKeyDown(Keys.Left))
                position.X += 5f * zoom;

            if (keyboardState.IsKeyDown(Keys.Right))
                position.X -= 5f * zoom;
                
            if (keyboardState.IsKeyDown(Keys.Up))
                position.Y += 5f * zoom;

            if (keyboardState.IsKeyDown(Keys.Down))
                position.Y -= 5f * zoom;

            if (keyboardState.IsKeyDown(Keys.X))
                Reset();

            if (keyboardState.IsKeyDown(Keys.D1))
                boxType = BoxType.Animation;
            if (keyboardState.IsKeyDown(Keys.D2))
                boxType = BoxType.Collision;
            if (keyboardState.IsKeyDown(Keys.D3))
                boxType = BoxType.Hurt;
            if (keyboardState.IsKeyDown(Keys.D4))
                boxType = BoxType.Hit;
            if (keyboardState.IsKeyDown(Keys.D5))
                boxType = BoxType.GuardProc;

            if (keyboardState.IsKeyDown(Keys.W) && oldState.IsKeyUp(Keys.W))
               Write();

            if (keyboardState.IsKeyDown(Keys.Z) && oldState.IsKeyUp(Keys.Z))
                Delete();

            if (keyboardState.IsKeyDown(Keys.K) && oldState.IsKeyUp(Keys.K))
                MoveRect(new Vector2(-1, 0));
            if (keyboardState.IsKeyDown(Keys.M) && oldState.IsKeyUp(Keys.M))
                MoveRect(new Vector2(1, 0));
            if (keyboardState.IsKeyDown(Keys.L) && oldState.IsKeyUp(Keys.L))
                MoveRect(new Vector2(0, 1));
            if (keyboardState.IsKeyDown(Keys.O) && oldState.IsKeyUp(Keys.O))
                MoveRect(new Vector2(0, -1));
        }

        private void Write()
        {
            List<string> stringlist = new List<string>();

            stringlist.Add("animations = new Rectangle[" + animationBoxes.Count+"];");
            for (int i = 0; i < animationBoxes.Count; i++)
            {
                string a = animationBoxes[i].X.ToString();
                string b = animationBoxes[i].Y.ToString();
                string c = animationBoxes[i].Width.ToString();
                string d = animationBoxes[i].Height.ToString();
                stringlist.Add("animations[" + i + "] = new Rectangle("+a+", "+b+", "+c+", "+d+");");
            }

            stringlist.Add("");

            stringlist.Add("hurtBox = new Rectangle[" + hurtBoxes.Count + "];");
            for (int i = 0; i < hurtBoxes.Count; i++)
            {
                string a = hurtBoxes[i].X.ToString();
                string b = hurtBoxes[i].Y.ToString();
                string c = hurtBoxes[i].Width.ToString();
                string d = hurtBoxes[i].Height.ToString();
                stringlist.Add("hurtBox[" + i + "] = new Rectangle(" + a + ", " + b + ", " + c + ", " + d + ");");
            }

            stringlist.Add("");

            stringlist.Add("collisionBox = new Rectangle[" + collisionBoxes.Count + "];");
            for (int i = 0; i < collisionBoxes.Count; i++)
            {
                string a = collisionBoxes[i].X.ToString();
                string b = collisionBoxes[i].Y.ToString();
                string c = collisionBoxes[i].Width.ToString();
                string d = collisionBoxes[i].Height.ToString();
                stringlist.Add("collisionBox[" + i + "] = new Rectangle(" + a + ", " + b + ", " + c + ", " + d + ");");
            }

            stringlist.Add("");

            stringlist.Add("hitBox = new Rectangle[" + hitBoxes.Count + "];");
            for (int i = 0; i < hitBoxes.Count; i++)
            {
                string a = hitBoxes[i].X.ToString();
                string b = hitBoxes[i].Y.ToString();
                string c = hitBoxes[i].Width.ToString();
                string d = hitBoxes[i].Height.ToString();
                stringlist.Add("hitBox[" + i + "] = new Rectangle(" + a + ", " + b + ", " + c + ", " + d + ");");
            }

            stringlist.Add("");

            stringlist.Add("guardProcBox = new Rectangle[" + guardProcBoxes.Count + "];");
            for (int i = 0; i < guardProcBoxes.Count; i++)
            {
                string a = guardProcBoxes[i].X.ToString();
                string b = guardProcBoxes[i].Y.ToString();
                string c = guardProcBoxes[i].Width.ToString();
                string d = guardProcBoxes[i].Height.ToString();
                stringlist.Add("guardProctBox[" + i + "] = new Rectangle(" + a + ", " + b + ", " + c + ", " + d + ");");
            }

            string[] stringArray = stringlist.ToArray();
            File.WriteAllLines("c:/test.txt", stringArray);

        }

        private void Delete()
        {
            if (boxType == BoxType.Animation && animationBoxes.Count>0)
                animationBoxes.RemoveAt(animationBoxes.Count-1);
            else if (boxType == BoxType.Collision && collisionBoxes.Count>0)
                collisionBoxes.RemoveAt(collisionBoxes.Count-1);
            else if (boxType == BoxType.Hurt && hurtBoxes.Count>0)
                hurtBoxes.RemoveAt(hurtBoxes.Count-1);
            else if (boxType == BoxType.Hit && hitBoxes.Count>0)
                hitBoxes.RemoveAt(hitBoxes.Count-1);
            else if (boxType == BoxType.GuardProc && guardProcBoxes.Count>0)
                guardProcBoxes.RemoveAt(guardProcBoxes.Count-1);
        }

        private void MoveRect(Vector2 dir)
        {
            Rectangle rect = Rectangle.Empty;

            if (boxType == BoxType.Animation && animationBoxes.Count > 0)
                rect = animationBoxes[animationBoxes.Count-1];
            else if (boxType == BoxType.Collision && collisionBoxes.Count > 0)
                rect = collisionBoxes[collisionBoxes.Count - 1];
            else if (boxType == BoxType.Hurt && hurtBoxes.Count > 0)
                rect = hurtBoxes[hurtBoxes.Count - 1];
            else if (boxType == BoxType.Hit && hitBoxes.Count > 0)
                rect = hitBoxes[hitBoxes.Count - 1];
            else if (boxType == BoxType.GuardProc && guardProcBoxes.Count > 0)
                rect = guardProcBoxes[guardProcBoxes.Count - 1];

            rect.X += (int)dir.X;
            rect.Y += (int)dir.Y;

            if (boxType == BoxType.Animation)
                animationBoxes[animationBoxes.Count - 1] = rect;
            if (boxType == BoxType.Collision)
                collisionBoxes[collisionBoxes.Count - 1] = rect;
            if (boxType == BoxType.Hurt)
                hurtBoxes[hurtBoxes.Count - 1] = rect;
            if (boxType == BoxType.Hit)
                hitBoxes[hitBoxes.Count - 1] = rect;
            if (boxType == BoxType.GuardProc)
                guardProcBoxes[guardProcBoxes.Count - 1] = rect;
        }
       
    }
}
