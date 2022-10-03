using System;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFramework.Controller;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace CrazyArcade.Demo1
{
    public class OctopusEnemy : CAEntity
    {
        private int X;
        private int Y;
        private int Xdirection;
        private int Ydirection;
        private int movingX;
        private int movingY;
        private int size;
        float timer;
        float threshold;
        private Texture2D texture;
        private Color tint;
        public Rectangle outputFrame1;
        public SpriteAnimation spriteAnims;//change to array, add other directions
        public override SpriteAnimation SpriteAnim => spriteAnims;


        public Rectangle inputFrame;

        //public static Rectangle[] InputFramesLeft;

        public OctopusEnemy(int x, int y, int x_direction, int y_direction)
        {
            texture = TextureSingleton.GetOctoBoss();
            //Texture2D Texture, int startPositionX, int startPositionY, int frames, int width, int height
            spriteAnims = new SpriteAnimation(texture,2,5);

            X = x;
            Y = y;
            Xdirection = x_direction;
            Ydirection = y_direction;
        }

        public override void Load()
        {
            size = 95;
            X = 500;
            Y = 500;
            movingX = 300;
            movingY = 300;
            timer = 0;
            threshold = 120;
            texture = TextureSingleton.GetOctoBoss();
            outputFrame1 = new Rectangle(X + movingX, Y + movingY, size, size);
            tint = Color.White;
        }


        public override void Update(GameTime time)
        {
            SpriteAnim.Position = new Vector2(475, 200);

            spriteAnims.Update(time);
            timer = timer % threshold;
            if (timer>threshold/2)
            {
                Xdirection *= -1;
            }
            outputFrame1 = new Rectangle(X + Xdirection * movingX, Y + Ydirection * movingY, size, size);

        }

    }
}