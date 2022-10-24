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
using System.Numerics;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using System.Drawing;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics;
using static System.Formats.Asn1.AsnWriter;
using CrazyArcade.CAFramework.Controller;
using Microsoft.Xna.Framework.Content;

namespace CrazyArcade.Levels
{
    public class LevelManager : IGameSystem, IControllable

    {
        private IController controller;
        private CAScene Scene;
        private string mapFile;
        private string levelFile;
        private MapSchema mapSchema;
        private Level[] levelArray;
        private CreateMap mapReader;
        private string[] levelFiles;
        private int levelNum;
        private int length;
        private int oldNum;
        public IController Controller
        {
            get => controller;
            set
            {
                controller = value;
                controller.Delegate = this;
            }
        }
        public LevelManager(CAScene scene, IController controller)
        {
            this.Scene = scene;
            mapFile = "Map.json";
            levelNum = 0;
            oldNum = 0;
            getLevelFiles();
            loadLevels();
            levelArray[levelNum].DrawLevel();
            this.controller = controller;
            controller.Delegate = this;
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
                levelArray[i] = new Level(Scene, levelFile);
            }


        }
        public void Update(GameTime time)
        {

            if (oldNum != levelNum)
            {
                levelArray[oldNum].DeleteLevel();
                Scene.RemoveAllSprite();
                levelArray[levelNum].DrawLevel();
                oldNum = levelNum;
            }

            
        }
        

        public void RightClick()

        {
            
            if (levelNum > 0)
            {
                levelNum--;
            }
            
        }

        public void LeftClick()
        {

            if (levelNum < levelFiles.Length-1)
            {
                oldNum = levelNum;
                levelNum++;
            }
            
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
        public void KeyUp()
        {

        }

        public void KeyDown()
        {

        }

        public void KeyLeft()
        {

        }

        public void KeyRight()
        {

        }

        public void KeySpace()
        {

        }
        public void Key_o()
        {

        }
        public void Key_p()
        {

        }
        public void LeftClick(int x, int y)
        {

        }

    }
}
