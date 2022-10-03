using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Boss
{
	public class SunBoss: CAEntity, ISunBossDelegate
	{

        ISceneDelegate sceneDelegate;
        private float posX;
        private float posY;
        public float PosX
        {
            get
            {
                return posX;
            }
            set
            {
                posX = value;
                this.X = (int)posX;
            }
        }
        public float PosY
        {
            get
            {
                return posY;
            }
            set
            {
                posY = value;
                this.Y = (int)posY;
            }
        }
        public SunBoss(ISceneDelegate sceneDelegate)
		{
            this.sceneDelegate = sceneDelegate;
            this.PosX = 440;
            this.PosY = 220;
		}

        IStates states;
        public override List<SpriteAnimation> SpriteAnimList => states.Animation;

        public override void Load()
        {
            states = new SunBossStartStates(this, new GameTime());
        }

        public override void Update(GameTime time)
        {
            base.Update(time);
            //Console.Out.Write("update sun boss\n");
            states = states.Update(time);
        }

        public bool DidGetDemaged()
        {
            return false;
        }

        public Point GetCharacterRelativePosition()
        {
            return new Point(GetCharacterPosition().X - this.X,
                GetCharacterPosition().Y - this.Y);
        }

        public Point GetCharacterPosition()
        {
            Random rand = new Random();
            return new Point(350 + rand.Next(0, 100),
                150 + rand.Next(0, 50));
        }

        public void Move(Vector2 distance)
        {
            //Console.Out.Write(distance.X);
            //Console.Out.Write(distance.Y);
            this.PosX += distance.X;
            this.PosY += distance.Y;
        }

        public ISceneDelegate Command()
        {
            return sceneDelegate;
        }

        public Vector2 GetCenter()
        {
            return new Vector2(posX + 44, posY + 44);
        }
    }
}

