using CrazyArcade.Blocks;
using CrazyArcade.Boss;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.GridBoxSystem;
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
    public class WaterBomb : CAGridBoxEntity, IPlayerCollidable, IExplosionCollidable, IExplodable, IBossCollidable
    {
        int BlastLength;

        float DetonateTimer;
        float DetonateTime;
        Boolean characterHasLeft = false;
        private SpriteAnimation spriteAnims;
        IBombCollectable owner;
        public override SpriteAnimation SpriteAnim => spriteAnims;

        public Rectangle internalRectangle;

        public Rectangle boundingBox => internalRectangle;
        //---------------Gridable Start------------------
        private Vector2 gamePos;
        private Vector2 pos;
        public override Vector2 ScreenCoord
        {
            get => pos;
            set
            {
                pos = value;
                this.UpdateCoord(value);
            }
        }
        private IGridTransform trans = new NullTransform();
        public override IGridTransform Trans { get => trans; set => trans = value; }

        public void UpdateCoord(Vector2 value)
        {
            this.X = (int)value.X;
            this.Y = (int)value.Y;
            this.internalRectangle.X = (int)ScreenCoord.X;
            this.internalRectangle.Y = (int)ScreenCoord.Y;
        }

        public override Vector2 GameCoord { get => gamePos; set => gamePos = value; }
        //---------------Gridable End------------------

        private IExplosionDetector detector;
        public IExplosionDetector Detector { get => detector; set => detector = value; }

        private bool canExplode = true;
        public bool CanExplode => canExplode;

        public Rectangle hitBox => new Rectangle(this.X, this.Y, 40, 40);

        private Rectangle[] AnimationFrames;
        
        public WaterBomb(Vector2 grid, int BlastLength, IBombCollectable character) : base(new GridBoxPosition(grid, (int)GridObjectDepth.Box))
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

        public WaterBomb(Vector2 grid, int BlastLength, IBombCollectable character, Boolean iAmOctopus) : base(new GridBoxPosition(grid, (int)GridObjectDepth.Box))
        {
            Vector2 bombPosition = grid;
            bombPosition = bombPosition + new Vector2(0.5f);
            bombPosition.Floor();
            gamePos = bombPosition;

            this.BlastLength = BlastLength;
            this.owner = character;
            AnimationFrames = GetAnimationFrames();
            DetonateTime = 0;
            DetonateTimer = 0;
            this.spriteAnims = new SpriteAnimation(TextureSingleton.GetBallons(), AnimationFrames, 8);
            internalRectangle = new Rectangle(X, Y, 40, 40);

            characterHasLeft = iAmOctopus;
        }


        private static Rectangle[] GetAnimationFrames()
        {
            Rectangle[] NewFrames = new Rectangle[3];
            NewFrames[0] = new Rectangle(11, 10, 42, 42);
            NewFrames[1] = new Rectangle(56, 10, 42, 42);
            NewFrames[2] = new Rectangle(97, 10, 46, 42);
            return NewFrames;
        }
        public override void Update(GameTime time)
        {
            if (!characterHasLeft) updateCharacterHasLeft();
            Detonate(time);
        }
        public override void Load()
        {
            owner.SpendBomb();
        }
        private void DeleteSelf()
        {
            SceneDelegate.ToRemoveEntity(this);
        }
        private void Detonate(GameTime time)
        {
            if(DetonateTime > DetonateTimer)
            {
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
            DeleteSelf();
            canExplode = false;
            return new Explosion(new Point((int)GameCoord.X, (int)GameCoord.Y), BlastLength, this.SceneDelegate, this.trans);
        }

        public override void Deload()
        {
            base.Deload();
            owner.RecollectBomb();
        }
        public bool Collide(IExplosion bomb)
        {
            detector.Ignite(this);
            return false;
        }

        public void Collide(IBossCollideBehaviour boss)
        {
            if (boss is SunBoss)
            {
                SceneDelegate.ToRemoveEntity(this);
            }
        }
    }
}