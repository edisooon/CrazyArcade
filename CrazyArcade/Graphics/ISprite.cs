using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.Graphics
{
    internal interface ISprite
    {
        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, float X, float Y);
    }
}
