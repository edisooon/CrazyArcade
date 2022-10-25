using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.CAFrameWork.Transition
{
	public interface ITransition
	{
		ITransitionCompleteHandler Handler { get; set; }
		void Update(GameTime time);
		void Draw(GameTime time, SpriteBatch batch);

    }
}

