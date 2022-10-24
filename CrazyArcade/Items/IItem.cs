using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.CAFramework;
using CrazyArcade.Blocks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Items
{
    //Interface made to catagorise those that implement it, items
    public interface IItem : IEntity
    {
        
    }
    public abstract class Item : Block, IItem, IItemCollision
    {

        public Item(Rectangle destination, Rectangle source, Texture2D texture, int frames, int fps) : base(destination, source, texture, frames, fps)
        {
            spriteAnimation = new SpriteAnimation(texture, frames, fps);
            this.X = destination.X;
            this.Y = destination.Y;

        }

        public override SpriteAnimation SpriteAnim => this.spriteAnimation;
        public Rectangle itemHitbox => this.hitbox;

        public override void Update(GameTime time)
        {

        }
        public override void Load()
        {
        }

        public void DeleteSelf(IScene parentScene)
        {
            parentScene.RemoveSprite(this);
        }
    }
}
