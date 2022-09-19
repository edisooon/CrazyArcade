using System;
namespace AWFrameWork
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

