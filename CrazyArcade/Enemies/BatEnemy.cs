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
    public class BatEnemySprite : CAEntity

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

        public BatEnemySprite(int x, int y)
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
            InputFramesRight[0] = new Rectangle(57, 134, 15, 16);
            InputFramesRight[1] = new Rectangle(75, 134, 16, 16);
            InputFramesRight[2] = new Rectangle(93, 134, 13, 16);
            InputFramesRight[3] = new Rectangle(75, 134, 16, 16);

            InputFramesLeft[0] = new Rectangle(57, 134, 15, 16);
            InputFramesLeft[1] = new Rectangle(75, 134, 16, 16);
            InputFramesLeft[2] = new Rectangle(93, 134, 13, 16);
            InputFramesLeft[3] = new Rectangle(75, 134, 16, 16);

            InputFramesUp[0] = new Rectangle(111, 134, 16, 16);
            InputFramesUp[1] = new Rectangle(129, 134, 16, 16);
            InputFramesUp[2] = new Rectangle(147, 134, 16, 16);
            InputFramesUp[3] = new Rectangle(129, 134, 16, 16);

            InputFramesDown[0] = new Rectangle(3, 134, 16, 16);
            InputFramesDown[1] = new Rectangle(21, 134, 16, 16);
            InputFramesDown[2] = new Rectangle(39, 134, 16, 16);
            InputFramesDown[3] = new Rectangle(21, 134, 16, 16);

            //Texture2D texture
            timer = 0;
            this.spriteAnims[(int)Dir.Up] = new SpriteAnimation(TextureSingleton.GetBombermanIIEnemies(), InputFramesUp, 6);
            this.spriteAnims[(int)Dir.Down] = new SpriteAnimation(TextureSingleton.GetBombermanIIEnemies(), InputFramesDown, 6);
            this.spriteAnims[(int)Dir.Left] = new SpriteAnimation(TextureSingleton.GetBombermanIIEnemies(), InputFramesLeft, 6);
            this.spriteAnims[(int)Dir.Right] = new SpriteAnimation(TextureSingleton.GetBombermanIIEnemies(), InputFramesRight, 6);
            foreach (SpriteAnimation anim in this.spriteAnims)
            {
                anim.setWidthHeight(30, 30);
                anim.Position = new Vector2(X, Y);
            }
        }

        public override void Update(GameTime time)
        {

            // handled animation updated (position and frame) in abstract level

            SpriteAnim.Position = new Vector2(X, Y);
            SpriteAnim.setEffect(effect);
            SpriteAnim.Update(time);
           

            xDifference = X - (int)Start.X;
            yDifference = Y - (int)Start.Y;

            if (timer > 1f/6)
            {
                if (direction == Dir.Right)

                {

                    if (xDifference >= 200)
                    {

                        direction = Dir.Up;
                        effect = SpriteEffects.None;
                        this.spriteAnims[(int)direction].Position = new Vector2(X, Y);


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
                        this.spriteAnims[(int)direction].Position = new Vector2(X, Y);
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
                        this.spriteAnims[(int)direction].Position = new Vector2(X, Y);
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
                        this.spriteAnims[(int)direction].Position = new Vector2(X, Y);
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



