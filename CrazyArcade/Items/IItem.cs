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
using CrazyArcade.BombFeature;

namespace CrazyArcade.Items
{
    //Interface made to catagorise those that implement it, items
    public interface IItem : IEntity
    {

    }
    public abstract class Item : CAEntity, IItem, IGridable, IExplosionCollidable, IPlayerCollidable
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
            }
        }
        //----------IGridable End------------
        protected Rectangle hitbox;
        protected SpriteAnimation spriteAnimation;
        protected ISceneDelegate parentScene;
        public Item(ISceneDelegate parentScene, Vector2 position, Rectangle source, Texture2D texture, int frames, int fps)
        {
            this.parentScene = parentScene;
            spriteAnimation = new SpriteAnimation(texture, frames, fps);
            spriteAnimation.Scale = 0.6f;
            GameCoord = position;
        }

        public override SpriteAnimation SpriteAnim => this.spriteAnimation;

        public Rectangle boundingBox => this.hitbox;

        public override void Update(GameTime time)
        {

        }
        public override void Load()
        {
        }
        //Assumes that @this is in the IScene that is passed
        public void DeleteSelf(ISceneDelegate parentScene)
        {
            parentScene.ToRemoveEntity(this);
        }

        public bool Collide(IExplosion bomb)
        {
            DeleteSelf(parentScene);
            return true;
        }

        public abstract void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner);
    }
}