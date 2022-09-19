using System;
using System.Collections;

namespace AWFrameWork
{
	public interface Scene
	{
		SpriteBatch Batch { get; set; }
        public void Load();
		public void Update(GameTime time, KeyboardState kstate, MouseState mstate);
        public void Draw(GameTime time);
		public void AddSprite(Sprite s);
		public void Remove(Sprite s);
		public void RemoveAllSprite();
		protected void click(MouseState state);
    }
}

