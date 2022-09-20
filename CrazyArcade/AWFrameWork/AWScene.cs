using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CrazyArcade.AWFrameWork
{
	public class AWScene : IScene
	{
        protected List<ISprite> sprites = new List<ISprite>();
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

        public void AddSprite(ISprite ISprite)
        {
            Console.Out.Write("added");
            sprites.Add(ISprite);
            ISprite.SuperScene = this;
            ISprite.Load();
        }

        public virtual void Draw(GameTime time)
        {
            foreach (ISprite ISprite in sprites)
            {
                if (ISprite is TextSprite)
                {
                    
                    TextSprite text = ISprite as TextSprite;
                    Batch.DrawString(
                        text.Font,
                        text.Text,
                        new Vector2(text.Frame.X, text.Frame.Y),
                        text.Tint);
                } else
                {
                    Batch.Draw(ISprite.Graphics, ISprite.Frame, ISprite.InputFrame, ISprite.Tint);
                }
            }
        }

        public virtual void Load()
        {
            foreach (ISprite ISprite in sprites)
            {
                ISprite.Load();
            }
        }

        public void Remove(ISprite ISprite)
        {
            sprites.Remove(ISprite);
        }

        public void RemoveAllSprite()
        {
            while (sprites.Count > 0)
            {
                sprites.RemoveAt(0);
            } 
        }

        public virtual void Update(GameTime time)
        {
            foreach (ISprite ISprite in sprites)
            {
                ISprite.Update(time);
            }
        }
    }
}

