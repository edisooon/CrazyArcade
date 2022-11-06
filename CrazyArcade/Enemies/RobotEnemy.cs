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


        public override SpriteAnimation SpriteAnim => spriteAnims[(int)direction];

        public RobotEnemySprite(int x, int y, CAScene scene) : base(x, y, scene)
        {
            this.spriteAnims = new SpriteAnimation[4];
        }

        public override void Load()
        {
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
 
            this.spriteAnims[(int)Dir.Up] = new SpriteAnimation(TextureSingleton.GetBombermanEnemies(), InputFramesUp, 6);
            this.spriteAnims[(int)Dir.Down] = new SpriteAnimation(TextureSingleton.GetBombermanEnemies(), InputFramesDown, 6);
            this.spriteAnims[(int)Dir.Left] = new SpriteAnimation(TextureSingleton.GetBombermanEnemies(), InputFramesLeft, 6);
            this.spriteAnims[(int)Dir.Right] = new SpriteAnimation(TextureSingleton.GetBombermanEnemies(), InputFramesRight, 6);
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



