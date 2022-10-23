using CrazyArcade.Demo1;
using CrazyArcade.Enemy;
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
using System.Numerics;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using System.Drawing;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics;
using static System.Formats.Asn1.AsnWriter;

namespace CrazyArcade.Levels
{
    internal class Level
    {
        

        private List<CAEntity> EntityList;
        private CAScene Scene;
        private LoadLevel Level0;
        private Vector2[] itemLocations;
        private Rectangle Destination;
        private CAEntity Entity;
        int size;
        float scale;
        Vector2 border;
        Vector2 startPosition;
        public Level(CAScene scene)
        {
            Level0 = new LoadLevel("level_0.json");
            this.Scene = scene;
            EntityList = new List<CAEntity>();
            LoadSprites(Level0);
            LoadBorder(Level0);

        }
        private void LoadBorder(LoadLevel currentLevel)
        {
            scale = .9f;
            border = currentLevel.GetBorder();
            for (int i = (int)border.X; i >= 0; i--)
            {


                LoadStone(currentLevel, scale, i, -1);
                LoadStone(currentLevel, scale, i - 1, (int)border.Y - 1);
            }
            for (int i = (int)border.Y; i >= 0; i--)
            {
                LoadStone(currentLevel, scale, -1, i - 1);
                LoadStone(currentLevel, scale, (int)border.X, i - 1);
            }
        }
        private void LoadStone(LoadLevel currentLevel, float Scale, int X, int Y)
        {
            scale = Scale;
            size = 0;
            startPosition = currentLevel.GetStartPosition(new int[2] { X, Y });
            Destination = new Rectangle((int)startPosition.X, (int)startPosition.Y, size, size);
            Entity = new LightSandBlock(Destination);
            Entity.SpriteAnim.Scale = scale;
            EntityList.Add(Entity);
        }
        private void LoadSprites(LoadLevel currentLevel)
        {
            //Blocks
            //TODO Find a way to reduce duplicate code
            scale = .9f;
            size = 36;
            itemLocations = currentLevel.GetItemLocation(LoadLevel.LevelItem.LightSandPosition);

            foreach (Vector2 vector in itemLocations)
            {
                Debug.WriteLine(vector.Y);
                Destination = new Rectangle((int)vector.X, (int)vector.Y, size, size);
                Entity = new LightSandBlock(Destination);
                Entity.SpriteAnim.Scale = scale;
                EntityList.Add(Entity);
            }

            itemLocations = currentLevel.GetItemLocation(LoadLevel.LevelItem.DarkSandPosition);

            foreach (Vector2 vector in itemLocations)
            {
                Debug.WriteLine(vector.Y);
                Destination = new Rectangle((int)vector.X, (int)vector.Y, size, size);
                Entity = new SandBlock(Destination);
                Entity.SpriteAnim.Scale = scale;
                EntityList.Add(Entity);
            }
            itemLocations = currentLevel.GetItemLocation(LoadLevel.LevelItem.StonePosition);

            foreach (Vector2 vector in itemLocations)
            {
                Debug.WriteLine(vector.Y);
                Destination = new Rectangle((int)vector.X, (int)vector.Y, size, size);
                Entity = new Rock(Destination);
                Entity.SpriteAnim.Scale = scale;
                EntityList.Add(Entity);
            }

            itemLocations = currentLevel.GetItemLocation(LoadLevel.LevelItem.LightTreePosition);

            foreach (Vector2 vector in itemLocations)
            {
                Debug.WriteLine(vector.Y);
                Destination = new Rectangle((int)vector.X, (int)vector.Y, size, size);
                Entity = new Tree(Destination);
                Entity.SpriteAnim.Scale = scale;
                EntityList.Add(Entity);
            }

            itemLocations = currentLevel.GetItemLocation(LoadLevel.LevelItem.DarkTreePosition);

            foreach (Vector2 vector in itemLocations)
            {
                Debug.WriteLine(vector.Y);
                Destination = new Rectangle((int)vector.X, (int)vector.Y, size, size);
                Entity = new DarkTree(Destination);
                Entity.SpriteAnim.Scale = .9f;
                EntityList.Add(Entity);
            }


            itemLocations = currentLevel.GetItemLocation(LoadLevel.LevelItem.CactusPosition);

            foreach (Vector2 vector in itemLocations)
            {
                Debug.WriteLine(vector.Y);
                Destination = new Rectangle((int)vector.X, (int)vector.Y, size, size);
                Entity = new Cactus(Destination);
                Entity.SpriteAnim.Scale = .9f;
                EntityList.Add(Entity);
            }

            itemLocations = currentLevel.GetItemLocation(LoadLevel.LevelItem.CoinBagPosition);

            foreach (Vector2 vector in itemLocations)
            {
                Debug.WriteLine(vector.Y);
                Destination = new Rectangle((int)vector.X, (int)vector.Y, size, size);
                Entity = new CoinBag(Destination);
                EntityList.Add(Entity);
            }

            itemLocations = currentLevel.GetItemLocation(LoadLevel.LevelItem.BalloonPosition);

            foreach (Vector2 vector in itemLocations)
            {

                Destination = new Rectangle((int)vector.X, (int)vector.Y, size, size);
                EntityList.Add(new Balloon(Destination));

            }

            itemLocations = currentLevel.GetItemLocation(LoadLevel.LevelItem.SneakerPosition);

            foreach (Vector2 vector in itemLocations)
            {

                Destination = new Rectangle((int)vector.X, (int)vector.Y, size, size);
                EntityList.Add(new Sneaker(Destination));
            }

            itemLocations = currentLevel.GetItemLocation(LoadLevel.LevelItem.TurtlePosition);

            foreach (Vector2 vector in itemLocations)
            {
                Debug.WriteLine(vector.Y);
                Destination = new Rectangle((int)vector.X, (int)vector.Y, size, size);
                EntityList.Add(new Turtle(Destination));
            }

            itemLocations = currentLevel.GetItemLocation(LoadLevel.LevelItem.PotionPosition);

            foreach (Vector2 vector in itemLocations)
            {
                Debug.WriteLine(vector.Y);
                Destination = new Rectangle((int)vector.X, (int)vector.Y, size, size);
                EntityList.Add(new Potion(Destination));
            }

            itemLocations = currentLevel.GetItemLocation(LoadLevel.LevelItem.CoinPosition);

            foreach (Vector2 vector in itemLocations)
            {
                Debug.WriteLine(vector.Y);
                Destination = new Rectangle((int)vector.X, (int)vector.Y, size, size);
                EntityList.Add(new Coin(Destination));
            }

            itemLocations = currentLevel.GetItemLocation(LoadLevel.LevelItem.BombPosition);

            foreach (Vector2 vector in itemLocations)
            {
                EntityList.Add(new BombEnemySprite((int)vector.X, (int)vector.Y));
            }

            itemLocations = currentLevel.GetItemLocation(LoadLevel.LevelItem.SquidPosition);

            foreach (Vector2 vector in itemLocations)
            {
                EntityList.Add(new SquidEnemySprite((int)vector.X, (int)vector.Y));
            }

            itemLocations = currentLevel.GetItemLocation(LoadLevel.LevelItem.BatPosition);

            foreach (Vector2 vector in itemLocations)
            {
                EntityList.Add(new BatEnemySprite((int)vector.X, (int)vector.Y));
            }

            itemLocations = currentLevel.GetItemLocation(LoadLevel.LevelItem.RobotPosition);

            foreach (Vector2 vector in itemLocations)
            {
                EntityList.Add(new RobotEnemySprite((int)vector.X, (int)vector.Y));
            }

            itemLocations = currentLevel.GetItemLocation(LoadLevel.LevelItem.OctoBossPosition);

            foreach (Vector2 vector in itemLocations)
            {
                EntityList.Add(new OctopusEnemy((int)vector.X, (int)vector.Y));
            }

            itemLocations = currentLevel.GetItemLocation(LoadLevel.LevelItem.SunBossPosition);

            foreach (Vector2 vector in itemLocations)
            {
                EntityList.Add(new SunBoss(Scene));
            }


        }
    }
}
