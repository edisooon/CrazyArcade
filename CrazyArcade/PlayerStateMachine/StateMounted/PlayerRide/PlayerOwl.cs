using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using CrazyArcade.GameGridSystems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace CrazyArcade.PlayerStateMachine
{
    public class PlayerOwl : PlayerRide
    {
        private SpriteAnimation[] spriteAnims;
        private static Texture2D turtleTexture;

        public override SpriteAnimation SpriteAnim => spriteAnims[(int)direction];
        public PlayerOwl(Character character) : base(character)
        {
            this.spriteAnims = new SpriteAnimation[4];
            // public SpriteAnimation(Texture2D texture, int startX, int startY, int width, int height, int frames, int offset, int fps) : base(texture, startX, startY, frames, width, height, offset )
            spriteAnims[(int)Dir.Up] = new SpriteAnimation(ridesTexture, 335, 11, 35, 33, 2, 5, 6);
            spriteAnims[(int)Dir.Down] = new SpriteAnimation(ridesTexture, 335, 51, 35, 33, 2, 5, 6);
            spriteAnims[(int)Dir.Left] = new SpriteAnimation(ridesTexture, 336, 90, 35, 33, 2, 5, 6);
            spriteAnims[(int)Dir.Right] = new SpriteAnimation(ridesTexture, 336, 129, 35, 33, 2, 5, 6);
            //for (int i = 0; i < 4; i++)
            //{
            //    spriteAnims[i].SetScale(CAGameGridSystems.BlockLength / 31f);
            //}
            character.ModifiedSpeed = 3;
        }
        public override void UpdateOffset()
        {
            if (direction == Dir.Left)
            {
                xOffset = 2;
            }
            else
            {
                xOffset = 4;
            }
        }
        public override void Update(GameTime time)
        {
            if (character.playerState is CharacterStateF2M) return;
            UpdateOffset();
            X = character.X + xOffset;
            Y = character.Y + yOffset;
            direction = character.direction;
        }
    }
}
