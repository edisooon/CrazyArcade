using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.Enemies
{
    public class RobotEnemySprite : Enemy

    {
        
        private Rectangle[] InputFramesRight;
        private Rectangle[] InputFramesLeft;
        private Rectangle[] InputFramesUp;
        private Rectangle[] InputFramesDown;
        private Texture2D texture;


        public override SpriteAnimation SpriteAnim => spriteAnims[(int)direction];

        public RobotEnemySprite(int x, int y) : base(x, y)
        {
            this.spriteAnims = new SpriteAnimation[4];
        }

        public override void Load()
        {
           
            texture = TextureSingleton.GetBombermanEnemies();
            direction = Dir.Down;
            effect = SpriteEffects.None;
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
            //death animation for enemyDeathState
            // public SpriteAnimation(Texture2D texture, int startX, int startY, int width, int height, int frames, int offset, int fps) 
            deathAnimation = new SpriteAnimation(texture, 205, 4, 16, 21, 1, 0, 1);
            deathAnimation.setWidthHeight(30, 30);
            deathAnimation.Position = new Vector2(X, Y);
            this.spriteAnims[(int)Dir.Up] = new SpriteAnimation(texture, InputFramesUp, fps);
            this.spriteAnims[(int)Dir.Down] = new SpriteAnimation(texture, InputFramesDown, fps);
            this.spriteAnims[(int)Dir.Left] = new SpriteAnimation(texture, InputFramesLeft, fps);
            this.spriteAnims[(int)Dir.Right] = new SpriteAnimation(texture, InputFramesRight, fps);
            foreach (SpriteAnimation anim in this.spriteAnims)
            {
                anim.setWidthHeight(30,30);
                anim.Position = new Vector2(X, Y);
            }
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
            new Vector2(0.0f, -0.075f),
            new Vector2(-0.075f, 0.0f),
            new Vector2(0.0f, 0.075f),
            new Vector2(0.075f, 0.0f),
        };


        void updateCoord()
        {

        }
    }
}



