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
			return new Vector2((float)(166 + (36 * coord[0])), (float)(46 + (36 * coord[1])));
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
				case 0:
					array[0] = GetStartPosition(levelObject.Player);
					return array;
					
				case 1:
					array = GetStartPositionArray(levelObject.Blocks.LightSand);
					return array;
					
				case 2:
					array = GetStartPositionArray(levelObject.Blocks.DarkSand);
					return array;
					
				case 3:
					array = GetStartPositionArray(levelObject.Blocks.Stone);

					return array;
                case 4:
                    array = GetStartPositionArray(levelObject.Boss.Sun);
                    return array;

                case 5:
                    array = GetStartPositionArray(levelObject.Boss.Octo);
                    return array;

                case 6:
                    array = GetStartPositionArray(levelObject.Enemies.Bomb);
                    return array;
                case 7:
					array = GetStartPositionArray(levelObject.Boss.Sun);
					return array;
					
				case 8:
					array = GetStartPositionArray(levelObject.Boss.Octo);
					return array;
			
				case 9:
					array = GetStartPositionArray(levelObject.Enemies.Bomb);
					return array;
			
				case 10:
					array = GetStartPositionArray(levelObject.Enemies.Squid);
					return array;
					
				case 11:
					array = GetStartPositionArray(levelObject.Enemies.Bat);
					return array;
					
				case 12:
					array = GetStartPositionArray(levelObject.Enemies.Robot);
					return array;
					
				case 13:
					array = GetStartPositionArray(levelObject.Items.CoinBag);
					return array;
					
				case 14:
					array = GetStartPositionArray(levelObject.Items.Balloon);
					return array;
				
				case 15:
					array = GetStartPositionArray(levelObject.Items.Sneaker);
					return array;
				
				case 16:
					array = GetStartPositionArray(levelObject.Items.Turtle);
					return array;
					
				case 17:
					array = GetStartPositionArray(levelObject.Items.Potion);
					return array;
				
				case 18:
					array = GetStartPositionArray(levelObject.Items.Coin);
					return array;
				
				default:

					return array;
				
			}
		}
	}
}
