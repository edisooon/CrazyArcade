using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.SoundEffectSystem;
using Microsoft.Xna.Framework;
using System;


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
        private readonly int xOffset = -4;
        private readonly int yOffset = 2;
        private readonly int width = 1;
        private readonly int height = 26;
        public EnemyLeftState(Enemy enemy)
        {
            this.enemy = enemy;
            scene = enemy.SceneDelegate;
            enemy.direction = Dir.Left;
            //This sets the size and location of the enemy block collision detector
            //It changes location and orientation based on which direction the enemy is going.
            enemy.SetDetectorValues(xOffset, yOffset, width, height);
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
        private readonly int xOffset = 33;
        private readonly int yOffset = 2;
        private readonly int width = 1;
        private readonly int height = 26;
        public EnemyRightState(Enemy enemy)
        {
            this.enemy = enemy;
            scene = enemy.SceneDelegate;
            enemy.direction = Dir.Right;
            //This sets the size and location of the enemy block collision detector
            //It changes location and orientation based on which direction the enemy is going.
            enemy.SetDetectorValues(xOffset, yOffset, width, height);

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
        private readonly int xOffset = 2;
        private readonly int yOffset = -4;
        private readonly int width = 26;
        private readonly int height = 1;
        public EnemyUpState(Enemy enemy)
        {
            this.enemy = enemy;
            scene = enemy.SceneDelegate;
            enemy.direction = Dir.Up;
            //This sets the size and location of the enemy block collision detector
            //It changes location and orientation based on which direction the enemy is going.
            enemy.SetDetectorValues(xOffset, yOffset, width, height);

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
        private readonly int xOffset = 2;
        private readonly int yOffset = 33;
        private readonly int width = 26;
        private readonly int height = 1;
        public EnemyDownState(Enemy enemy)
        {
            this.enemy = enemy;
            scene = enemy.SceneDelegate;
            enemy.direction = Dir.Down;
            //This sets the size and location of the enemy block collision detector
            //It changes location and orientation based on which direction the enemy is going.
            enemy.SetDetectorValues(xOffset, yOffset, width, height);
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
            enemy.SceneDelegate.ToAddEntity(new CASoundEffect("SoundEffects/EnemyDies"));

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
