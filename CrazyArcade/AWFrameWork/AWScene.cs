using System;

namespace AWFrameWork
{
	public class AWScene : Scene
	{
        private List<Sprite> sprites = new List<Sprite>();
        private bool mouseDown = false;
        public AWScene()
		{

		}
        private SpriteBatch batch;
        public SpriteBatch Batch {
            get {
                return batch;
            }
            set
            {
                batch = value;
            }
        }

        public void AddSprite(Sprite sprite)
        {
            sprites.Add(sprite);
            sprite.SuperScene = this;
            sprite.Load();
        }

        public virtual void Draw(GameTime time)
        {
            foreach (Sprite sprite in sprites)
            {
                if (sprite is TextSprite)
                {
                    
                    TextSprite text = sprite as TextSprite;
                    Batch.DrawString(
                        text.Font,
                        text.Text,
                        new Vector2(text.Frame.X, text.Frame.Y),
                        text.Tint);
                } else
                {
                    Batch.Draw(sprite.Graphics, sprite.Frame, sprite.InputFrame, sprite.Tint);
                }
            }
        }

        public virtual void Load()
        {
            foreach (Sprite sprite in sprites)
            {
                sprite.Load();
            }
        }

        public void Remove(Sprite sprite)
        {
            sprites.Remove(sprite);
        }

        public void RemoveAllSprite()
        {
            while (sprites.Count > 0)
            {
                sprites.RemoveAt(0);
            } 
        }

        public virtual void Update(GameTime time, KeyboardState kstate, MouseState mstate)
        {
            foreach (Sprite sprite in sprites)
            {
                sprite.Update(time);
            }
            if (mouseDown && mstate.LeftButton == ButtonState.Released)
            {
                click(mstate);
            }
            mouseDown = mstate.LeftButton == ButtonState.Pressed;
        }
        public virtual void click(MouseState state)
        {
            foreach (Sprite sprite in sprites)
            {
                if (sprite.Frame.Contains(state.Position.X, state.Position.Y)) {
                    sprite.click(state);
                }
            }
        }
    }
}

