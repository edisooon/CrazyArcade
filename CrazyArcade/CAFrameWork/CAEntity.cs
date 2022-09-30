using System;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.CAFramework
{
	public abstract class CAEntity: IEntity
	{

        // for each entity, it has to have a position and animations of sprite
        protected int X, Y;
        public abstract SpriteAnimation SpriteAnim { get; }

        public abstract void Load();
        public virtual void Update(GameTime time)
        {
            // handled animation updated (position and frame) in abstract level
            SpriteAnim.Position = new Vector2(X, Y);
            SpriteAnim.Update(time);
        }
        public void Draw(GameTime time, SpriteBatch batch)
        {
            SpriteAnim.Position.X = X;
            SpriteAnim.Position.Y = Y;
            SpriteAnim.Draw(batch);
            SpriteAnim.Update(time); 
        }
    }
}

