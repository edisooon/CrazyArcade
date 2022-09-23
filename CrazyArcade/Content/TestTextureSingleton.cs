using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.Content
{
    public static class TestTextureSingleton
    {
        private static Texture2D spriteSheet;

        public static void LoadAllTextures(ContentManager content)
        {
            spriteSheet = content.Load<Texture2D>("Balloons");
        }

        public static Texture2D GetSpriteSheet()
        {
            return spriteSheet;
        }
    }
}
