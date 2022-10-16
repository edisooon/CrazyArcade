using System;
using System.Text.Json;
using System.IO;
using System.Diagnostics;
using Microsoft.Xna.Framework;

using CrazyArcade.Levels;
namespace CrazyArcade.Levels;

public class LoadLevel
{
	public static Level levelObject;
    public ReadJSON Reader;
	public LoadLevel()
	{
		Reader = new ReadJSON("\\Level_0.json");
		levelObject = new Level();
		levelObject = Reader.levelObject;
	}

	public enum LevelItem
	{
		PlayerPosition,
		LightSandPosition,
		DarkSandPosition,
		StonePosition,
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

	public static Vector2 GetStartPosition(int[] coord)
	{
		return new Vector2(	(float)(130 + (36 * coord[0])),(float)(12 + (coord[1])));
	}
	public static Vector2[] GetStartPositionArray(int[][] coordArray)
	{
		Vector2[] result = new Vector2[coordArray.Length];
		for (int i = 0; i<coordArray.Length; i++)
		{
			result[i] = GetStartPosition(coordArray[i]); 

		}
		return result;
	}

	public static Vector2 GetPlayerStart()
	{
		return GetStartPosition(levelObject.Player);
	}
	public static Color GetBackgroundColor()
	{
		return new Color(levelObject.Background[0],levelObject.Background[1], levelObject.Background[2]);
	}
	public static Vector2 GetDimensions()
	{
		return new Vector2((float)levelObject.Grid[0], (float)levelObject.Grid[1]);
	}
	//returns an array of vectors for the location
	public static Vector2[] GetItemLocation(LevelItem property)
	{
		Vector2[] array = new Vector2[1];
		int item = (int)property;
		switch (item)
		{
			case 0:
				array[0] = GetStartPosition(levelObject.Player);
				return array;
				break;
			case 1:
				array = GetStartPositionArray(levelObject.Blocks.LightSand);
				return array;
				break;
			case 2:
				array = GetStartPositionArray(levelObject.Blocks.DarkSand);
				return array;
				break;
			case 3:
				array = GetStartPositionArray(levelObject.Blocks.Stone);
				return array;
				break;
			case 4:
				array = GetStartPositionArray(levelObject.Boss.Sun);
				return array;
				break;
			case 5:
				array = GetStartPositionArray(levelObject.Boss.Octo);
				return array;
				break;
			case 6:
				array = GetStartPositionArray(levelObject.Enemies.Bomb);
				return array;
				break;
			case 7:
				array = GetStartPositionArray(levelObject.Enemies.Squid);
				return array;
				break;
			case 8:
				array = GetStartPositionArray(levelObject.Enemies.Bat);
				return array;
				break;
			case 9:
				array = GetStartPositionArray(levelObject.Enemies.Robot);
				return array;
				break;
			case 10:
				array = GetStartPositionArray(levelObject.Items.CoinBag);
				return array;
				break;
			case 11:
				array = GetStartPositionArray(levelObject.Items.Balloon);
				return array;
				break;
			case 12:
				array = GetStartPositionArray(levelObject.Items.Sneaker);
				return array;
				break;
			case 13:
				array = GetStartPositionArray(levelObject.Items.Turtle);
				return array;
				break;
			case 14:
				array = GetStartPositionArray(levelObject.Items.Potion);
				return array;
				break;
			case 15:
				array = GetStartPositionArray(levelObject.Items.Coin);
				return array;
				break;
			default:

				return array;
				break;
		}
	}
}
