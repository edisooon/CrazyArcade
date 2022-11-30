using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrazyArcade.Content
{
    //How to use:
    //in Initialize
    //TextureSingleton.LoadAllTextures(this.Content);
    //In Draw or your method:
    //Texture2D texture = TextureSingleton.GetPlayer1();
    //This only returns Textures2D
    public class TextureSingleton
    {
        public static string[] fileNames;
        public static Texture2D[] spriteSheets;
        //Eager Initialization
        private static TextureSingleton instance = new TextureSingleton();
        private static SpriteFont[] fonts;
        private TextureSingleton() { }
        public static TextureSingleton Instance {
            get 
            {
                return instance; 
            } 
        }
        private static void DefineArrays()
        {
            fileNames = new string[] {"Balloons","BombEnemy", "Bubble", "DesertBlocks", "Pirate", "Player1", "Powerups", "Rides", "OctobossFull", "Sneaker", "Turtle", "Bomb", "Coin", "Coinbag", "Potion", "bomberman_enemies", "bombermanII_enemies","blue_background","splash", "door", "kick" };
            spriteSheets = new Texture2D[fileNames.Length];
            fonts = new SpriteFont[1];
        }
        public static void LoadAllTextures(ContentManager content)
        {
            DefineArrays();
            for (int i = 0; i < fileNames.Length; i++)
            {
                spriteSheets[i] = content.Load<Texture2D>(fileNames[i]);
            }
            fonts[0] = content.Load<SpriteFont>("testFont");
        }
        public static Texture2D GetNull()
        {
            return spriteSheets[0];
        }
        public static Texture2D GetBallons()
        {
            return spriteSheets[0];
        }

        public static Texture2D GetBombEnemy()
        {
            return spriteSheets[1];
        }
        public static Texture2D GetBubble()
        {
            return spriteSheets[2];
        }

        public static Texture2D GetDesertBlocks()
        {
            return spriteSheets[3];
        }

        public static Texture2D GetPirate()
        {
            return spriteSheets[4];

        }

        public static Texture2D GetPlayer(bool isPirate)
        {
            return isPirate ? GetPirate() : spriteSheets[5];
        }

        public static Texture2D GetPowerUps()
        {
            return spriteSheets[6];
        }
        public static Texture2D GetRides()
        {
            return spriteSheets[7];
        }
        public static Texture2D GetOctoBoss()
        {
            return spriteSheets[8];
        }
        public static Texture2D GetRollerskates()
        {
            return spriteSheets[9];
        }
        public static Texture2D GetTurtle()
        {
            return spriteSheets[10];
        }
        public static Texture2D GetBomb()
        {
            return spriteSheets[11];
        }
        public static Texture2D GetCoin()
        {
            return spriteSheets[12];
        }
        public static Texture2D GetCoinbag()
        {
            return spriteSheets[13];
        }
        public static Texture2D GetPotion()
        {
            return spriteSheets[14];
        }
        public static Texture2D GetBombermanEnemies()
        {
            return spriteSheets[15];
        }
        public static Texture2D GetBombermanIIEnemies()
        {
            return spriteSheets[16];
        }
        public static Texture2D GetBlueBackground()
        {
            return spriteSheets[17];
        }
        public static Texture2D GetSplashImage()
        {
            return spriteSheets[18];
        }

        public static Texture2D GetDoor()
        {
            return spriteSheets[19];
        }
        public static Texture2D GetKick()
        {
            return spriteSheets[20];
        }
        public static SpriteFont getTestFont()
        {
            return fonts[0];
        }



    }
}