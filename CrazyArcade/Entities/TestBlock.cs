using CrazyArcade.Content;
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
    internal class TestBlock : IBlock
    {   
        public ISprite Sprite { get; set; }
        public Vector2 Position { get; set; }

        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Sprite.Draw(spriteBatch, gameTime, Position.X, Position.Y);
        }

        public TestBlock()
        {
            Position = new Vector2(50,50);
            Sprite = new StaticSprite(TestTextureSingleton.GetSpriteSheet(), 0, 0, 48, 48, 24, 24);
        }
    }
}
