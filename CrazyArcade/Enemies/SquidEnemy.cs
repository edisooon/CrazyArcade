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
    public class SquidEnemySprite : Enemy

    {
        private SpriteAnimation[] spriteAnims;
        private Rectangle[] InputFramesRight;
        private Rectangle[] InputFramesLeft;
        private Rectangle[] InputFramesUp;
        private Rectangle[] InputFramesDown;
        private Dir[] dirList;
        float timer;

        public override SpriteAnimation SpriteAnim => spriteAnims[(int)direction];

        public SquidEnemySprite(int x, int y) : base(x, y)
        {
            this.spriteAnims = new SpriteAnimation[4];
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
            InputFramesRight[0] = new Rectangle(18, 345, 16, 22);
            InputFramesRight[1] = new Rectangle(1, 343, 16, 24);
            InputFramesRight[2] = new Rectangle(18, 345, 16, 22);
            InputFramesRight[3] = new Rectangle(35, 347, 16, 20);
            InputFramesLeft[0] = new Rectangle(18, 345, 16, 22);
            InputFramesLeft[1] = new Rectangle(1, 343, 16, 24);
            InputFramesLeft[2] = new Rectangle(18, 345, 16, 22);
            InputFramesLeft[3] = new Rectangle(35, 347, 16, 20);
            InputFramesUp[0] = new Rectangle(154, 345, 16, 22);
            InputFramesUp[1] = new Rectangle(171, 347, 16, 20);
            InputFramesUp[2] = new Rectangle(154, 345, 16, 22);
            InputFramesUp[3] = new Rectangle(137, 343, 16, 24);
            InputFramesDown[0] = new Rectangle(86, 345, 16, 22);
            InputFramesDown[1] = new Rectangle(103, 347, 16, 20);
            InputFramesDown[2] = new Rectangle(86, 345, 16, 22);
            InputFramesDown[3] = new Rectangle(69, 343, 16, 24);
            //Texture2D texture
            timer = 0;
            this.spriteAnims[(int)Dir.Up] = new SpriteAnimation(TextureSingleton.GetBombermanEnemies(), InputFramesUp, 6);
            this.spriteAnims[(int)Dir.Down] = new SpriteAnimation(TextureSingleton.GetBombermanEnemies(), InputFramesDown, 6);
            this.spriteAnims[(int)Dir.Left] = new SpriteAnimation(TextureSingleton.GetBombermanEnemies(), InputFramesLeft, 6);
            this.spriteAnims[(int)Dir.Right] = new SpriteAnimation(TextureSingleton.GetBombermanEnemies(), InputFramesRight, 6);
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


            xDifference = GameCoord.X - Start.X;
            yDifference = GameCoord.Y - Start.Y;

            if (timer > 1f / 6)
            {
                move(direction);
            }
            else
            {
                timer += (float)time.ElapsedGameTime.TotalMilliseconds;
            }
            internalRectangle.X = X;
            internalRectangle.Y = Y;
        }

        protected override Vector2[] SpeedVector => speedVector;

        /*
            Up = 0,
            Left = 1,
            Down = 2,
            Right = 3
         */
        Vector2[] speedVector =
        {
            new Vector2(0.0f, -0.1f),
            new Vector2(-0.1f, 0.0f),
            new Vector2(0.0f, 0.1f),
            new Vector2(0.1f, 0.0f),
        };
        public override void UpdateAnimation(Dir dir)
        {
            this.spriteAnims[(int)direction].Position = new Vector2(X, Y);
        }

        void updateCoord()
        {

        }


    }
}



