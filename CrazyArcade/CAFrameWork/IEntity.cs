using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.CAFrameWork
{
    public interface IEntity
    {
        void Load();
        void Update(GameTime time);
        void Draw(GameTime time, SpriteBatch batch);
    }
}

