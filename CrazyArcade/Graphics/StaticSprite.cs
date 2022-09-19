using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.Graphics
{
    internal class StaticSprite : ISprite
    {
        Texture2D spriteSheet;
        int startDrawX;
        int startDrawY;
        int height;
        int width;
        int xOff;
        int yOff;
        public void Update(GameTime gameTime)
        {
            //unused
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, float X, float Y)
        {
            spriteBatch.Draw(spriteSheet, new Vector2(X - xOff, Y - yOff), new Rectangle(startDrawX, startDrawY, width, height), Color.White);
        }
        public StaticSprite(Texture2D spriteSheet, int startDrawX, int startDrawY, int height, int width, int xOff, int yOff)
        {
            this.spriteSheet = spriteSheet;
            this.startDrawX = startDrawX;
            this.startDrawY = startDrawY;
            this.height = height;
            this.width = width;
            this.xOff = xOff;
            this.yOff = yOff;
        }
    }
}
