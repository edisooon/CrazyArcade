using CrazyArcade.Enemies;
using CrazyArcade.Boss;
using CrazyArcade.CAFramework;
using CrazyArcade.Items;
using CrazyArcade.Blocks;
using CrazyArcade.PlayerStateMachine;
using System.Collections.Generic;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Microsoft.Xna.Framework.Input;
using CrazyArcade.CAFrameWork.InputSystem;
using CrazyArcade.CAFrameWork.Transition;
using System;
using CrazyArcade.Pirates;
using CrazyArcade.CAFrameWork.DoorUtils;

namespace CrazyArcade.Levels
{
    internal class Level
    {
        private List<CAEntity> EntityList;
        private CAScene Scene;
        private CreateLevel currentLevel;
        private Vector2[] itemLocations;
        private CAEntity Entity;
        float scale;
        Vector2 border;
        Vector2 startPosition;
        int[] keySet = new int[7];

        public Level(CAScene scene, string levelName)
        {
            keySet[0] = KeyBoardInput.KeyDown(Keys.Up);
            keySet[1] = KeyBoardInput.KeyDown(Keys.Down);
            keySet[2] = KeyBoardInput.KeyDown(Keys.Left);
            keySet[3] = KeyBoardInput.KeyDown(Keys.Right);
            keySet[4] = KeyBoardInput.KeyUp(Keys.Space);
            keySet[5] = KeyBoardInput.KeyUp(Keys.N);
            keySet[6] = KeyBoardInput.KeyUp(Keys.B);
            currentLevel = new CreateLevel(levelName);
            this.Scene = scene;
            EntityList = new List<CAEntity>();
            LoadSprites();
            LoadBorder();
            PlayerCharacter player = new(keySet)
            {
                GameCoord = currentLevel.GetPlayerStart()
            };
            EntityList.Add(player);
        }
        public List<CAEntity> DrawLevel()
        {
            return EntityList;
        }
        
