using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Fight
{
    public class ProjectileAnimationManager
    {
        public Texture2D texture;
        public Vector2 position = Vector2.Zero;
        public Color color = Color.White;
        public Vector2 origin;
        public float rotation = 0f;
        public float scale = 2f;
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
        public Projectile projectile;

        public int test1, test2;
        public int decal;
        public int currentFrameWidth;
        public int lastFrameWidth;
        public int firstFrameWidth;

        public ProjectileAnimationManager(Texture2D texture, int frames, int animations, Projectile projectile)
        {
            this.texture = texture;
            this.frames = frames;
            width = texture.Width / frames;
            height = texture.Height / animations;
            this.projectile = projectile;
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
                if (projectile.sign == 1)
                {
                    spriteEffect = SpriteEffects.None;
                    if (animations[animation].inverse)
                        spriteEffect = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    spriteEffect = SpriteEffects.FlipHorizontally;
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

            #region sign = 1
            if (projectile.sign == 1)
            {
                #region hitbox
                if (animations[animation].animations[frameIndex] != Rectangle.Empty)
                {
                    projectile.HitBox = new Rectangle((int)(
                        //position
                    projectile.Position.X + Stage.position
                        //center around position
                    - (currentFrameWidth - decal) / 2
                    ),

                    (int)(
                    -scale * animations[animation].animations[frameIndex].Height
                    + projectile.Position.Y),

                    animations[animation].animations[frameIndex].Width * (int)scale,

                    animations[animation].animations[frameIndex].Height * (int)scale);
                }
                #endregion

                #region GuardProcBox
                if (animations[animation].guardProcBox[frameIndex] != Rectangle.Empty)
                {
                    projectile.GuardProcBox = new Rectangle((int)(
                        //position
                    projectile.Position.X + Stage.position
                        //hurtbox x coordinate in frame reference
                    + scale * (animations[animation].guardProcBox[frameIndex].X - animations[animation].animations[frameIndex].X)
                        //center around position
                    - (currentFrameWidth - decal) / 2
                    ),

                    (int)(scale * animations[animation].guardProcBox[frameIndex].Y
                    - scale * animations[animation].animations[frameIndex].Y
                    - scale * animations[animation].animations[frameIndex].Height
                    + projectile.Position.Y),

                    animations[animation].guardProcBox[frameIndex].Width * (int)scale,

                    animations[animation].guardProcBox[frameIndex].Height * (int)scale);
                }
                else
                    projectile.GuardProcBox = new Rectangle(0, 0, 0, 0);
                #endregion
            }
            #endregion

            #region sign = -1
            else if (projectile.sign == -1)
            {
                #region hitBox
                if (animations[animation].hitBox[frameIndex] != Rectangle.Empty)
                {
                    projectile.HitBox = new Rectangle((int)(
                        //position
                    +projectile.Position.X + Stage.position
                        //hurtbox x coordinate in frame reference
                    - scale * (animations[animation].hitBox[frameIndex].X - animations[animation].animations[frameIndex].X + animations[animation].hitBox[frameIndex].Width)
                        //center around current position
                    + (currentFrameWidth - decal) / 2
                    ),

                    (int)(scale * animations[animation].hitBox[frameIndex].Y
                    - scale * animations[animation].animations[frameIndex].Y
                    - scale * animations[animation].animations[frameIndex].Height
                    + projectile.Position.Y),

                    animations[animation].hitBox[frameIndex].Width * (int)scale,

                    animations[animation].hitBox[frameIndex].Height * (int)scale);
                }
                else
                    projectile.HitBox = new Rectangle(0, 0, 0, 0);
                #endregion

                #region guardProcBox
                if (animations[animation].guardProcBox[frameIndex] != Rectangle.Empty)
                {
                    projectile.GuardProcBox = new Rectangle((int)(
                        //position
                    +projectile.Position.X + Stage.position
                        //hurtbox x coordinate in frame reference
                    - scale * (animations[animation].guardProcBox[frameIndex].X - animations[animation].animations[frameIndex].X + animations[animation].guardProcBox[frameIndex].Width)
                        //center around current position
                    + (currentFrameWidth - decal) / 2
                    ),

                    (int)(scale * animations[animation].guardProcBox[frameIndex].Y
                    - scale * animations[animation].animations[frameIndex].Y
                    - scale * animations[animation].animations[frameIndex].Height
                    + projectile.Position.Y),

                    animations[animation].guardProcBox[frameIndex].Width * (int)scale,

                    animations[animation].guardProcBox[frameIndex].Height * (int)scale);
                }
                else
                    projectile.GuardProcBox = new Rectangle(0, 0, 0, 0);
                #endregion
            }
            #endregion

            //frames may have different width
            decal = (int)(currentFrameWidth - firstFrameWidth);

            int x = (currentFrameWidth - decal) / 2;
            if (projectile.sign == -1)
                x = decal + (lastFrameWidth - decal) / 2 + (int)scale * (animations[animation].animations[frameIndex].Width/2);


                position = new Vector2(projectile.Position.X + Stage.position - x,
                                projectile.Position.Y - animations[animation].animations[frameIndex].Height * scale);
        }

        public void Displacement()
        {
            if(frameIndex<animations[animation].displacement.Count())
            {
                projectile.velocity += animations[animation].displacement[frameIndex];
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

        public Animation GetAnim()
        {
            return animations[animation];
        }

    }
}
