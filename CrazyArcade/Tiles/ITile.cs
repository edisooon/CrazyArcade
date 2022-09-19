using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.Tiles
{
    internal interface ITile
    {
        public Vector2 position { get; set; }

        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch, float X, float Y);
    }
}
