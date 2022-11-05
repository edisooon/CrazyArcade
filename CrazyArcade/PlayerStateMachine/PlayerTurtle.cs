using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


//Note: this is kept in the PlayerStateMachine namespace due to the lack of higher orginization for entities and the project in general.
namespace CrazyArcade.PlayerStateMachine
{
    public class PlayerTurtle : CAEntity
    {
        public Character player;
        public CAScene scene;

        private Dir direction;
        private SpriteAnimation[] spriteAnims;
        public SpriteAnimation currentAnimation;
        private static Texture2D turtleTexture;
        private int xOffset;
        private int yOffset;

        public override SpriteAnimation SpriteAnim => spriteAnims[(int)direction];
        public PlayerTurtle(Character player, CAScene scene)
        {
            turtleTexture = TextureSingleton.GetRides();
            this.player = player;
            this.scene = scene;
            X = player.X;
            Y = player.Y;
            DrawOrder = player.ActualDrawOrder -2;
            this.spriteAnims = new SpriteAnimation[4];
            // public SpriteAnimation(Texture2D texture, int startX, int startY, int width, int height, int frames, int offset, int fps) : base(texture, startX, startY, frames, width, height, offset )
            spriteAnims[(int)Dir.Up] = new SpriteAnimation(turtleTexture, 15, 5, 29, 30, 2, 18, 6);
            
            spriteAnims[(int)Dir.Down] = new SpriteAnimation(turtleTexture, 14, 37, 30, 31, 2, 19, 6);
            spriteAnims[(int)Dir.Left] = new SpriteAnimation(turtleTexture, 5, 69, 41, 31, 2, 5, 6);
            spriteAnims[(int)Dir.Right] = new SpriteAnimation(turtleTexture, 12, 101, 42, 31, 2, 5, 6);
            for (int i = 0; i < 4; i++)
            {
                spriteAnims[i].Scale = 1.1f;
            }
            direction = player.direction;
            currentAnimation = spriteAnims[(int)direction];

        }
        public override void Update(GameTime time)
        {
            if (direction == Dir.Up || direction == Dir.Down)
            {
                xOffset = 6;
            }
            else if (direction == Dir.Left)
            {
                xOffset = -5;
            }
            else
            {
                xOffset = 0;
            }
            X = player.X + xOffset;
            Y = player.Y + 35;
            direction = player.direction;
            currentAnimation = spriteAnims[(int)direction];
            currentAnimation.Update(time);
            if (player.playerState is not CharacterStateTurtle)
            {
                Delete_Self();
            }
        }

        public override void Load()
        {
            
        }

        public void Delete_Self()
        {
            scene.RemoveSprite(this);
        }
    }
}
