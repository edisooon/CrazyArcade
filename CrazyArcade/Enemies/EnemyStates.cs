using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace CrazyArcade.Enemies
{
    public interface IEnemyState
    {
        void ChangeDirection();
        void BeKilled();
        void Update();

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

        public void Update()
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
        public void Update() { 
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

        public void Update()
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

        public void Update()
        {

        }
    }

    public class EnemyDeathState : IEnemyState
    {
        private Enemy enemy;
        public CAScene scene;
        private int timer;
        private float opacity;
       
        public EnemyDeathState(Enemy enemy)
        {
            this.enemy=enemy;
            scene = enemy.scene;
            enemy.animateDeath();
            timer = 0;
            opacity = 1f;

            
        }
        public void ChangeDirection()
        {

        }
        public void BeKilled()
        {
            
        }

        public void Update()
        {

            if (timer == 5)
            {
                scene.RemoveSprite(enemy);
            }
            else
            {
                opacity = 1f - (.25f * (float)timer);
                enemy.spriteAnim.Color = Color.White * opacity;
                timer++;
            }
            
        }
    }
}
