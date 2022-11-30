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
    public LevelSchema levelObject { get; }
    public MapSchema mapObject { get; }
    //How to use:
    //ReadJSON test = new ReadJSON("\\Level_0.json", file);
    //Level Level0 = test.levelObject;


    public enum fileType
    {
        LevelFile,
        MapFile
    }
    public ReadJSON(string fileName, fileType type)
    {
        char sep = Path.DirectorySeparatorChar;
        sReader = new StreamReader(winDir+ sep+"Content"+ sep+"JsonLevels"+sep + fileName);

        try
        {
            jString = sReader.ReadToEnd();
        }
        catch
        {
            Console.Error.WriteLine("File is empty");
        }
        if (type == fileType.LevelFile)
        {
            levelObject = JsonSerializer.Deserialize<LevelSchema>(jString);
        }
        else if(type == fileType.MapFile) 
        {
            mapObject = JsonSerializer.Deserialize<MapSchema>(jString);
        }
    }

}


public partial class MapSchema
{

    public string[] Levels { get; set; }
}
public class LevelSchema
{

    public int[] Background { get; set; }

    public int[]  Border { get; set; }

    public LevelBlocks Blocks { get; set; }

    public LevelItems Items { get; set; }

    public int[] Player { get; set; }

	public int[][] Pirate { get; set; }

	public LevelEnemies Enemies { get; set; }

    public LevelBoss Boss { get; set; }
}

public class LevelBlocks
{
    public int[][] Door { get; set; }
    public int[][] LightSand { get; set; }

    public int[][] DarkSand { get; set; }

    public int[][] Stone { get; set; }
    public int[][] Cactus { get; set; }
    public int[][] DarkTree { get; set; }
    public int[][] LightTree { get; set; }
    

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

    public int[][] Kick { get; set; }
}
