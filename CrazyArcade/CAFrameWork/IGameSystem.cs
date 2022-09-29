using System;
using CrazyArcade.CAFrameWork;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.CAFramework
{
	public interface IGameSystem
	{
        void Update(GameTime time);
        void AddSprite(IEntity sprite);
		void RemoveSprite(IEntity sprite);
        void RemoveAll();
    }
}

