using System;
using CrazyArcade.Blocks;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrazyArcade.GameGridSystems;
using CrazyArcade.BombFeature;
using CrazyArcade.CAFrameWork.GridBoxSystem;
using CrazyArcade.EnemyCollision;
using System.Runtime.CompilerServices;

namespace CrazyArcade.Enemies
{
    public abstract class Enemy: EnemyEntity, IPlayerCollidable, IGridable, IExplosionCollidable, IEnemyCollisionBehavior
    {
        public SpriteAnimation[] spriteAnims;
        public SpriteAnimation spriteAnim;
        public Dir direction;
        protected SpriteEffects effect;
        protected Vector2 Start;
        private readonly float CenterEnemyValue;
        private Vector2 gamePos;
        private Vector2 pos;
        public IEnemyState state;
        public SpriteAnimation deathAnimation;
        private float timer;
        protected int fps = 10;
        public IGridBoxManager gridBoxManager;
        protected const int EnemySize = 30;
        Rectangle blockDetector = new(0, 0, 1, 2*(EnemySize/3));
        public int XDetectionOffset;
        public int YDetectionOffset;
        public int turnFLag = 0;
        private readonly float blockSize = 36;
        //----------IGridable Start------------
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

            }
        }
        //----------IGridable End------------

        //
        public Enemy(int x, int y)
        {   
            
            //36 is the size of each block
            CenterEnemyValue = ((1f - (float)EnemySize / blockSize)) / 2f;
            timer = 0;
            GameCoord = new Vector2(CenterEnemyValue + (float)x, CenterEnemyValue + (float)y);
            Start = GameCoord;
            state = new EnemyDownState(this);
            
        }
        
        protected Rectangle internalRectangle = new(0, 0, EnemySize, EnemySize);
        //player collision

        public Rectangle boundingBox => internalRectangle;
        //player collision
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
            internalRectangle.X = X;
            internalRectangle.Y = Y;
            blockDetector.X = X + XDetectionOffset;
            blockDetector.Y = Y + YDetectionOffset;

            if (timer > 1f / 6)
            {

                state.Update(time);
                timer = 0;
            }
            else
            {
                timer += (float)time.ElapsedGameTime.TotalMilliseconds;
            }
            
        }

        protected abstract Vector2[] SpeedVector { get; }
        public IGridBoxManager Manager { get => gridBoxManager; set => gridBoxManager = value; }

        public Rectangle BlockBoundingBox => blockDetector;

        public void Move()
        {
            if (turnFLag == 0)
            {
                // This stop enemy from moving right after turning.
                GameCoord += (SpeedVector[(int)direction] * .6f);
            }
            else
            {
                turnFLag = 0;
            }
            
        }

        public void SetDetectorValues(int xOffset,int yOffset,int width,int height)
        {
            //These values change the location of block detection blocks. The block is always in front of the enemy sprite
            XDetectionOffset = xOffset;
            YDetectionOffset = yOffset;
            blockDetector.Width = width;
            blockDetector.Height = height;  
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
            // This stop enemy from moving right after turning
            turnFLag = 1;
            
        }
        public virtual void ShootProjectile(GameTime time)
        {
            //default is empty
        }
    }
}

