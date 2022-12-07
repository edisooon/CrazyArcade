using CrazyArcade.Blocks;
using CrazyArcade.BombFeature;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.SoundEffectSystem;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Formats.Asn1.AsnWriter;

namespace CrazyArcade.Enemies
{
    public class MimicEnemySprite : Enemy, IBombCollectable

    {
        private Texture2D texture;
        
        public override SpriteAnimation SpriteAnim => spriteAnims[0];

        public MimicEnemySprite(int x, int y) : base(x, y)
        {
            this.spriteAnims = new SpriteAnimation[1];
        }

        public override void Load()
        {
            base.Load();
            texture = TextureSingleton.GetBomb();
           
            effect = SpriteEffects.None;
            
            //Texture2D texture
            //death animation for enemyDeathState
            // public SpriteAnimation(Texture2D texture, int startX, int startY, int width, int height, int frames, int offset, int fps) 
            deathAnimation = new SpriteAnimation(texture, 5, 5);
            spriteAnims[(int)Dir.Up] = new SpriteAnimation(texture, 5, 5);
            spriteAnims[0].setWidthHeight(36, 36);
            spriteAnims[0].Color = Color.LightSlateGray;

        }
        
        public override void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            WaterBomb projectile = new WaterBomb(GameCoord, 2, this);
            SceneDelegate.ToAddEntity(new CASoundEffect("SoundEffects/PlaceBomb"));
            this.SceneDelegate.ToAddEntity(projectile);
            state = new EnemyDeathState(this);

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
            new Vector2(0.0f, 0.0f),
            new Vector2(0.0f, 0.0f),
            new Vector2(0.0f, 0.0f),
            new Vector2(0.0f, 0.0f),
        };
        void IBombCollectable.RecollectBomb()
        {

        }

        void IBombCollectable.SpendBomb()
        {

        }

		public override void UpdateAnimation()
		{
			this.spriteAnims[0].Position = new Vector2(X, Y);

		}
	}
}



