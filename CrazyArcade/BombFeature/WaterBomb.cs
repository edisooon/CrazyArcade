using CrazyArcade.Blocks;
using CrazyArcade.Boss;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.GridBoxSystem;
using CrazyArcade.CAFrameWork.SoundEffectSystem;
using CrazyArcade.Content;
using CrazyArcade.Demo1;
using CrazyArcade.GameGridSystems;
using CrazyArcade.PlayerStateMachine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
        private SpriteAnimation spriteAnims;
        private Dir direction = Dir.Down;
        private Point[] moveDir = new Point[4] { new Point(0, -1), new Point(-1, 0), new Point(0, 1), new Point(1, 0) };
        private float speed = 10;
        private Vector2[] move;
        private bool isMoving = false;
        IBombCollectable owner;
        public override SpriteAnimation SpriteAnim => spriteAnims;
        public HashSet<IPlayerCollisionBehavior> hasNotLeft;

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

        private static Vector2 getBombPosition(Vector2 grid)
        {
            Vector2 bombPosition = grid;
            bombPosition = bombPosition + new Vector2(0.5f);
            bombPosition.Floor();
            return bombPosition;
        }
        
        public WaterBomb(Vector2 grid, int BlastLength, IBombCollectable character) : base(new GridBoxPosition(getBombPosition(grid), (int)GridObjectDepth.Box))
        {
            gamePos = getBombPosition(grid);

            this.BlastLength = BlastLength;
            this.owner = character;
            AnimationFrames = GetAnimationFrames();
            DetonateTime = 0;
            DetonateTimer = 3000;
            this.spriteAnims = new SpriteAnimation(TextureSingleton.GetBallons(), AnimationFrames, 8);
            this.spriteAnims.Scale = 35f / 42f;
            this.spriteAnims.Position = new Vector2(0, 4);
            internalRectangle = new Rectangle(X, Y, 40, 40);
            move = new Vector2[4] { new Vector2(0, -speed), new Vector2(-speed, 0), new Vector2(0, speed), new Vector2(speed, 0) };
        }

        public WaterBomb(Vector2 grid, int BlastLength, IBombCollectable character,Boolean iAmOctopus) : base(new GridBoxPosition(getBombPosition(grid), (int)GridObjectDepth.Box))
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
            move = new Vector2[4] { new Vector2(0, -speed), new Vector2(-speed, 0), new Vector2(0, speed), new Vector2(speed, 0) };
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
            if(this.isMoving) updatePosition(time);
            Detonate(time);
        }

        private void updatePosition(GameTime time)
        {
            float gameCoordMove = speed / CAGameGridSystems.BlockLength;
            if (length-gameCoordMove> 0)
            {
                GameCoord += Trans.RevScale(move[(int)direction]);
                length -= gameCoordMove;
            } else
            {
                this.isMoving = false;
                GameCoord = new Vector2(Position.X, Position.Y);
                length = -1;
            }
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
                SceneDelegate.ToAddEntity(new CASoundEffect("SoundEffects/BossExplosion"));
                detector.Ignite(this);
            }
            else
            {
                DetonateTime += (float)time.ElapsedGameTime.TotalMilliseconds;
            }
        }

        private bool isColliding(IPlayerCollisionBehavior collisionPartner)
        {
            Rectangle checkRectangle = Rectangle.Intersect(this.boundingBox, collisionPartner.blockCollisionBoundingBox);
            return checkRectangle.Width != 0 || checkRectangle.Height != 0;
        }

        public void UpdateHasNotLeft(List<IPlayerCollisionBehavior> playerBehaviors)
        {   
            if(hasNotLeft == null)
            {
                InitializeHasNotLeft(playerBehaviors);
            }
            else
            {
                foreach(IPlayerCollisionBehavior playerBehavior in hasNotLeft)
                {
                    if (!isColliding(playerBehavior)) hasNotLeft.Remove(playerBehavior);
                }
            }
        }

        private void InitializeHasNotLeft(List<IPlayerCollisionBehavior> playerBehaviors)
        {
            hasNotLeft = new HashSet<IPlayerCollisionBehavior>();
            foreach(IPlayerCollisionBehavior playerBehavior in playerBehaviors)
            {
                if (isColliding(playerBehavior)) hasNotLeft.Add(playerBehavior);
            }
        }
        private float length = -1;  // due to the do while loop in kick
        private void kick(Dir dir)
        {
            this.isMoving = true;
            Point mdir = moveDir[(int)dir];
            GridBoxPosition gridP = Position;
            do
            {
                length++;
                gridP.X += mdir.X;
                gridP.Y += mdir.Y;
            } while (manager.MoveBoxTo(this, gridP));
            Console.WriteLine(length);
        }
        private bool couldMove(Dir dir, GridBoxPosition initialPos)
        {
            Point mdir = moveDir[(int)dir];
            return manager.CheckAvailable(new GridBoxPosition(initialPos.X + mdir.X, initialPos.Y + mdir.Y, (int)GridObjectDepth.Box))==null;
        }

        public void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            if (hasNotLeft.Contains(collisionPartner)) return;
            this.direction = (collisionPartner as Character).direction;
            if (collisionPartner.CouldKick && couldMove(direction, this.Position))
            {
                kick(direction);
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