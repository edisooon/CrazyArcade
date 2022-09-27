using System;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFramework.Controller;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace CrazyArcade.Graphics
{

    public class BombEnemySprite : CAEntity
    {
        private int i;
        private int X;
        private int Y;
        private int movingX;
        private int movingY;
        float timer;
        float threshold;
        private Texture2D texture;
        private Color tint;
        private Rectangle outputFrame;
        private Rectangle inputFrame;
        public static Rectangle[] InputFramesRight;
        public static Rectangle[] InputFramesLeft;
        public static Rectangle[] InputFramesUp;
        public static Rectangle[] InputFramesDown;
        public static Rectangle[] currentDirectionArray;
        public BombEnemySprite(int x, int y)
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

            movingX = 0;
            movingY = 60;
            timer = 0;
            threshold = 200;
            InputFramesRight = new Rectangle[3];
            InputFramesUp = new Rectangle[3];
            InputFramesLeft = new Rectangle[3];
            InputFramesDown = new Rectangle[3];
            InputFramesRight[0] = new Rectangle(1890, 6, 140, 135);
            InputFramesRight[1] = new Rectangle( 2037, 5, 260, 245);
            InputFramesRight[2] = new Rectangle(2300, 5, 205, 202);
            InputFramesUp[0] = new Rectangle( 6, 3, 198, 206);
            InputFramesUp[1] = new Rectangle( 206, 0, 230, 212);
            InputFramesUp[2] = new Rectangle(440, 2,135, 145);
            InputFramesLeft[0] = new Rectangle(1260, 2,244, 244);
            InputFramesLeft[1] = new Rectangle(1509, 2, 124, 124 );
            InputFramesLeft[2] = new Rectangle(1636, 2, 247, 239 );
            InputFramesDown[0] = new Rectangle(579, 7, 241, 256 );
            InputFramesDown[1] = new Rectangle(832, 0, 285, 299 );
            InputFramesDown[2] = new Rectangle(1125, 9,133, 143) ;
            currentDirectionArray = InputFramesRight;
            texture = TextureSingleton.GetBombEnemy();
            inputFrame = currentDirectionArray[0];
            outputFrame = new Rectangle(X, Y, 50, 50);
            tint = Color.White;
            i = 0;
        }


        public override void Update(GameTime time)
        {
            if (timer > threshold)
            {
                if (i == 2)
                {
                    i = 1;
                }
                else
                {
                    i++;
                }
                if (currentDirectionArray == InputFramesRight)
                {
                    if (movingX >= 60)
                    {
                        //change to next array
                        currentDirectionArray = InputFramesUp;
                        i = 0;
                    }
                    else
                    {
                        movingX = movingX + 10;
                    }


                }
                else if (currentDirectionArray == InputFramesUp)
                {
                    if (movingY <= 0)
                    {
                        //change to next array
                        currentDirectionArray = InputFramesLeft;
                        i = 0;
                    }
                    else
                    {
                        movingY = movingY - 10;
                    }
                }
                else if (currentDirectionArray == InputFramesLeft)
                {
                    if (movingX <= 0)
                    {
                        //change to next array
                        currentDirectionArray = InputFramesDown;
                        i = 0;
                    }
                    else
                    {
                        movingX = movingX - 10;
                    }
                }
                else if (currentDirectionArray == InputFramesDown)
                {
                    if (movingY >= 60)
                    {
                        //change to next array
                        currentDirectionArray = InputFramesRight;
                        i = 0;
                    }
                    else
                    {
                        movingY = movingY + 10;
                    }
                }

                outputFrame = new Rectangle(X+movingX, Y+movingY, 50, 50);
                inputFrame = currentDirectionArray[i];
                timer = 0;
            }
            else
            {
                timer += (float)time.ElapsedGameTime.TotalMilliseconds;
            }
            

        }
    }
}