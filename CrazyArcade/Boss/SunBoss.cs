using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using CrazyArcade.GameGridSystems;
using CrazyArcade.BombFeature;

namespace CrazyArcade.Boss
{
	public class SunBoss: CAEntity, ISunBossDelegate, IGridable, IExplosionCollidable
	{

        ISceneDelegate sceneDelegate;
        private float unitSize = 44/40;
        private int lives = 3;
        public SunBoss(ISceneDelegate sceneDelegate)
		{
            this.sceneDelegate = sceneDelegate;
            this.GameCoord = new Vector2(5, 5);
		}

        IStates states;
        public override List<SpriteAnimation> SpriteAnimList => states.Animation;

        private Vector2 gamePos;
        private Vector2 pos;
        public Vector2 ScreenCoord
        {
            get => pos;
            set
            {
                pos = value;
                this.X = (int)value.X;
                this.Y = (int)value.Y;
            }
        }
        public Vector2 GameCoord { get => gamePos; set => gamePos = value; }
        private IGridTransform trans = new NullTransform();
        public IGridTransform Trans { get => trans; set => trans = value; }

        public override void Load()
        {
            states = new SunBossStartStates(this, new GameTime());
        }

        public override void Update(GameTime time)
        {
            base.Update(time);
            states = states.Update(time);
        }

        public bool DidGetDemaged()
        {
            return false;
        }

        public Vector2 GetCharacterRelativePosition()
        {
            return GetCharacterPosition() - this.gamePos;
        }

        public Vector2 GetCharacterPosition()
        {
            Random rand = new Random();
            return new Vector2(5 + (float)rand.Next(0, 100) / 100,
                5 + (float)rand.Next(0, 100) / 100);
        }

        public void Move(Vector2 distance)
        {
            this.GameCoord += distance;
        }

        public ISceneDelegate Command()
        {
            return sceneDelegate;
        }

        public Vector2 GetCenter()
        {
            return new Vector2(GameCoord.X + unitSize, GameCoord.Y + unitSize);
        }

        public void DeleteSelf()
        {
            sceneDelegate.ToRemoveEntity(this);
        }

        public void Collide(IExplosion bomb)
        {
            if (--lives == 0) DeleteSelf();
            this.SpriteAnim.Color = Color.Red;
        }
    }
}

