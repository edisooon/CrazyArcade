using CrazyArcade.Demo1;
using CrazyArcade.Enemies;
using CrazyArcade.Boss;
using CrazyArcade.CAFramework;
using CrazyArcade.Items;
using CrazyArcade.Blocks;
using CrazyArcade.Levels;
using CrazyArcade.PlayerStateMachine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CrazyArcade.Levels
{
    public class LevelManager : IGameSystem

    {

        private List<CAEntity> EntityList;
        private CAScene Scene;
        private LoadLevel Level0;
        private Vector2[] itemLocations;
        private Rectangle Destination;
        private int size;
        public LevelManager(CAScene scene)
        {
            Level0 = new LoadLevel("level_0.json");
            this.Scene = scene;
            EntityList = new List<CAEntity>();
            LoadSprites();
            foreach (CAEntity entity in EntityList)
            {
                Scene.AddSprite(entity);
            }
        }
        private void LoadSprites()
        {
            //Blocks
            //TODO Find a way to reduce duplicate code
            itemLocations = Level0.GetItemLocation(LoadLevel.LevelItem.DarkSandPosition);
            size = 36;
            foreach (Vector2 vector in itemLocations)
            {
                Debug.WriteLine(vector.Y);
                Destination = new Rectangle((int)vector.X, (int)vector.Y, size, size);
                EntityList.Add(new SandBlock(Destination));
            }


            itemLocations = Level0.GetItemLocation(LoadLevel.LevelItem.LightSandPosition);

            foreach (Vector2 vector in itemLocations)
            {
                Debug.WriteLine(vector.Y);
                Destination = new Rectangle((int)vector.X, (int)vector.Y, size, size);
                Console.Out.WriteLine(Destination);
                EntityList.Add(new LightSandBlock(Destination));
            }
            itemLocations = Level0.GetItemLocation(LoadLevel.LevelItem.StonePosition);

            foreach (Vector2 vector in itemLocations)
            {
                Debug.WriteLine(vector.Y);
                Destination = new Rectangle((int)vector.X, (int)vector.Y, size, size);
                EntityList.Add(new Rock(Destination));
            }


            itemLocations = Level0.GetItemLocation(LoadLevel.LevelItem.CoinBagPosition);

            foreach (Vector2 vector in itemLocations)
            {
                Debug.WriteLine(vector.Y);
                Destination = new Rectangle((int)vector.X, (int)vector.Y, size, size);
                EntityList.Add(new CoinBag(Destination));
            }

            itemLocations = Level0.GetItemLocation(LoadLevel.LevelItem.BalloonPosition);

            foreach (Vector2 vector in itemLocations)
            {

                Destination = new Rectangle((int)vector.X, (int)vector.Y, size, size);
                EntityList.Add(new Balloon(Destination));
            }

            itemLocations = Level0.GetItemLocation(LoadLevel.LevelItem.SneakerPosition);

            foreach (Vector2 vector in itemLocations)
            {

                Destination = new Rectangle((int)vector.X, (int)vector.Y, size, size);
                EntityList.Add(new Sneaker(Destination));
            }

            itemLocations = Level0.GetItemLocation(LoadLevel.LevelItem.TurtlePosition);

            foreach (Vector2 vector in itemLocations)
            {
                Debug.WriteLine(vector.Y);
                Destination = new Rectangle((int)vector.X, (int)vector.Y, size, size);
                EntityList.Add(new Turtle(Destination));
            }

            itemLocations = Level0.GetItemLocation(LoadLevel.LevelItem.PotionPosition);

            foreach (Vector2 vector in itemLocations)
            {
                Debug.WriteLine(vector.Y);
                Destination = new Rectangle((int)vector.X, (int)vector.Y, size, size);
                EntityList.Add(new Potion(Destination));
            }

            itemLocations = Level0.GetItemLocation(LoadLevel.LevelItem.CoinPosition);

            foreach (Vector2 vector in itemLocations)
            {
                Debug.WriteLine(vector.Y);
                Destination = new Rectangle((int)vector.X, (int)vector.Y, size, size);
                EntityList.Add(new Coin(Destination));
            }

            itemLocations = Level0.GetItemLocation(LoadLevel.LevelItem.BombPosition);

            foreach (Vector2 vector in itemLocations)
            {
                EntityList.Add(new BombEnemySprite((int)vector.X, (int)vector.Y));
            }

            itemLocations = Level0.GetItemLocation(LoadLevel.LevelItem.SquidPosition);

            foreach (Vector2 vector in itemLocations)
            {
                EntityList.Add(new SquidEnemySprite((int)vector.X, (int)vector.Y));
            }

            itemLocations = Level0.GetItemLocation(LoadLevel.LevelItem.BatPosition);

            foreach (Vector2 vector in itemLocations)
            {
                EntityList.Add(new BatEnemySprite((int)vector.X, (int)vector.Y));
            }

            itemLocations = Level0.GetItemLocation(LoadLevel.LevelItem.RobotPosition);

            foreach (Vector2 vector in itemLocations)
            {
                EntityList.Add(new RobotEnemySprite((int)vector.X, (int)vector.Y));
            }

            itemLocations = Level0.GetItemLocation(LoadLevel.LevelItem.OctoBossPosition);

            foreach (Vector2 vector in itemLocations)
            {
                EntityList.Add(new OctopusEnemy((int)vector.X, (int)vector.Y));
            }
           
            itemLocations = Level0.GetItemLocation(LoadLevel.LevelItem.SunBossPosition);

            foreach (Vector2 vector in itemLocations)
            {
                EntityList.Add(new SunBoss(Scene));
            }


        }

       
        public void Update(GameTime time)
        {

        }
        public void AddSprite(IEntity sprite)
        {
            
        }
        public void RemoveSprite(IEntity sprite)
        {

        }
        public void RemoveAll()
        {

        }
        
       
    }
}
