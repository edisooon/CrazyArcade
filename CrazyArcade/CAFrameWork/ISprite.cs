using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.CAFramework
{
	public interface ISprite
	{
        void Load();
        void Update(GameTime time);
        void Draw(GameTime time, SpriteBatch batch);
    }
}

