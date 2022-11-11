using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using CrazyArcade.GameGridSystems;

namespace CrazyArcade.Boss
{
	public class SunBoss: CAEntity, ISunBossDelegate, IGridable
	{
        //----------------Test purpose-------------------
        ITimer timer;
        //-----------------------------------------------
        ISceneDelegate sceneDelegate;
        private float unitSize = 44/40;
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

        private int health = 2;
        public bool IsDead => Health <= 0;
        public int Health => health;

        public Rectangle Range => new Rectangle(0, 0, 11, 11);

        public override void Load()
        {
            states = new SunBossStartStates(this, new GameTime());
        }

        public override void Update(GameTime time)
        {
            //----------------Test purpose-------------------
            if (timer == null)
            {
                timer = new CATimer(time.TotalGameTime);
            }
            timer.Update(time.TotalGameTime);
            //-----------------------------------------------
            base.Update(time);
            states = states.Update(time);
        }

        public bool DidGetDemaged()
        {
            //----------------Test purpose-------------------
            if (timer.TotalMili > 4000)
            {
                timer = null;
                return true;
            }
            return false;
            //-----------------------------------------------
        }

        public Vector2 GetCharacterRelativePosition()
        {
            return GetCharacterPosition() - this.GetCenter();
        }

        public Vector2 GetCharacterPosition()
        {
            if (SceneDelegate.PlayerPositions.Count > 0)
            {
                return SceneDelegate.PlayerPositions[0];
            }
            return new Vector2();
        }

        public bool Move(Vector2 distance)
        {
            if (Range.Contains(this.GameCoord + distance))
            {
                this.GameCoord += distance;
                return true;
            }
            return false;
        }

        public ISceneDelegate Command()
        {
            return sceneDelegate;
        }

        public Vector2 GetCenter()
        {
            return new Vector2(GameCoord.X + unitSize / 2, GameCoord.Y + unitSize / 2);
        }

        public void DecreaseHealth()
        {
            health--;
        }
        public void Dead()
        {
            SceneDelegate.ToRemoveEntity(this);
        }
    }
}

