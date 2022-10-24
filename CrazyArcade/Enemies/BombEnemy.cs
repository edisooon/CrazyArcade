using System;
using System.Threading;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFramework.Controller;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace CrazyArcade.Enemies
{
	public class BombEnemySprite: Enemy

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
        int fps;

        public override SpriteAnimation SpriteAnim => spriteAnims[(int)direction];

        public BombEnemySprite(int x, int y)
		{
            this.spriteAnims = new SpriteAnimation[4];
            direction =Dir.Down;
            internalRectangle.X = (int)GameCoord.X;
            internalRectangle.Y = (int)GameCoord.Y;
            ScreenCoord = new Vector2(x, y);
            Start = new Vector2((float)x, (float)y);//Could be wrong interperetation
        }

        public override void Load()
        {
            fps = 6;
            dirList = new Dir[4];
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
            InputFramesDown[2] = new Rectangle(1125, 9,133, 143);
            //Texture2D texture
            timer = 0;
            this.spriteAnims[(int)Dir.Up] = new SpriteAnimation(TextureSingleton.GetBombEnemy(), InputFramesUp,fps); 
            this.spriteAnims[(int)Dir.Down] = new SpriteAnimation(TextureSingleton.GetBombEnemy(), InputFramesDown,fps);
            this.spriteAnims[(int)Dir.Left] = new SpriteAnimation(TextureSingleton.GetBombEnemy(), InputFramesLeft,fps);
            this.spriteAnims[(int)Dir.Right] = new SpriteAnimation(TextureSingleton.GetBombEnemy(), InputFramesRight,fps);
            foreach (SpriteAnimation anim in this.spriteAnims)
            {
                anim.setWidthHeight(30,30);  
                anim.Position = GameCoord;
            }
        }

        public override void Update(GameTime time)
        {

            // handled animation updated (position and frame) in abstract level

            SpriteAnim.Position = GameCoord;
            SpriteAnim.Update(time);

            xDifference = (int)GameCoord.X - (int)Start.X;
            yDifference = (int)GameCoord.Y - (int)Start.Y;

            if (timer > 1f/fps)
            {
                if (direction == Dir.Right)
                {
                    
                    if (xDifference >= 200)
                    {
                        
                        direction = Dir.Up;
                        this.spriteAnims[(int)direction].Position = GameCoord;
                    }
                    else
                    {
                        GameCoord = new Vector2((int)GameCoord.X + 10, GameCoord.Y);
                    }
                }
                else if (direction == Dir.Up)
                {
                    if (yDifference <= 0)
                    {
            
                        direction = Dir.Left;
                        this.spriteAnims[(int)direction].Position = GameCoord;
                    }
                    else
                    {
                        GameCoord = new Vector2(GameCoord.X, (int)GameCoord.Y - 10);
                    }
                }
                else if (direction == Dir.Left)
                {
                    if (xDifference <= 0)
                    {

                        direction = Dir.Down;
                        this.spriteAnims[(int)direction].Position = GameCoord;
                    }
                    else
                    {
                        GameCoord = new Vector2((int)GameCoord.X - 10, GameCoord.Y);
                    }
                }
                else if (direction == Dir.Down)
                {
                    if (yDifference >= 200)
                    {
                        
                        direction = Dir.Right;
                        this.spriteAnims[(int)direction].Position = GameCoord;
                    }
                    else
                    {
                        GameCoord = new Vector2(GameCoord.X, (int)GameCoord.Y + 10);
                    }
                }
                timer = 0;
            }
            else
            {
                timer += (float)time.ElapsedGameTime.TotalMilliseconds;
            }
            internalRectangle.X = (int)GameCoord.X;
            internalRectangle.Y = (int)GameCoord.Y;
        }



    }
}



