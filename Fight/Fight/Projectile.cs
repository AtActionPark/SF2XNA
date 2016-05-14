using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Fight.Animations;
using Microsoft.Xna.Framework.Graphics;

namespace Fight
{
    public enum ProjState { Moving, Dying }

    public class Projectile
    {
        public Vector2 Position;
        public Vector2 velocity = new Vector2(5,0);
        public ProjectileAnimationManager animManager;
        public Fighter fighter;
        public bool toRemove;
        public bool removed;
        public int sign;
        public Rectangle HitBox;
        public Rectangle GuardProcBox;
        ProjState state;
        public ProjAttackState projAttackState;
        

        public Projectile(Fighter fighter)
        {
            this.fighter = fighter;
            sign = fighter.sign;
            Position = new Vector2(fighter.Position.X, fighter.Position.Y) + (sign == 1 ? new Vector2(100, -80) : new Vector2(-100, -80));
            SetAnims();
            projAttackState = new ProjAttackState();
            projAttackState.strength = fighter.buffer.strength;
            projAttackState.Update();
        }

        public void Update(GameTime gameTime)
        {
            animManager.Update(gameTime);
            if(!toRemove)
                Position += projAttackState.velocity*sign;
            if (Position.X > 800 - Stage.position || Position.X < 0 - Stage.position)
                removed = true;

            if (state == ProjState.Dying && animManager.animEnded)
            {
                removed = true;
            }


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Static.drawHitbox)
            {
                spriteBatch.Draw(Art.WhitePixel, GuardProcBox, Color.DarkRed);
                spriteBatch.Draw(Art.WhitePixel, HitBox, Color.Red);
            }
            animManager.Draw(spriteBatch);
        }

        public void Die()
        {
            toRemove = true;
            
            animManager.ResetFrameCount();
            animManager.animation = "die";
            state = ProjState.Dying;

            Position.Y += 20;
            if (sign == -1)
                Position.X += 10;
            //Position.X += 20 * sign;
            animManager.Update(Static.staticGameTime);
           
        }

        public void SetAnims()
        {
            animManager = new ProjectileAnimationManager(Art.Ryu, 10, 10, this);
            animManager.timeToUpdate = 0.1f;
            animManager.position = Position;
            animManager.isLooping = true;

            animManager.AddAnimation("move", new MovingHadoAnim());
            animManager.AddAnimation("die", new DyingHadoAnim());
            animManager.animation = "move";
        }
    }
}
