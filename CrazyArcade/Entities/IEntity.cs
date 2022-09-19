using CrazyArcade.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.Entities
{
    internal interface IEntity
    {
        public Vector2 Position {get; set;}

        public ISprite Sprite { get; set; }

        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
