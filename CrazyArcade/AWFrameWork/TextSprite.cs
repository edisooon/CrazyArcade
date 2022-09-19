using System;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.AWFrameWork
{
	public class TextSprite: AWSprite
	{
        private String text;
        public String Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }
        private SpriteFont font;
        public SpriteFont Font
        {
            get
            {
                return font;
            }
        }

        public override Texture2D Graphics => throw new NotImplementedException();

        public TextSprite(String text, SpriteFont font)
		{
            this.text = text;
            this.font = font;
		}

        public override void Load()
        {
            
        }
    }
}

