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
        void BeKilled();
        void Update(GameTime time);

    }
    public class EnemyLeftState : IEnemyState
    {
        private Enemy enemy;
        public CAScene scene;

        public EnemyLeftState(Enemy enemy)
        {
            this.enemy = enemy;
            scene = enemy.scene;
        }
        public void ChangeDirection()
        {

        }
        public void BeKilled()
        {

        }

        public void Update(GameTime time)
        {

        }
    }
    public class EnemyRightState : IEnemyState
    {
        private Enemy enemy;
        public CAScene scene;
        public EnemyRightState(Enemy enemy)
        {
            this.enemy = enemy;
            scene = enemy.scene;
        }
        public void ChangeDirection()
        {

        }
        public void BeKilled()
        {

        }
        public void Update(GameTime time) { 
        }
    }
    public class EnemyUpState : IEnemyState
    {
        private Enemy enemy;
        public CAScene scene;
        public EnemyUpState(Enemy enemy)
        {
            this.enemy = enemy;
            scene = enemy.scene;
        }
        public void ChangeDirection()
        {

        }
        public void BeKilled()
        {

        }

        public void Update(GameTime time)
        {
        }
    }
    public class EnemyDownState : IEnemyState
    {
        private Enemy enemy;
        public CAScene scene;
        public EnemyDownState(Enemy enemy)
        {
            this.enemy = enemy;
            scene = enemy.scene;
        }
        public void ChangeDirection()
        {

        }
        public void BeKilled()
        {

        }

        public void Update(GameTime time)
        {

        }
    }

    public class EnemyDeathState : IEnemyState
    {
        private Enemy enemy;
        public CAScene scene;
        private float timer;
        private float opacity;
        private float fadeTime;
        public EnemyDeathState(Enemy enemy)
        {
            this.enemy=enemy;
            scene = enemy.scene;

            
            enemy.spriteAnims = new SpriteAnimation[1];
            enemy.spriteAnims[0] = enemy.deathAnimation;
            enemy.direction=0;

            timer = 0;
            opacity = 1f;
            fadeTime = 600f;

        }
        public void ChangeDirection()
        {

        }
        public void BeKilled()
        {
            
        }

        public void Update(GameTime time)
        {


            enemy.UpdateAnimation((Dir)0);
            if (timer > fadeTime)
            {
                scene.RemoveSprite(enemy);
            }
            else
            {
                enemy.spriteAnims[0].Color = Color.White * (1f - timer/fadeTime);
                timer += (float)time.ElapsedGameTime.TotalMilliseconds;
            }
            

        }
    }
}
