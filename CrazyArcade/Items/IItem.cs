using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.CAFramework;
using CrazyArcade.Blocks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CrazyArcade.GameGridSystems;

namespace CrazyArcade.Items
{
    //Interface made to catagorise those that implement it, items
    public interface IItem : IEntity
    {
        
    }
    public abstract class Item : CAEntity, IItem, IItemCollision, IGridable
    {
        //----------IGridable Start------------
        private Vector2 gamePos;
        private Vector2 pos;
        public Vector2 ScreenCoord
        {
            get => pos;
            set
            {
                pos = value;
                this.UpdateCoord(value);
            }
        }
        public void UpdateCoord(Vector2 value)
        {
            this.X = (int)value.X;
            this.Y = (int)value.Y;
            hitbox = new Rectangle((int)ScreenCoord.X, (int)ScreenCoord.Y, 36, 36);
        }
        public Vector2 GameCoord
        {
            get => gamePos;
            set
            {
                gamePos = value;
                ScreenCoord = trans.Trans(value);
            }
        }
        private IGridTransform trans = new NullTransform();
        
        public IGridTransform Trans
        {
            get => trans;
            set
            {
                trans = value;
                ScreenCoord = value.Trans(GameCoord);
                enabled = true;
            }
        }
        //----------IGridable End------------
        protected Rectangle hitbox;
        protected SpriteAnimation spriteAnimation;
        public Item(Vector2 position, Rectangle source, Texture2D texture, int frames, int fps)
        {
            spriteAnimation = new SpriteAnimation(texture, frames, fps);
            GameCoord = position;
        }

        public override SpriteAnimation SpriteAnim => this.spriteAnimation;
        public Rectangle itemHitbox => this.hitbox;

        private bool enabled = false;
        public bool Enabled => enabled;

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
            SceneDelegate.ToRemoveEntity(this);
        }
    }
}
