using System;
using System.Threading;
using CrazyArcade.Boss;
using System.Timers;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFramework.Controller;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace CrazyArcade.Enemies
{
    public class BatEnemySprite : Enemy

    {
        private Rectangle[] InputFramesRight;
        private Rectangle[] InputFramesLeft;
        private Rectangle[] InputFramesUp;
        private Rectangle[] InputFramesDown;
        private Texture2D texture;
        public SunBossProjectile sunBossProjectile;

        public override SpriteAnimation SpriteAnim => spriteAnims[(int)direction];

        
        public BatEnemySprite(int x, int y) : base(x, y)
        {
            this.spriteAnims = new SpriteAnimation[4];
        }

        public override void Load()
        {
            direction = Dir.Down;
            effect = SpriteEffects.None;
            texture = TextureSingleton.GetBombermanIIEnemies();
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
            //death animation for enemyDeathState
            // public SpriteAnimation(Texture2D texture, int startX, int startY, int width, int height, int frames, int offset, int fps) 
            deathAnimation = new SpriteAnimation(texture, 165,134, 16, 16, 1, 0, 1);
            deathAnimation.setWidthHeight(30, 30);
            deathAnimation.Position = new Vector2(X, Y);
            spriteAnims[(int)Dir.Up] = new SpriteAnimation(texture, InputFramesUp, fps);
            spriteAnims[(int)Dir.Down] = new SpriteAnimation(texture, InputFramesDown, fps);
            spriteAnims[(int)Dir.Left] = new SpriteAnimation(texture, InputFramesLeft, fps);
            spriteAnims[(int)Dir.Right] = new SpriteAnimation(texture, InputFramesRight, fps);
            foreach (SpriteAnimation anim in spriteAnims)
            {
                anim.setWidthHeight(30, 30);
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
        readonly Vector2[] speedVector =
        {
            new Vector2(0.0f, -0.075f),
            new Vector2(-0.075f, 0.0f),
            new Vector2(0.0f, 0.075f),
            new Vector2(0.075f, 0.0f),
        };

        public override void ShootProjectile(GameTime time)
        {
            float speedScale = .2f;
            float centerOffset = .25f;
            Vector2 center = new(GameCoord.X + centerOffset, GameCoord.Y + centerOffset);
            sunBossProjectile = new SunBossProjectile(SceneDelegate, speedVector[(int)direction]* speedScale, center, new CATimer(time.TotalGameTime));
            SceneDelegate.ToAddEntity(sunBossProjectile);
        }


    }
}



