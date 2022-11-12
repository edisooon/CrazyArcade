using System;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFramework.Controller;
using CrazyArcade.Enemies;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace CrazyArcade.Boss
{
    public class OctopusEnemy : Enemy
    {
        private Texture2D texture;
        private Rectangle[] InputFramesRight;
        private Rectangle[] InputFramesLeft;
        private Rectangle[] InputFramesUp;
        private Rectangle[] InputFramesDown;
        private Color tint;
        public Rectangle outputFrame1;
        public override SpriteAnimation SpriteAnim => spriteAnims[(int)direction];


        public Rectangle inputFrame;


        public OctopusEnemy(int x, int y, CAScene scene) : base(x, y, scene)
        {
            texture = TextureSingleton.GetOctoBoss();
            spriteAnims = new SpriteAnimation[4];
            X = x;
            Y = y;
        }

        public override void Load()
        {
            direction = Dir.Down;
            effect = SpriteEffects.None;
            texture = TextureSingleton.GetOctoBoss();
            InputFramesRight = new Rectangle[1];
            InputFramesUp = new Rectangle[1];
            InputFramesLeft = new Rectangle[1];
            InputFramesDown = new Rectangle[2];
            InputFramesRight[0] = new Rectangle(803, 21, 104, 148);

            InputFramesLeft[0] = new Rectangle(614, 23, 102, 144);

            InputFramesUp[0] = new Rectangle(421, 26, 107, 138);

            InputFramesDown[0] = new Rectangle(41, 23, 107, 144);
            InputFramesDown[1] = new Rectangle(231, 24, 108, 141);

            texture = TextureSingleton.GetOctoBoss();
            tint = Color.White;
            // public SpriteAnimation(Texture2D texture, int startX, int startY, int width, int height, int frames, int offset, int fps) 
            deathAnimation = new SpriteAnimation(texture, 1941, 43, 108, 104, 1, 0, 1);
            deathAnimation.setWidthHeight(108, 104);
            deathAnimation.Position = new Vector2(X, Y);
            this.spriteAnims[(int)Dir.Up] = new SpriteAnimation(texture, InputFramesUp, fps);
            this.spriteAnims[(int)Dir.Down] = new SpriteAnimation(texture, InputFramesDown, fps);
            this.spriteAnims[(int)Dir.Left] = new SpriteAnimation(texture, InputFramesLeft, fps);
            this.spriteAnims[(int)Dir.Right] = new SpriteAnimation(texture, InputFramesRight, fps);
            foreach (SpriteAnimation anim in this.spriteAnims)
            {
                anim.setWidthHeight(30, 30);
                anim.Position = new Vector2(X, Y);
            }
        }

        protected override Vector2[] SpeedVector => speedVector;


        Vector2[] speedVector =
        {
            new Vector2(0.0f, -0.15f),
            new Vector2(-0.15f, 0.0f),
            new Vector2(0.0f, 0.15f),
            new Vector2(0.15f, 0.0f),
        };

    }
}