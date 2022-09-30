using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.Enemy;

namespace CrazyArcade.Enemy
{
    public class EnemyScene : CAScene
    {
        CAEntity sprite;

        public override void LoadSystems()
        {

        }
        public override void Load()             
        {
            sprite = new BombEnemySprite(100, 100);
            sprite.Load();      
            base.Load();
        }
        public override void Update(GameTime time)
        {
            sprite.Update(time);
            base.Update(time); 


        }
        public override void LoadSprites()

        {

            this.AddSprite(sprite);

        }
    }
}
