using CrazyArcade.Blocks;
using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using CrazyArcade.Demo1;
using CrazyArcade.GameGridSystems;
using CrazyArcade.PlayerStateMachine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.BombFeature
{
    public class WaterBomb : CAEntity, IPlayerCollidable, IExplosionCollidable, IExplodable
    {
        int BlastLength;
        float DetonateTimer;
        float DetonateTime;
        Boolean characterHasLeft = false;
        private SpriteAnimation spriteAnims;
        private static readonly Rectangle frame1 = new(11, 10, 42, 42);
        private static readonly Rectangle frame2 = new(56, 10, 42, 42);
        private static readonly Rectangle frame3 = new(97, 10, 46, 42);
        private static readonly int tileSize = 40;
        IBombCollectable owner;
        public override SpriteAnimation SpriteAnim => spriteAnims;

        public Rectangle internalRectangle;

        public Rectangle boundingBox => internalRectangle;

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
        private IGridTransform trans = new NullTransform();
        public IGridTransform Trans { get => trans; set => trans = value; }

        public void UpdateCoord(Vector2 value)
        {
            this.X = (int)value.X;
            this.Y = (int)value.Y;
            this.internalRectangle.X = (int)ScreenCoord.X;
            this.internalRectangle.Y = (int)ScreenCoord.Y;
        }

        public Vector2 GameCoord { get => gamePos; set => gamePos = value; }
        private IExplosionDetector detector;
        public IExplosionDetector Detector { get => detector; set => detector = value; }

        public int Distance => BlastLength;

        public Point Center => new Point((int) GameCoord.X, (int) GameCoord.Y);

        private bool canExplode = true;
        public bool CanExplode => canExplode;

        private Rectangle[] AnimationFrames;
        
        public WaterBomb(Vector2 grid, int BlastLength, IBombCollectable character)
        {

            Vector2 bombPosition = grid;
            bombPosition = bombPosition + new Vector2(0.5f);
            bombPosition.Floor();
            gamePos = bombPosition;

            this.BlastLength = BlastLength;
            this.owner = character;
            AnimationFrames = GetAnimationFrames();
            DetonateTime = 0;
            DetonateTimer = 3000;
            this.spriteAnims = new SpriteAnimation(TextureSingleton.GetBallons(), AnimationFrames, 8);
            internalRectangle = new Rectangle(X, Y, 40, 40);
        }
        private static Rectangle[] GetAnimationFrames()
        {
            Rectangle[] NewFrames = new Rectangle[3];
            NewFrames[0] = frame1;
            NewFrames[1] = frame2;
            NewFrames[2] = frame3;
            return NewFrames;
        }
        public override void Update(GameTime time)
        {
            if (!characterHasLeft) updateCharacterHasLeft();
            Detonate(time);
        }
        public override void Load()
        {
            //Nothing
        }
        private void DeleteSelf()
        {
            SceneDelegate.ToRemoveEntity(this);
        }
        private void Detonate(GameTime time)
        {
            if(DetonateTime > DetonateTimer)
            {
                DeleteSelf();
                owner.recollectBomb();
                detector.Ignite(this);
            }
            else
            {
                DetonateTime += (float)time.ElapsedGameTime.TotalMilliseconds;
            }
        }

        public void updateCharacterHasLeft()
        {
            //Rectangle checkRectangle = Rectangle.Intersect(this.boundingBox, owner.blockCollisionBoundingBox);
            //if (checkRectangle.Width == 0 || checkRectangle.Height == 0)
            //{
            //    characterHasLeft = true;
            //}
        }

        public void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            if (!characterHasLeft) return;
            int modifier = 1;
            if (overlap.Width > overlap.Height)
            {
                if (Y < collisionPartner.blockCollisionBoundingBox.Y) modifier = -1;
                collisionPartner.CollisionHaltLogic(new Point(0, modifier * overlap.Height));
            }
            else
            {
                if (X < collisionPartner.blockCollisionBoundingBox.X) modifier = -1;
                collisionPartner.CollisionHaltLogic(new Point(modifier * overlap.Width, 0));
            }
        }

        public IExplosion explode()
        {
            canExplode = false;
            owner.recollectBomb();
            return new Explosion(Center, Distance, this.SceneDelegate, this.trans);
        }

        public void Collide(IExplosion bomb)
        {
            detector.Ignite(this);
        }
    }
}
