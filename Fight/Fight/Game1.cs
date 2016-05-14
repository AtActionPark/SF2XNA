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

namespace Fight
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        FightersManager FightersManager;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Art.Load(Content);
            Stage.Load();
            MoveList.Load();
            FightersManager = new FightersManager();

            graphics.PreferredBackBufferWidth = (int)Static.Size.X;
            graphics.PreferredBackBufferHeight =(int) Static.Size.Y;
            graphics.ApplyChanges();
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            Input.Update();
            Static.Update();
            MoveList.Load();
            Static.pause = Input.IsKeyDown(Keys.Space);
            if ((!Static.pause || (Static.pause && Input.WasKeyPressed(Keys.C))) && !Static.freeze)
                FightersManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null);
            Stage.Draw(spriteBatch);
            FightersManager.Draw(spriteBatch);
            
            spriteBatch.End();
            Window.Title = "FPS: " + 1000/gameTime.ElapsedGameTime.TotalMilliseconds + " " + FightersManager.result;
            base.Draw(gameTime);
        }
    }
}
