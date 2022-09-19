using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CrazyArcade.AWFrameWork
{
	public interface ISprite
	{
		Color Tint { get; set; }
		Rectangle Frame { get; set; }
		Rectangle InputFrame { get; }
		IScene SuperScene {get; set;}
		Texture2D Graphics { get; }
		public void Load();
		public void Update(GameTime time);
        public void RemoveFromScene();
	}
}

