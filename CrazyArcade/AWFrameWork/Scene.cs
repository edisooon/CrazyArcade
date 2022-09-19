using System;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CrazyArcade.AWFrameWork
{
	public interface IScene
	{
		SpriteBatch Batch { get; set; }
        public void Load();
		public void Update(GameTime time, KeyboardState kstate, MouseState mstate);
        public void Draw(GameTime time);
		public void AddSprite(ISprite s);
		public void Remove(ISprite s);
		public void RemoveAllSprite();
    }
}

