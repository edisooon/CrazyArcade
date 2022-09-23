using System;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFramework
{
	public interface IGameSystem
	{
		void AddSprite(ISprite sprite);
		bool RemoveSprite(ISprite sprite);
        void RemoveAll();
        void Update(GameTime time);
	}
}

