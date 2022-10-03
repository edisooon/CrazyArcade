using System;
using System.Threading;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFramework.Controller;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace CrazyArcade.Enemy
{
    public class RobotEnemySprite : CAEntity

    {
        private SpriteAnimation[] spriteAnims;
        private Dir direction;
        private Rectangle[] InputFramesRight;
        private Rectangle[] InputFramesLeft;
        private Rectangle[] InputFramesUp;
        private Rectangle[] InputFramesDown;
        private Vector2 Start;
        private int xDifference;
        private int yDifference;
        private Dir[] dirList;
        float timer;
        SpriteEffects effect;

        public override SpriteAnimation SpriteAnim => spriteAnims[(int)direction];

        public RobotEnemySprite(int x, int y)
        {
            this.spriteAnims = new SpriteAnimation[4];
            X = x;
            Y = y;
            Start = new Vector2((float)X, (float)Y);

        }

        public override void Load()
        {
            direction = Dir.Down;
            effect = SpriteEffects.None;
            dirList = new Dir[4];
            InputFramesRight = new Rectangle[4];
            InputFramesUp = new Rectangle[4];
            InputFramesLeft = new Rectangle[4];
            InputFramesDown = new Rectangle[4];
            InputFramesRight[0] = new Rectangle(1, 4, 16, 21);
            InputFramesRight[1] = new Rectangle(18, 3, 16, 22);
            InputFramesRight[2] = new Rectangle(35, 3, 16, 22);
            InputFramesRight[3] = new Rectangle(52, 2, 16, 23);
            InputFramesLeft[0] = new Rectangle(1, 4, 16, 21);
            InputFramesLeft[1] = new Rectangle(18, 3, 16, 22);
            InputFramesLeft[2] = new Rectangle(35, 3, 16, 22);
            InputFramesLeft[3] = new Rectangle(52, 2, 16, 23);
            InputFramesUp[0] = new Rectangle(137, 4, 16, 21);
            InputFramesUp[1] = new Rectangle(154, 3, 16, 22);
            InputFramesUp[2] = new Rectangle(171, 3, 16, 22);
            InputFramesUp[3] = new Rectangle(188, 1, 16, 24);
            InputFramesDown[0] = new Rectangle(69, 4, 16, 21);
            InputFramesDown[1] = new Rectangle(86, 3, 16, 22);
            InputFramesDown[2] = new Rectangle(103, 3, 16, 22);
            InputFramesDown[3] = new Rectangle(120, 2, 16, 23);
            //Texture2D texture
            timer = 0;
            this.spriteAnims[(int)Dir.Up] = new SpriteAnimation(TextureSingleton.GetBombermanEnemies(), InputFramesUp, 6);
            this.spriteAnims[(int)Dir.Down] = new SpriteAnimation(TextureSingleton.GetBombermanEnemies(), InputFramesDown, 6);
            this.spriteAnims[(int)Dir.Left] = new SpriteAnimation(TextureSingleton.GetBombermanEnemies(), InputFramesLeft, 6);
            this.spriteAnims[(int)Dir.Right] = new SpriteAnimation(TextureSingleton.GetBombermanEnemies(), InputFramesRight, 6);
            foreach (SpriteAnimation anim in this.spriteAnims)
            {
                anim.setWidthHeight(50, 50);
            }
        }

        public override void Update(GameTime time)
        {

            // handled animation updated (position and frame) in abstract level

            SpriteAnim.Position = new Vector2(X, Y);
            SpriteAnim.Update(time);
            SpriteAnim.setEffect(effect);

            xDifference = X - (int)Start.X;
            yDifference = Y - (int)Start.Y;

            if (timer > 6 / 1f)
            {
                if (direction == Dir.Right)

                {

                    if (xDifference >= 200)
                    {
                        
                        direction = Dir.Up;
                        effect = SpriteEffects.None;



                    }
                    else
                    {
                        X = X + 10;
                    }
                }
                else if (direction == Dir.Up)
                {
                    if (yDifference <= 0)
                    {

                        direction = Dir.Left;
                        effect = SpriteEffects.None;
                    }
                    else
                    {
                        Y = Y - 10;
                    }
                }
                else if (direction == Dir.Left)
                {
                    if (xDifference <= 0)
                    {

                        direction = Dir.Down;
                        effect = SpriteEffects.None;
                    }
                    else
                    {
                        X = X - 10;
                    }
                }
                else if (direction == Dir.Down)
                {
                    if (yDifference >= 200)
                    {

                        direction = Dir.Right;
                        effect = SpriteEffects.FlipHorizontally;
                    }
                    else
                    {
                        Y = Y + 10;
                    }
                }
                timer = 0;
            }
            else
            {
                timer += (float)time.ElapsedGameTime.TotalMilliseconds;
            }
        }



    }
}



