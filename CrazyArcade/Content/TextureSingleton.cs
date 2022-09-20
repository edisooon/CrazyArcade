using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace CrazyArcade.Content
{
    //How to use:
    //TextureSingleton.LoadAllTextures(this.Content);
    //Texture2D texture = TextureSingleton.GetPlayer1Death();
    public class TextureSingleton
    {
        private static Texture2D player1Sheet;

        private static TextureSingleton instance = new TextureSingleton();
        private TextureSingleton() { }
        public static TextureSingleton Instance {
            get 
            {

                return instance; 
            } 
        }
        public static void LoadAllTextures(ContentManager content)
        {
            player1Sheet = content.Load<Texture2D>("Player1Death");
        }

        public static Texture2D GetPlayer1Death()
        {
            return player1Sheet;
        }
        
    }
}