        public void DeleteLevel()
        {
            foreach (CAEntity entity in EntityList)
            {
                Scene.RemoveSprite(entity);
            }
        }
        
        
        private void LoadBorder()
        {
            scale = .9f;
            border = currentLevel.GetBorder();
            for (int i = (int)border.X+1; i >= 0; i--)
            {
                LoadStone(i, 0);
                LoadStone(i, (int)border.Y+1);
            }
            for (int i = (int)border.Y+1; i >= 0; i--)
            {
                LoadStone(0, i);
                LoadStone((int)border.X+1, i);
            }
        }
        private void LoadStone(int X, int Y)
        {

            startPosition = currentLevel.GetStartPosition(new int[2] { X, Y });
            Entity = new Rock(startPosition);
            Entity.SpriteAnim.Scale = scale;
            EntityList.Add(Entity);
        }
        private void LoadSprites()
        {
            
            //TODO Find a way to reduce duplicate code
            scale = .9f;
            itemLocations = currentLevel.GetItemLocation(CreateLevel.LevelItem.DoorPosition);

            for (int i = 0; i < itemLocations.Length; i += 2)
            {
                Console.WriteLine("Door stage json: " + (int)itemLocations[i + 1].X);
                Entity = new Door(itemLocations[i], (int)itemLocations[i + 1].X - 1, (Dir)itemLocations[i + 1].Y);
                Entity.SpriteAnim.Scale = scale;
                EntityList.Add(Entity);
            }
            itemLocations = currentLevel.GetItemLocation(CreateLevel.LevelItem.LightSandPosition);

            foreach (Vector2 vector in itemLocations)
            {

                Entity = new LightSandBlock(Scene, vector);
                Entity.SpriteAnim.Scale = scale;
                EntityList.Add(Entity);
            }

            itemLocations = currentLevel.GetItemLocation(CreateLevel.LevelItem.DarkSandPosition);

            foreach (Vector2 vector in itemLocations)
            {
                
                Entity = new SandBlock(Scene, vector);
                Entity.SpriteAnim.Scale = scale;
                EntityList.Add(Entity);
            }
            itemLocations = currentLevel.GetItemLocation(CreateLevel.LevelItem.StonePosition);

            foreach (Vector2 vector in itemLocations)
            {
                
                Entity = new Rock(vector);
                Entity.SpriteAnim.Scale = scale;
                EntityList.Add(Entity);
            }

            itemLocations = currentLevel.GetItemLocation(CreateLevel.LevelItem.LightTreePosition);

            foreach (Vector2 vector in itemLocations)
            {
                
                Entity = new Tree(vector);
                Entity.SpriteAnim.Scale = scale;
                EntityList.Add(Entity);
            }

            itemLocations = currentLevel.GetItemLocation(CreateLevel.LevelItem.DarkTreePosition);

            foreach (Vector2 vector in itemLocations)
            {
                
                Entity = new DarkTree(vector);
                Entity.SpriteAnim.Scale = .9f;
                EntityList.Add(Entity);
            }


            itemLocations = currentLevel.GetItemLocation(CreateLevel.LevelItem.CactusPosition);

            foreach (Vector2 vector in itemLocations)
            {
                
                Entity = new Cactus(vector);
                Entity.SpriteAnim.Scale = .9f;
                EntityList.Add(Entity);
            }

            itemLocations = currentLevel.GetItemLocation(CreateLevel.LevelItem.CoinBagPosition);

            foreach (Vector2 vector in itemLocations)
            {
               
                Entity = new CoinBag(vector);
                EntityList.Add(Entity);
            }

            itemLocations = currentLevel.GetItemLocation(CreateLevel.LevelItem.BalloonPosition);

            foreach (Vector2 vector in itemLocations)
            {

                
                EntityList.Add(new Balloon(vector));

            }

            itemLocations = currentLevel.GetItemLocation(CreateLevel.LevelItem.SneakerPosition);

            foreach (Vector2 vector in itemLocations)
            {

                
                EntityList.Add(new Sneaker(vector));
            }

            itemLocations = currentLevel.GetItemLocation(CreateLevel.LevelItem.TurtlePosition);

            foreach (Vector2 vector in itemLocations)
            {
                
                EntityList.Add(new Turtle(vector));
            }

            itemLocations = currentLevel.GetItemLocation(CreateLevel.LevelItem.PotionPosition);

            foreach (Vector2 vector in itemLocations)
            {
                
                EntityList.Add(new Potion(vector));
            }

            itemLocations = currentLevel.GetItemLocation(CreateLevel.LevelItem.CoinPosition);

            foreach (Vector2 vector in itemLocations)
            {
                
                EntityList.Add(new Coin(vector));
            }

            itemLocations = currentLevel.GetItemLocation(CreateLevel.LevelItem.KickPosition);

            foreach (Vector2 vector in itemLocations)
            {

                EntityList.Add(new KickBoot(vector));
            }

            itemLocations = currentLevel.GetItemLocation(CreateLevel.LevelItem.BombPosition);

            foreach (Vector2 vector in itemLocations)
            {
                EntityList.Add(new BombEnemySprite((int)vector.X, (int)vector.Y));
            }

            itemLocations = currentLevel.GetItemLocation(CreateLevel.LevelItem.SquidPosition);

            foreach (Vector2 vector in itemLocations)
            {
                EntityList.Add(new SquidEnemySprite((int)vector.X, (int)vector.Y));
            }

            itemLocations = currentLevel.GetItemLocation(CreateLevel.LevelItem.BatPosition);

            foreach (Vector2 vector in itemLocations)
            {
                EntityList.Add(new BatEnemySprite((int)vector.X, (int)vector.Y));
            }

            itemLocations = currentLevel.GetItemLocation(CreateLevel.LevelItem.RobotPosition);

            foreach (Vector2 vector in itemLocations)
            {
                EntityList.Add(new RobotEnemySprite((int)vector.X, (int)vector.Y));
            }

            itemLocations = currentLevel.GetItemLocation(CreateLevel.LevelItem.MimicPosition);

            foreach (Vector2 vector in itemLocations)
            {

                EntityList.Add(new MimicEnemySprite((int)vector.X, (int)vector.Y));
            }

            itemLocations = currentLevel.GetItemLocation(CreateLevel.LevelItem.OctoBossPosition);

            foreach (Vector2 vector in itemLocations)
            {
                EntityList.Add(new OctopusEnemy((int)vector.X, (int)vector.Y, Scene));
            }

            itemLocations = currentLevel.GetItemLocation(CreateLevel.LevelItem.SunBossPosition);

            foreach (Vector2 vector in itemLocations)
            {
                EntityList.Add(new SunBoss(Scene));
            }

			itemLocations = currentLevel.GetItemLocation(CreateLevel.LevelItem.PiratePosition);

			foreach (Vector2 vector in itemLocations)
			{
				EntityList.Add(new PirateCharacter());
			}
            LoadFlags();
		}
        private void LoadFlags()
        {
            EntityList.Add(new ObtainFlag(currentLevel.GetFlag(CreateLevel.FlagEnum.PuzzleFlag)));
        }
    }
}
