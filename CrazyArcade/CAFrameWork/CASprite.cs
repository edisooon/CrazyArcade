using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.CAFramework
{
	public abstract class CASprite: ISprite
	{
        protected Point position;
        protected Texture2D texture;
        protected Color tint;
        public abstract Rectangle OutputFrame { get; } //frame on the screen
        public abstract Rectangle InputFrame { get; } //frame on the sprite sheet

        public void Draw(GameTime time, SpriteBatch batch)
        {
            batch.Draw(texture, OutputFrame, InputFrame, tint);
        }

        public abstract void Load();

        public abstract void Update(GameTime time);
    }
}

