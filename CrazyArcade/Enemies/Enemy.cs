using System;
using CrazyArcade.Blocks;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using CrazyArcade.GameGridSystems;
using CrazyArcade.BombFeature;

namespace CrazyArcade.Enemies
{
    public abstract class Enemy: CAEntity, IPlayerCollidable, IGridable, IExplosionCollidable
    {
        public SpriteAnimation[] spriteAnims;
        public SpriteAnimation spriteAnim;
        public  CAScene scene;
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
        public IGridTransform Trans { get => trans; set {
                trans = value;
                ScreenCoord = value.Trans(GameCoord);
                X = (int)ScreenCoord.X;
                Y = (int)ScreenCoord.Y;
                internalRectangle.X = X;
                internalRectangle.Y = Y;
            }
        }
        //----------IGridable End------------
        public Enemy(int x, int y, CAScene scene)

        {
            timer = 0;
            this.scene = scene;
            GameCoord = new Vector2(x, y-2);
            Start = GameCoord;
            
        }
        protected Rectangle internalRectangle = new Rectangle(0, 0, 30, 30);

        public Rectangle boundingBox => internalRectangle;

        public void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            collisionPartner.CollisionDestroyLogic();
            //To show the state only, this line of code needs to be moved once bomb -> enemy collision is implemented to CollisionDestroyLogic 
            //state = new EnemyDeathState(this);
            

        }
        public override void Update(GameTime time)
        {

            // handled animation updated (position and frame) in abstract level

            SpriteAnim.Position = new Vector2(X, Y);
            SpriteAnim.setEffect(effect);
            



            xDifference = GameCoord.X - Start.X;
            yDifference = GameCoord.Y - Start.Y;
            if (state != null)
            {
                state.Update(time);
            }
            if (timer > 1f / 6)
            {
                if (state is not EnemyDeathState)
                {
                    move(direction);
                }
                
                
                
                
                timer = 0;
            }
            else
            {
                timer += (float)time.ElapsedGameTime.TotalMilliseconds;
            }
            internalRectangle.X = X;
            internalRectangle.Y = Y;
        }
        private bool ChangeDir(Dir dir)
        {
            switch (dir)
            {
                case Dir.Right:
                    
                    return xDifference >= 4;
                    
                case Dir.Up:

                    return yDifference <= 0;

                case Dir.Down:
                    
                    return yDifference >= 4;
                case Dir.Left:
                    return xDifference <= 0;
            }
            return false;
        }

        protected abstract Vector2[] SpeedVector { get; }

        protected void move(Dir dir)
        {
            if (ChangeDir(dir))
            {
                direction = (Dir)((((int)dir) + 1) % 4);
                effect = direction == Dir.Right ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                UpdateAnimation(dir);
            }
            
                GameCoord += SpeedVector[(int)dir];
            
        }
        public void UpdateAnimation(Dir dir)
        {

            this.spriteAnims[(int)direction].Position = new Vector2(X, Y);
        }

        public void Collide(IExplosion bomb)
        {
            state = new EnemyDeathState(this);
        }
    }
}

