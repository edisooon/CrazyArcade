using System;
using CrazyArcade.Blocks;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrazyArcade.GameGridSystems;
using CrazyArcade.BombFeature;
using CrazyArcade.CAFrameWork.GridBoxSystem;
using CrazyArcade.EnemyCollision;

namespace CrazyArcade.Enemies
{
    public abstract class Enemy: CAEntity, IPlayerCollidable, IGridable, IExplosionCollidable, IEnemyCollisionBehavior
    {
        public SpriteAnimation[] spriteAnims;
        public SpriteAnimation spriteAnim;
        public CAScene scene;
        public Dir direction;
        protected float xDifference;
        protected float yDifference;
        protected SpriteEffects effect;
        protected Vector2 Start;
        //----------IGridable Start------------
        private Vector2 gamePos;
        private Vector2 pos;
        public IEnemyState state;
        public SpriteAnimation deathAnimation;
        private float timer;
        protected int fps = 10;
        public IGridBoxManager gridBoxManager;
        protected Rectangle blockBoundingBox = new Rectangle(0, 0, 30, 30);
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
            get => trans; set
            {
                trans = value;
                ScreenCoord = value.Trans(GameCoord);
                X = (int)ScreenCoord.X;
                Y = (int)ScreenCoord.Y;
                internalRectangle.X = X;
                internalRectangle.Y = Y;
                blockBoundingBox.X = X;
                blockBoundingBox.Y = Y;


            }
        }
        //----------IGridable End------------
        public Enemy(int x, int y, CAScene scene)

        {
            timer = 0;
            this.scene = scene;
            GameCoord = new Vector2(x, y - 2);
            Start = GameCoord;
            state = new EnemyDownState(this);
            
        }
        protected Rectangle internalRectangle = new Rectangle(0, 0, 30, 30);

        public Rectangle boundingBox => internalRectangle;

        public void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            collisionPartner.CollisionDestroyLogic();

        }
        public override void Update(GameTime time)
        {

            // handled animation updated (position and frame) in abstract level

            SpriteAnim.Position = new Vector2(X, Y);
            SpriteAnim.setEffect(effect);
            xDifference = GameCoord.X - Start.X;
            yDifference = GameCoord.Y - Start.Y;

            if (timer > 1f / 6)
            {

                state.Update(time);
                timer = 0;
            }
            else
            {
                timer += (float)time.ElapsedGameTime.TotalMilliseconds;
            }
            internalRectangle.X = X;
            internalRectangle.Y = Y;
            blockBoundingBox.X = X;
            blockBoundingBox.Y = Y;
        }

        protected abstract Vector2[] SpeedVector { get; }
        public IGridBoxManager Manager { get => gridBoxManager; set => gridBoxManager = value; }

        public Rectangle BlockBoundingBox => blockBoundingBox;

        public void Move()
        {
            GameCoord += (SpeedVector[(int)direction]*.5f);
        }
        public void UpdateAnimation()
        {
            this.spriteAnims[(int)direction].Position = new Vector2(X, Y);
        }

        public bool Collide(IExplosion bomb)
        {
            state = new EnemyDeathState(this);
            return true;
        }
        //called by block
        public void TurnEnemy()
        {
            state.ChangeDirection();
            effect = direction == Dir.Right ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            UpdateAnimation();
        }
    }
}

