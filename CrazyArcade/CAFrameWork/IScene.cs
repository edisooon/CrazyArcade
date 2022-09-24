using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.CAFramework
{
	public interface IScene
    {
        void Load();
        void Update(GameTime time);
        void Draw(GameTime time, SpriteBatch batch);
        void AddSprite(ISprite sprite);
        void RemoveSprite(ISprite sprite);
        void RemoveAllSprite();
    }
}

