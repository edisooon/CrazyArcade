using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrazyArcade.Content
{
    //How to use:
    //TextureSingleton.LoadAllTextures(this.Content);
    //Texture2D texture = TextureSingleton.GetPlayer1Death();
    public class TextureSingleton
    {
        public static string[] fileNames;
        public static Texture2D[] spriteSheets;
        private static TextureSingleton instance = new TextureSingleton();
        private TextureSingleton() { }
        public static TextureSingleton Instance {
            get 
            {
                return instance; 
            } 
        }
        private static void DefineArrays()
        {
            fileNames = new string[] {"Bomb", "Bubble", "Cactus", "Coins", "Crate", "ExtraBomb", "flask", "Pirate",
                "PirateAttacked", "PirateStart", "Player1", "Player1Death", "Player1Hurt", "Player1Turtle",
                "SandBlockBuff", "SandGround", "Skates", "Stone", "Turtle", "TurtlePowerup", "WaterExplosion"};
            spriteSheets = new Texture2D[fileNames.Length];
        }
        public static void LoadAllTextures(ContentManager content)
        {
            DefineArrays();
            for (int i = 0; i < fileNames.Length; i++)
            {
                spriteSheets[i]= content.Load<Texture2D>(fileNames[i]);
            }
        }
        
        public static Texture2D GetBomb()
        {
            return spriteSheets[0];
        }
        public static Texture2D GetBubble()
        {
            return spriteSheets[1];
        }
        public static Texture2D GetCoins()
        {
            return spriteSheets[2];
        }
        public static Texture2D GetCrate()
        {
            return spriteSheets[3];
        }
        public static Texture2D GetBombPowerup()
        {
            return spriteSheets[4];

        }
        public static Texture2D GetFlask()
        {
            return spriteSheets[5];
        }
        public static Texture2D GetPirate()
        {
            return spriteSheets[6];
        }
        public static Texture2D GetPirateAttacked()
        {
            return spriteSheets[7];
        }
        public static Texture2D GetPirateStart()
        {
            return spriteSheets[8];
        }
        public static Texture2D GetPlayer1()
        {
            return spriteSheets[9];
        }
        public static Texture2D GetPlayer1Death()
        {
            return spriteSheets[10];
        }
        public static Texture2D GetPlayer1Hurt()
        {
            return spriteSheets[11];
        }
        public static Texture2D GetPlayer1Turtle()
        {
            return spriteSheets[12];
        }
        public static Texture2D GetSandBlock()
        {
            return spriteSheets[13];
        }
        public static Texture2D GetSandGround()
        {
            return spriteSheets[14];
        }
        public static Texture2D GetSkates()
        {
            return spriteSheets[15];
        }
        public static Texture2D GetStone()
        {
            return spriteSheets[16];
        }
        public static Texture2D GetTurtleRide()
        {
            return spriteSheets[17];
        }
        public static Texture2D GetTurtlePowerUp()
        {
            return spriteSheets[18];
        }
        public static Texture2D GetWaterExplosion()
        {
            return spriteSheets[19];
        }



    }
}