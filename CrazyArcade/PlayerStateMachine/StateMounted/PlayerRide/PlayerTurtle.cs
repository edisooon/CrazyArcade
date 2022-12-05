using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using CrazyArcade.GameGridSystems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace CrazyArcade.PlayerStateMachine
{
    public class PlayerTurtle : PlayerRide
    {
        private SpriteAnimation[] spriteAnims;
        private static Texture2D turtleTexture;

        public override SpriteAnimation SpriteAnim => spriteAnims[(int)direction];
        public PlayerTurtle(Character character) : base(character)
        {
            this.spriteAnims = new SpriteAnimation[4];
            // public SpriteAnimation(Texture2D texture, int startX, int startY, int width, int height, int frames, int offset, int fps) : base(texture, startX, startY, frames, width, height, offset )
            spriteAnims[(int)Dir.Up] = new SpriteAnimation(ridesTexture, 15, 5, 29, 31, 2, 18, 6);
            spriteAnims[(int)Dir.Down] = new SpriteAnimation(ridesTexture, 14, 37, 30, 31, 2, 19, 6);
            spriteAnims[(int)Dir.Left] = new SpriteAnimation(ridesTexture, 5, 69, 41, 31, 2, 5, 6);
            spriteAnims[(int)Dir.Right] = new SpriteAnimation(ridesTexture, 12, 101, 42, 31, 2, 5, 6);
            //for (int i = 0; i < 4; i++)
            //{
            //    spriteAnims[i].SetScale(CAGameGridSystems.BlockLength / 31f);
            //}
            character.ModifiedSpeed = 1;
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
            X = character.X + xOffset;
            Y = character.Y + yOffset;
            direction = character.direction;
        }
    }
}
