using System;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFramework.Controller;
using CrazyArcade.Enemies;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CrazyArcade.GameGridSystems;
using CrazyArcade.Blocks;

namespace CrazyArcade.Boss
{
    public class OctopusEnemy : CAEntity, IGridable, IPlayerCollidable
    {
        public SpriteAnimation[] spriteAnims;
        public SpriteAnimation spriteAnim;
        private Texture2D texture;
        public CAScene scene;
        protected Vector2 Start;
        protected float xDifference;
        protected float yDifference;
        private Rectangle[] InputFramesRight;
        private Rectangle[] InputFramesLeft;
        private Rectangle[] InputFramesUp;
        private Rectangle[] InputFramesDown;
        private Dir[] dirList;
        protected SpriteEffects effect;
        private Color tint;
        public Dir direction;
        public Rectangle outputFrame1;

        protected Rectangle internalRectangle = new Rectangle(0, 0, 109, 145);

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
        public override SpriteAnimation SpriteAnim => spriteAnims[(int)direction];
        public Rectangle boundingBox => internalRectangle;

        public Rectangle inputFrame;

        public void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            collisionPartner.CollisionDestroyLogic();
            //To show the state only, this line of code needs to be moved once bomb -> enemy collision is implemented to CollisionDestroyLogic 

            //pseudo code:
            //if(collisionPartner is bomb blast){
            //  lower health;
            //  if(health<1){
            //      state = new EnemyDeathState(this);
            //  }
            //}
        }
        public OctopusEnemy(int x, int y, CAScene scene) : base()
        {
            timer = 0;
            this.scene = scene;
            GameCoord = new Vector2(x, y - 2);
            Start = GameCoord;
            X = x;
            Y = y;
            texture = TextureSingleton.GetOctoBoss();
            spriteAnims = new SpriteAnimation[4];
        }

        public override void Load()
        {
            direction = Dir.Down;
            dirList = new Dir[4];
            effect = SpriteEffects.None;
            texture = TextureSingleton.GetOctoBoss();
            InputFramesRight = new Rectangle[1];
            InputFramesUp = new Rectangle[1];
            InputFramesLeft = new Rectangle[1];
            InputFramesDown = new Rectangle[2];
            InputFramesRight[0] = new Rectangle(803, 21, 104, 148);
            InputFramesLeft[0] = new Rectangle(614, 23, 102, 144);
            InputFramesUp[0] = new Rectangle(421, 26, 107, 138);
            InputFramesDown[0] = new Rectangle(41, 23, 107, 144);
            InputFramesDown[1] = new Rectangle(231, 24, 108, 141);

            texture = TextureSingleton.GetOctoBoss();
            tint = Color.White;
            // public SpriteAnimation(Texture2D texture, int startX, int startY, int width, int height, int frames, int offset, int fps) 
            deathAnimation = new SpriteAnimation(texture, 1941, 43, 108, 104, 1, 0, 1);
            deathAnimation.setWidthHeight(108, 104);
            deathAnimation.Position = new Vector2(X, Y);
            this.spriteAnims[(int)Dir.Up] = new SpriteAnimation(texture, InputFramesUp, fps);
            this.spriteAnims[(int)Dir.Down] = new SpriteAnimation(texture, InputFramesDown, fps);
            this.spriteAnims[(int)Dir.Left] = new SpriteAnimation(texture, InputFramesLeft, fps);
            this.spriteAnims[(int)Dir.Right] = new SpriteAnimation(texture, InputFramesRight, fps);
            foreach (SpriteAnimation anim in this.spriteAnims)
            {
                anim.setWidthHeight(110, 145);
                anim.Position = new Vector2(X, Y);
            }
            spriteAnim = spriteAnims[(int)direction];
            deathAnimation = spriteAnim;
        }

        protected bool ChangeDir(Dir dir)
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
        protected Vector2[] SpeedVector => speedVector;
        protected void move(Dir dir)
        {
            if (ChangeDir(dir))
            {
                direction = (Dir)((((int)dir) + 1) % 4);
                //effect = direction == Dir.Left ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                UpdateAnimation(dir);
            }

            GameCoord += SpeedVector[(int)dir];

        }

        Vector2[] speedVector =
        {
            new Vector2(0.0f, -0.15f),
            new Vector2(-0.15f, 0.0f),
            new Vector2(0.0f, 0.15f),
            new Vector2(0.15f, 0.0f),
        };

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

        public void UpdateAnimation(Dir dir)
        {
            this.spriteAnims[(int)direction].Position = new Vector2(X, Y);
        }
    }
}