using System;
using System.Text.Json;
using System.IO;
using System.Diagnostics;

namespace CrazyArcade.Levels;

public class ReadJSON
{
    StreamReader sReader;
    string jString;
    string winDir = System.Environment.CurrentDirectory;
    public Level levelObject { get; }
    //How to use:
    //ReadJSON test = new ReadJSON("\\Level_0.json");
    //Level Level0 = test.levelObject;
    
    public ReadJSON(string fileName)
    {
        sReader = new StreamReader(winDir+ "\\Content\\JsonLevels" + fileName);

        try
        {
            jString = sReader.ReadToEnd();
        }
        catch
        {
            Console.Error.WriteLine("File is empty");
        }
        levelObject = JsonSerializer.Deserialize<Level>(jString);
        //Debug.WriteLine(levelObject.Grid[0]);
    }

}

public class Level
{

    public int[] Background { get; set; }

    public int[] Grid { get; set; }

    public LevelBlocks Blocks { get; set; }

    public LevelItems Items { get; set; }

    public int[] Player { get; set; }

    public LevelEnemies Enemies { get; set; }

    public LevelBoss Boss { get; set; }
}

public class LevelBlocks
{
    public int[][] LightSand { get; set; }

    public int[][] DarkSand { get; set; }

    public int[][] Stone { get; set; }
}

public class LevelBoss
{
    public int[][] Sun { get; set; }

    public int[][] Octo { get; set; }
}

public class LevelEnemies
{
    public int[][] Bomb { get; set; }

    public int[][] Squid { get; set; }

    public int[][] Bat { get; set; }

    public int[][] Robot { get; set; }
}

public class LevelItems
{

    public int[][] CoinBag { get; set; }

    public int[][] Balloon { get; set; }

    public int[][] Sneaker { get; set; }

    public int[][] Turtle { get; set; }

    public int[][] Potion { get; set; }

    public int[][] Coin { get; set; }
}
