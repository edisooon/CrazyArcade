using System;
using CrazyArcade.Blocks;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using CrazyArcade.GameGridSystems;

namespace CrazyArcade.Enemies
{
    public abstract class Enemy: CAEntity, IPlayerCollidable, IGridable
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
            state = new EnemyDownState(this);
        }
        protected Rectangle internalRectangle = new Rectangle(0, 0, 30, 30);

        public Rectangle boundingBox => internalRectangle;

        public void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            collisionPartner.CollisionDestroyLogic();
            //To show the state only, this line of code needs to be moved once bomb -> enemy collision is implemented to CollisionDestroyLogic 
            state = new EnemyDeathState(this);
            

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
                
            }
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
        }
        //checks if the sprite needs to change direction based on the location of the sprite. This will need to be replaced later with a function that checks if enemy collides with a block, it should move direction.
        private bool ChangeDir()
        {
            switch (direction)
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

        public void move()
        {
            //Temporary and need to be removed later after enemy movement fully implemented with block collision
            if (ChangeDir())
            {
                state.ChangeDirection();
                effect = direction == Dir.Right ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                UpdateAnimation();
            }
            //up to here
            GameCoord += SpeedVector[(int)direction];
            
        }
        public void UpdateAnimation()
        {

            this.spriteAnims[(int)direction].Position = new Vector2(X, Y);
        }
    }
}

