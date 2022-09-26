using System;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFramework.Controller;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace CrazyArcade.Graphics
{
    public class StarProjectileSprite: CAEntity
    {
        private int i;
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
        private Rectangle[] starFrames;
        public Rectangle outputFrame1;
        

        public Rectangle inputFrame;
        //public static Rectangle[] InputFramesLeft;

        public StarProjectileSprite(int x, int y,int x_direction, int y_direction)
        {
            X = x;
            Y = y;  
            Xdirection = x_direction;   
            Ydirection = y_direction;
        }
        public override Texture2D Texture
        {
            get { return texture; }
        }

        public override Rectangle InputFrame
        {
            get { return inputFrame; }
        }
        public override Rectangle OutputFrame
        {
            get { return outputFrame1; }
        }
        public override Color Tint
        {
            get { return tint; }
        }

        public override void Load()
        {

            size = 20;
            X = 100;
            Y = 240;
            movingX = 0;
            movingY = 0;
            timer = 0;
            threshold = 120;
            texture = TextureSingleton.GetSunBoss();
            
            outputFrame1 = new Rectangle(X + movingX, Y + movingY, size, size);
            tint = Color.White;
            i = 0;
            starFrames = new Rectangle[6];
            starFrames[0] = new Rectangle(193, 291, 13, 13);
            starFrames[1] = new Rectangle(207, 294, 9, 9);
            starFrames[2] = new Rectangle(217, 296, 5, 5);
            starFrames[3] = new Rectangle(223, 290, 15, 15);
            starFrames[4] = new Rectangle(239, 292, 11, 11);
            starFrames[5] = new Rectangle(251, 294, 7, 7);
            inputFrame = starFrames[0];
        }


        public override void Update(GameTime time)
        {
            
            if (timer > threshold)
            {
                if (i == 5)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
                movingX = movingX + 5;
                movingY = movingY + 5;
                outputFrame1 = new Rectangle(X + (Xdirection*movingX), Y + (Ydirection*movingY), size,size );
                
                inputFrame = starFrames[i];
                timer = 0;
            }
            else
            {
                timer += (float)time.ElapsedGameTime.TotalMilliseconds;
            }

        }
        
    }
    public class SunBodySprite : CAEntity
    {
        private bool state; 
        private int X;
        private int Y;
        private int movingX;
        //private int movingY;
        private int size;
        float timer;
        float threshold;
        private Texture2D texture;
        private Color tint;
        private Rectangle outputFrame;
        private Rectangle inputFrame;
        
        
        public SunEnemySprite(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override Texture2D Texture
        {
            get { return texture; }
        }

        public override Rectangle InputFrame
        {
            get { return inputFrame; }
        }
        public override Rectangle OutputFrame
        {
            get { return outputFrame; }
        }
        public override Color Tint
        {
            get { return tint; }
        }
       

        public override void Load()
        {
            state = true;
            movingX = 0;
            timer = 0;
            size = 150;
            threshold = 80;
            texture = TextureSingleton.GetSunBoss();
            inputFrame = new Rectangle(0, 403, 90, 90);
            outputFrame = new Rectangle(X, Y, size, size);
            tint = Color.White;
        }


        public override void Update(GameTime time)
        {
            if (timer > threshold)
            {
 
                
                
                if (state)
                {
                    movingX = movingX + 10;
                    
                    if (movingX >= 300)
                    {
                        state = false;
                        inputFrame = new Rectangle(0,311,90,90);
                    }
                }
                else
                {
                   
                    movingX = movingX - 10;
                    if (movingX < 280)
                    {
                        inputFrame = new Rectangle(0, 403, 90, 90);
                    }
                    if (movingX <= 0)
                    {
                        state = true;
                    }
                }
                outputFrame = new Rectangle(X + movingX, Y, size, size);
                timer = 0;


            }
            else
            {
                timer += (float)time.ElapsedGameTime.TotalMilliseconds;
            }

        }
        


    }
}