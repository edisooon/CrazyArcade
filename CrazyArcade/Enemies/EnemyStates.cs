using CrazyArcade.CAFramework;
using CrazyArcade.PlayerStateMachine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using static System.Formats.Asn1.AsnWriter;

namespace CrazyArcade.Enemies
{
    public interface IEnemyState
    {
        void ChangeDirection();
        void Update(GameTime time);
    }
    public class EnemyLeftState : IEnemyState
    {
        private readonly Enemy enemy;
        public ISceneDelegate scene;

        public EnemyLeftState(Enemy enemy)
        {
            this.enemy = enemy;
            scene = enemy.SceneDelegate;
            enemy.direction = Dir.Left;
            enemy.SetDetectorValues(0, 10, 1, 10);
        }
        public void ChangeDirection()
        {
            Random rnd = new Random();
            int num = rnd.Next();
            if (num % 2 == 0)
            {
                enemy.state = new EnemyDownState(enemy);
            }
            else
            {
                enemy.state = new EnemyRightState(enemy);
            }
            
        }

        public void Update(GameTime time)
        {

            enemy.Move();
        }
    }
    public class EnemyRightState : IEnemyState
    {
        private readonly Enemy enemy;
        public ISceneDelegate scene;
        public EnemyRightState(Enemy enemy)
        {
            this.enemy = enemy;
            scene = enemy.SceneDelegate;
            enemy.direction = Dir.Right;
            enemy.SetDetectorValues(29, 10, 1, 10);

        }
        public void ChangeDirection()
        {
            Random rnd = new Random();
            int num = rnd.Next();
            if (num % 2 == 0)
            {
                enemy.state = new EnemyUpState(enemy);
            }
            else
            {
                enemy.state = new EnemyLeftState(enemy);
            }


        }

        public void Update(GameTime time) {
            enemy.Move();
        }
    }
    public class EnemyUpState : IEnemyState
    {
        private readonly Enemy enemy;
        public ISceneDelegate scene;
        public EnemyUpState(Enemy enemy)
        {
            this.enemy = enemy;
            scene = enemy.SceneDelegate;
            enemy.direction = Dir.Up;
            enemy.SetDetectorValues(10, 0, 10, 1);

        }
        public void ChangeDirection()
        {

            Random rnd = new Random();
            int num = rnd.Next();
            
            if (num % 2 == 0)
            {
                enemy.state = new EnemyLeftState(enemy);
            }
            else
            {
                enemy.state = new EnemyDownState(enemy);
            }

        }

        public void Update(GameTime time)
        {
            enemy.Move();
        }
    }
    public class EnemyDownState : IEnemyState
    {
        private readonly Enemy enemy;
        public ISceneDelegate scene;
        public EnemyDownState(Enemy enemy)
        {
            this.enemy = enemy;
            scene = enemy.SceneDelegate;
            enemy.direction = Dir.Down;
            enemy.SetDetectorValues(10, 29, 10, 1);
        }
        public void ChangeDirection()
        {
            Random rnd = new Random();
            int num = rnd.Next();

            if (num % 2 == 0)
            {
                enemy.state = new EnemyRightState(enemy);
            }
            else
            {
                enemy.state = new EnemyDownState(enemy);
            }


        }

        public void Update(GameTime time)
        {
            enemy.Move();
        }
    }

    public class EnemyDeathState : IEnemyState
    {
        private readonly Enemy enemy;
        public ISceneDelegate scene;
        private float timer;
        private float opacity;
        private readonly float fadeTime;
        public EnemyDeathState(Enemy enemy)
        {
            this.enemy=enemy;
            scene = enemy.SceneDelegate;

            enemy.spriteAnims = new SpriteAnimation[1];
            enemy.spriteAnims[0] = enemy.deathAnimation;
            enemy.direction=0;

            timer = 0;
            opacity = 1f;
            fadeTime = 100f;

        }
        public void ChangeDirection()
        {

        }


        public void Update(GameTime time)
        {
            if (timer > fadeTime)
            {
                scene.ToRemoveEntity(enemy);
            }
            else
            {
                opacity = 1f - timer / fadeTime;
                enemy.spriteAnims[0].Color = Color.White * opacity;
                timer += (float)time.ElapsedGameTime.TotalMilliseconds;
            }

        }
    }
}
