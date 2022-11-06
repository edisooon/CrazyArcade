using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
namespace CrazyArcade.Enemies
{
	public class BombEnemySprite: Enemy

	{
        
        private Rectangle[] InputFramesRight;
        private Rectangle[] InputFramesLeft;
        private Rectangle[] InputFramesUp;
        private Rectangle[] InputFramesDown;
        private Dir[] dirList;
        float timer;
        int fps;

        public override SpriteAnimation SpriteAnim => spriteAnims[(int)direction];

        public BombEnemySprite(int x, int y, CAScene scene) : base(x, y, scene)
		{
            this.spriteAnims = new SpriteAnimation[4];
            
        }
        public override void Load()
        {
            direction = Dir.Down;
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
            this.spriteAnims[(int)Dir.Right] = new SpriteAnimation(TextureSingleton.GetBombEnemy(), InputFramesLeft, fps);
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



