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
    public interface IEnemyState//It seems like this is not really being used other than death state?
    {
        void ChangeDirection();
        void Update(GameTime time);

    }
    public class EnemyLeftState : IEnemyState
    {
        private Enemy enemy;
        public ISceneDelegate scene;

        public EnemyLeftState(Enemy enemy)
        {
            this.enemy = enemy;
            scene = enemy.SceneDelegate;
            enemy.direction = Dir.Left;
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
                enemy.state = new EnemyRightState(enemy);
            }
            
        }

        public void Update(GameTime time)
        {

            enemy.move();
        }
    }
    public class EnemyRightState : IEnemyState
    {
        private Enemy enemy;
        public ISceneDelegate scene;
        public EnemyRightState(Enemy enemy)
        {
            this.enemy = enemy;
            scene = enemy.SceneDelegate;
            enemy.direction = Dir.Right;
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
                enemy.state = new EnemyLeftState(enemy);
            }
        }

        public void Update(GameTime time) {
            enemy.move(Dir.Right);
        }
    }
    public class EnemyUpState : IEnemyState
    {
        private Enemy enemy;
        public ISceneDelegate scene;
        public EnemyUpState(Enemy enemy)
        {
            this.enemy = enemy;
            scene = enemy.SceneDelegate;
            enemy.direction = Dir.Up;
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
            enemy.move(Dir.Up);
        }
    }
    public class EnemyDownState : IEnemyState
    {
        private Enemy enemy;
        public ISceneDelegate scene;
        public EnemyDownState(Enemy enemy)
        {
            this.enemy = enemy;
            scene = enemy.SceneDelegate;
            enemy.direction = Dir.Down;
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
                enemy.state = new EnemyUpState(enemy);
            }

        }

        public void Update(GameTime time)
        {
            enemy.move(Dir.Down);
        }
    }

    public class EnemyDeathState : IEnemyState
    {
        private Enemy enemy;
        public ISceneDelegate scene;
        private float timer;
        private float opacity;
        private float fadeTime;
        public EnemyDeathState(Enemy enemy)
        {
            this.enemy=enemy;
            scene = enemy.SceneDelegate;

            enemy.spriteAnims = new SpriteAnimation[1];
            enemy.spriteAnims[0] = enemy.deathAnimation;
            enemy.direction=0;

            timer = 0;
            opacity = 1f;
            fadeTime = 300f;

        }
        public void ChangeDirection()
        {

        }


        public void Update(GameTime time)
        {
            //enemy.UpdateAnimation((Dir)0);
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
