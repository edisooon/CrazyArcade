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
    public abstract class Item : CAEntity, IItem, IItemCollision
    {

        public Item(Vector2 position, Rectangle source, Texture2D texture, int frames, int fps) : base(position, source, texture, frames, fps)
        {
            spriteAnimation = new SpriteAnimation(texture, frames, fps);

        }

        public override SpriteAnimation SpriteAnim => this.spriteAnimation;
        public Rectangle itemHitbox => this.hitbox;

        public override void Update(GameTime time)
        {

        }
        public override void Load()
        {
        }
        public abstract void CollisionLogic(IItemCollidable collisionPartner);
        //Assumes that @this is in the IScene that is passed
        public void DeleteSelf(IScene parentScene)
        {
            parentScene.RemoveSprite(this);
        }
    }
}
