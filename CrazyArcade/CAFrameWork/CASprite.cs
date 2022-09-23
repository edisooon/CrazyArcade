using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.CAFramework
{
	public abstract class CASprite: ISprite
	{
        public abstract Texture2D Texture { get; }
        public abstract Rectangle InputFrame { get; } //frame on the sprite sheet
        public abstract Rectangle OutputFrame { get; } //frame on the screen
        public abstract Color Tint { get; }
        public CASprite()
		{

		}

        public void Draw(GameTime time, SpriteBatch batch)
        {
            batch.Draw(Texture, OutputFrame, InputFrame, Tint);
        }

        public virtual void Load()
        {

        }

        public abstract void Update(GameTime time);
    }
}

