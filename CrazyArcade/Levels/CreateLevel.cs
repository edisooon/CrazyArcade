using System;
using System.Text.Json;
using System.IO;
using System.Diagnostics;
using Microsoft.Xna.Framework;

using CrazyArcade.Levels;
namespace CrazyArcade.Levels
{
    public class CreateMap
	{
        public MapSchema mapObject { get; }
        public ReadJSON Reader;
        public CreateMap(string fileName)
        {
            Reader = new ReadJSON(fileName, ReadJSON.fileType.MapFile);
            mapObject = new MapSchema();
            mapObject = Reader.mapObject;
        }
    }
    //allows for scene to load in level
    public class CreateLevel
	{
		public LevelSchema levelObject { get; }
        public ReadJSON Reader;
		public CreateLevel(string fileName)
		{
			Reader = new ReadJSON(fileName, ReadJSON.fileType.LevelFile);
			levelObject = Reader.levelObject;
		}

		public enum LevelItem
		{
			PlayerPosition,
			LightSandPosition,
			DarkSandPosition,
			StonePosition,
            CactusPosition,
            DarkTreePosition,
            LightTreePosition,
            SunBossPosition,
			OctoBossPosition,
			BombPosition,
			SquidPosition,
			BatPosition,
			RobotPosition,
			CoinBagPosition,
			BalloonPosition,
			SneakerPosition,
			TurtlePosition,
			PotionPosition,
			CoinPosition
		}

		public Vector2 GetStartPosition(int[] coord)
		{
			return new Vector2((float)(166 + (36 * coord[0])), (float)(18 + (36 * coord[1])));
		}
		public Vector2[] GetStartPositionArray(int[][] coordArray)
		{
			Vector2[] result = new Vector2[coordArray.Length];
			for (int i = 0; i < coordArray.Length; i++)
			{
				result[i] = GetStartPosition(coordArray[i]);

			}
			return result;
		}

		public Vector2 GetPlayerStart()
		{
			return GetStartPosition(levelObject.Player);
		}
		public Color GetBackgroundColor()
		{
			return new Color(levelObject.Background[0], levelObject.Background[1], levelObject.Background[2]);
		}
		public Vector2 GetBorder()
		{
			return new Vector2((float)levelObject.Border[0], (float)levelObject.Border[1]);
		}
		//returns an array of vectors for the location
		public Vector2[] GetItemLocation(LevelItem property)
		{
			Vector2[] array = new Vector2[1];
			int item = (int)property;
			switch (item)
			{
				case (int)LevelItem.PlayerPosition:
					array[0] = GetStartPosition(levelObject.Player);
					return array;
					
				case (int)LevelItem.LightSandPosition:
					array = GetStartPositionArray(levelObject.Blocks.LightSand);
					return array;
					
				case (int)LevelItem.DarkSandPosition:
					array = GetStartPositionArray(levelObject.Blocks.DarkSand);
					return array;
					
				case (int)LevelItem.StonePosition:
					array = GetStartPositionArray(levelObject.Blocks.Stone);

					return array;
                case (int)LevelItem.CactusPosition:
                    array = GetStartPositionArray(levelObject.Blocks.Cactus);
                    return array;

                case (int)LevelItem.DarkTreePosition:
                    array = GetStartPositionArray(levelObject.Blocks.DarkTree);
                    return array;

                case (int)LevelItem.LightTreePosition:
                    array = GetStartPositionArray(levelObject.Blocks.LightTree);
                    return array;
                case (int)LevelItem.SunBossPosition:
					array = GetStartPositionArray(levelObject.Boss.Sun);
					return array;
					
				case (int)LevelItem.OctoBossPosition:
					array = GetStartPositionArray(levelObject.Boss.Octo);
					return array;
			
				case (int)LevelItem.BombPosition:
					array = GetStartPositionArray(levelObject.Enemies.Bomb);
					return array;
			
				case (int)LevelItem.SquidPosition:
					array = GetStartPositionArray(levelObject.Enemies.Squid);
					return array;
					
				case (int)LevelItem.BatPosition:
					array = GetStartPositionArray(levelObject.Enemies.Bat);
					return array;
					
				case (int)LevelItem.RobotPosition:
					array = GetStartPositionArray(levelObject.Enemies.Robot);
					return array;
					
				case (int)LevelItem.CoinBagPosition:
					array = GetStartPositionArray(levelObject.Items.CoinBag);
					return array;
					
				case (int)LevelItem.BalloonPosition:
					array = GetStartPositionArray(levelObject.Items.Balloon);
					return array;
				
				case (int)LevelItem.SneakerPosition:
					array = GetStartPositionArray(levelObject.Items.Sneaker);
					return array;
				
				case (int)LevelItem.TurtlePosition:
					array = GetStartPositionArray(levelObject.Items.Turtle);
					return array;
					
				case (int)LevelItem.PotionPosition:
					array = GetStartPositionArray(levelObject.Items.Potion);
					return array;
				
				case (int)LevelItem.CoinPosition:
					array = GetStartPositionArray(levelObject.Items.Coin);
					return array;
				
				default:

					return array;
				
			}
		}
	}
}
