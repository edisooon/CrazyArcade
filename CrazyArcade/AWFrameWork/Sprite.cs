using System;
namespace AWFrameWork
{
	public interface Sprite
	{
		Color Tint { get; set; }
		Rectangle Frame { get; set; }
		Rectangle InputFrame { get; }
		Scene SuperScene {get; set;}
		Texture2D Graphics { get; }
		public void Load();
		public void Update(GameTime time);
        public void RemoveFromScene();
		public void click(MouseState state);
	}
}

