using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Fight
{
    public class AnimationManager
    {
        public Texture2D texture;
        public Vector2 position = Vector2.Zero;
        public Color color = Color.White;
        public Vector2 origin;
        public float rotation = 0f;
        public float scale = 2;
        public SpriteEffects spriteEffect;
        public int frameIndex = 0;
        public bool isLooping = false;
        public bool reset = false;

        private float timeElapsed;
        public float timeToUpdate =0.06f;
        public int framesPerSecond
        {
            set { timeToUpdate = (1f / value); }
        }
        public bool animEnded;


        protected Dictionary<string, Animation> animations = new Dictionary<string, Animation>();

        public string animation;
        protected int frames;
        public int height;
        public int width;
        public Fighter fighter;

        public int test1, test2;
        public int decal;
        public int currentFrameWidth;
        public int lastFrameWidth;
        public int firstFrameWidth;

        public AnimationManager(Texture2D texture, int frames, int animations, Fighter fighter)
        {
            this.texture = texture;
            this.frames = frames;
            width = texture.Width / frames;
            height = texture.Height / animations;
            this.fighter = fighter; 
        }

        public void Update(GameTime gameTime)
        {
            animEnded = false;
            isLooping = animations[animation].isLooping;
            
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > animations[animation].timeToUpdate)
            {
                timeElapsed -= animations[animation].timeToUpdate;
                if (frameIndex < animations[animation].animations.Count() - 1)
                    frameIndex++;
                else if (isLooping)
                {
                    frameIndex = 0;
                }
                else
                    animEnded = true;
            }
            //flip sprite if facing left
            if (fighter.sign == 1)
            {
                spriteEffect = SpriteEffects.None;
                if (animations[animation].inverse)
                    spriteEffect = SpriteEffects.FlipHorizontally;
            }
            else
            { spriteEffect = SpriteEffects.FlipHorizontally;
            if (animations[animation].inverse)
                spriteEffect = SpriteEffects.None;
            }

            UpdateBoxes();
            Displacement();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (frameIndex > animations[animation].animations.Count())
                frameIndex = 0;

            spriteBatch.Draw(texture,
                    position,
                    animations[animation].animations[frameIndex],
                    color,
                    rotation,
                    origin,
                    scale,
                    spriteEffect,
                    0f);
        }

        public void UpdateBoxes()
        {
            if (frameIndex >= animations[animation].animations.Count())
                frameIndex = 0;

            currentFrameWidth = (int)scale*animations[animation].animations[frameIndex].Width;
            firstFrameWidth = (int)scale * animations[animation].animations[0].Width;

            //frames may have different width
            decal = (int)(currentFrameWidth - firstFrameWidth);

            #region sign = 1
            if (fighter.sign == 1)
            {
                #region hurtBox
                fighter.HurtBox = new Rectangle((int)(
                    //position
                    fighter.Position.X + Stage.position
                    //hurtbox x coordinate in frame reference
                    +scale*(animations[animation].hurtBox[frameIndex].X- animations[animation].animations[frameIndex].X)
                    //center around position
                    -(currentFrameWidth -decal)/2
                    ),

                    (int)(
                    fighter.Position.Y
                    + scale * (animations[animation].hurtBox[frameIndex].Y - animations[animation].animations[frameIndex].Y)
                    - scale * animations[animation].animations[frameIndex].Height
                    ),

                    animations[animation].hurtBox[frameIndex].Width * (int)scale,

                    animations[animation].hurtBox[frameIndex].Height * (int)scale);
                #endregion

                #region collisionBox
                fighter.CollisionBox = new Rectangle((int)(
                    //position
                    fighter.Position.X + Stage.position
                    //hurtbox x coordinate in frame reference
                    +scale*(animations[animation].collisionBox[frameIndex].X- animations[animation].animations[frameIndex].X)
                    //center around position
                    -(currentFrameWidth -decal)/2
                    ),

                    (int)(scale * animations[animation].collisionBox[frameIndex].Y
                     - scale * animations[animation].animations[frameIndex].Y
                     - scale * animations[animation].animations[frameIndex].Height
                     + fighter.Position.Y),

                     animations[animation].collisionBox[frameIndex].Width * (int)scale,

                     animations[animation].collisionBox[frameIndex].Height * (int)scale);
                #endregion
                 
                #region hitBox
                if (animations[animation].hitBox[frameIndex] != Rectangle.Empty)
                {
                    fighter.HitBox = new Rectangle((int)(
                    //position
                    fighter.Position.X + Stage.position
                    //hurtbox x coordinate in frame reference
                    + scale * (animations[animation].hitBox[frameIndex].X - animations[animation].animations[frameIndex].X)
                    //center around position
                    - (currentFrameWidth - decal) / 2
                    ),

                    (int)(scale * animations[animation].hitBox[frameIndex].Y
                    - scale * animations[animation].animations[frameIndex].Y
                    - scale * animations[animation].animations[frameIndex].Height
                    + fighter.Position.Y),

                    animations[animation].hitBox[frameIndex].Width * (int)scale,

                    animations[animation].hitBox[frameIndex].Height * (int)scale);
                }
                else
                    fighter.HitBox = new Rectangle(0, 0, 0, 0);
                #endregion

                #region GuardProcBox
                if (animations[animation].guardProcBox[frameIndex] != Rectangle.Empty)
                {
                    fighter.GuardProcBox = new Rectangle((int)(
                        //position
                    fighter.Position.X + Stage.position
                        //hurtbox x coordinate in frame reference
                    + scale * (animations[animation].guardProcBox[frameIndex].X - animations[animation].animations[frameIndex].X)
                        //center around position
                    - (currentFrameWidth - decal) / 2
                    ),

                    (int)(scale * animations[animation].guardProcBox[frameIndex].Y
                    - scale * animations[animation].animations[frameIndex].Y
                    - scale * animations[animation].animations[frameIndex].Height
                    + fighter.Position.Y),

                    animations[animation].guardProcBox[frameIndex].Width * (int)scale,

                    animations[animation].guardProcBox[frameIndex].Height * (int)scale);
                }
                else
                    fighter.GuardProcBox = new Rectangle(0, 0, 0, 0);
                #endregion
            }
            #endregion

            #region sign = -1
            else if (fighter.sign == -1)
            {
                #region hurtBox
                fighter.HurtBox = new Rectangle((int)(
                    //position
                    +fighter.Position.X + Stage.position
                    //hurtbox x coordinate in frame reference
                    - scale * (animations[animation].hurtBox[frameIndex].X - animations[animation].animations[frameIndex].X + animations[animation].hurtBox[frameIndex].Width)
                    //center around current position
                    + (currentFrameWidth - decal)/2
                    ),

                    (int)(scale * animations[animation].hurtBox[frameIndex].Y
                    - scale * animations[animation].animations[frameIndex].Y
                    - scale * animations[animation].animations[frameIndex].Height
                    + fighter.Position.Y),

                    animations[animation].hurtBox[frameIndex].Width * (int)scale,

                    animations[animation].hurtBox[frameIndex].Height * (int)scale);
                #endregion

                #region collisionBox
                fighter.CollisionBox = new Rectangle((int)(
                    //position
                    +fighter.Position.X + Stage.position
                    //hurtbox x coordinate in frame reference
                    - scale * (animations[animation].collisionBox[frameIndex].X - animations[animation].animations[frameIndex].X + animations[animation].collisionBox[frameIndex].Width)
                    //center around current position
                    + (currentFrameWidth - decal) / 2
                    ),

                    (int)(scale * animations[animation].collisionBox[frameIndex].Y
                    - scale * animations[animation].animations[frameIndex].Y
                    - scale * animations[animation].animations[frameIndex].Height
                    + fighter.Position.Y),

                    animations[animation].collisionBox[frameIndex].Width * (int)scale,

                    animations[animation].collisionBox[frameIndex].Height * (int)scale);
                #endregion

                #region hitBox
                if (animations[animation].hitBox[frameIndex] != Rectangle.Empty)
                {
                    fighter.HitBox = new Rectangle((int)(
                    //position
                    +fighter.Position.X + Stage.position
                    //hurtbox x coordinate in frame reference
                    - scale * (animations[animation].hitBox[frameIndex].X - animations[animation].animations[frameIndex].X + animations[animation].hitBox[frameIndex].Width)
                    //center around current position
                    + (currentFrameWidth - decal) / 2
                    ),

                    (int)(scale * animations[animation].hitBox[frameIndex].Y
                    - scale * animations[animation].animations[frameIndex].Y
                    - scale * animations[animation].animations[frameIndex].Height
                    + fighter.Position.Y),

                    animations[animation].hitBox[frameIndex].Width * (int)scale,

                    animations[animation].hitBox[frameIndex].Height * (int)scale);
                }
                else
                    fighter.HitBox = new Rectangle(0, 0, 0, 0);
                #endregion

                #region guardProcBox
                if (animations[animation].guardProcBox[frameIndex] != Rectangle.Empty)
                {
                    fighter.GuardProcBox = new Rectangle((int)(
                        //position
                    +fighter.Position.X + Stage.position
                        //hurtbox x coordinate in frame reference
                    - scale * (animations[animation].guardProcBox[frameIndex].X - animations[animation].animations[frameIndex].X + animations[animation].guardProcBox[frameIndex].Width)
                        //center around current position
                    + (currentFrameWidth - decal) / 2
                    ),

                    (int)(scale * animations[animation].guardProcBox[frameIndex].Y
                    - scale * animations[animation].animations[frameIndex].Y
                    - scale * animations[animation].animations[frameIndex].Height
                    + fighter.Position.Y),

                    animations[animation].guardProcBox[frameIndex].Width * (int)scale,

                    animations[animation].guardProcBox[frameIndex].Height * (int)scale);
                }
                else
                    fighter.GuardProcBox = new Rectangle(0, 0, 0, 0);
                #endregion
            }
            #endregion

            int x = (currentFrameWidth - decal) / 2;
            if (fighter.sign == -1)
                x = decal + (lastFrameWidth - decal) / 2 + (int)scale * (animations[animation].animations[frameIndex].Width/2);

            position = new Vector2(fighter.Position.X + Stage.position - x,
                                fighter.Position.Y - animations[animation].animations[frameIndex].Height * scale);
        }

        public void Displacement()
        {
            if(frameIndex<animations[animation].displacement.Count())
            {
                fighter.velocity += animations[animation].displacement[frameIndex];
                if (fighter.velocity.Y < 0)
                    fighter.isOnGround = false;
            }
        }

        public void AddAnimation(string name, Animation anim)
        {
            animations.Add(name,anim);
        }

        public void ChangeAnimation(string name, Animation anim)
        {
            animations[name] = anim;
        }

        public void ResetFrameCount()
        {
            frameIndex = 0;
        }

    }
}
