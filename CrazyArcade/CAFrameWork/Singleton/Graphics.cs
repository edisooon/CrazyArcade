using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CrazyArcade.CAFrameWork.Singleton
{
	public static class Graphics
	{
		public static ContentManager Content;
		private static Texture2D character;
        public static Texture2D Character
		{
			get
			{
                if (character == null)
                {
					character = Content.Load<Texture2D>("Character");
                }
				return character;
            }
		}
        private static Texture2D sandGround;
        public static Texture2D SandGround
        {
            get
            {
                if (sandGround == null)
                {
                    sandGround = Content.Load<Texture2D>("SandGround");
                }
                return sandGround;
            }

        }
    }
}

