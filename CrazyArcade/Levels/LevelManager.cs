
using CrazyArcade.CAFramework;

namespace CrazyArcade.Levels
{
    public class LevelManager
    {
        public static LevelManager manager = new LevelManager();
        private string mapFile;
        private string levelFile;
        private MapSchema mapSchema;
        private Level[] levelArray;
        private CreateMap mapReader;
        private string[] levelFiles;
        private int levelNum;
        private int length;
        private int oldNum;
        private int shiftFlag;
        private Dir direction;

        public LevelManager()
        {
            mapFile = "Map.json";
            levelNum = 0;
            oldNum = 0;
            getLevelFiles();
            loadLevels();
            levelArray[levelNum].DrawLevel();
            shiftFlag = 50;
        }

        private void getLevelFiles()
        {
            mapReader = new CreateMap(mapFile);
            mapSchema = mapReader.mapObject;
            levelFiles = mapSchema.Levels;
        }   
        private void loadLevels()
        {
            length = levelFiles.Length;
            levelArray = new Level[length];
            for (int i = 0; i < length; i++)
            {
                levelFile = levelFiles[i];
           
            }
        }

    }
}
