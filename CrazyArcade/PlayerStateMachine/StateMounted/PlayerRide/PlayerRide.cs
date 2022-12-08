using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using CrazyArcade.GameGridSystems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace CrazyArcade.PlayerStateMachine
{
    public abstract class PlayerRide : CAEntity
    {
        protected Character character;
        protected Dir direction;
        protected static Texture2D ridesTexture;
        protected int xOffset;
        protected int yOffset;
        protected int initialX;
        protected int initialY;

        public PlayerRide(Character character)
        {
            ridesTexture = TextureSingleton.GetRides();
            this.character = character;
            DrawOrder = character.ActualDrawOrder - 2;

            yOffset = CAGameGridSystems.BlockLength;
            direction = character.direction;
            UpdateOffset();
            X = character.X + xOffset;
            Y = character.Y - character.bboxOffset.Y + yOffset;

        }

        public abstract void UpdateOffset();

        public void Delete_Self()
        {
            character.SceneDelegate.ToRemoveEntity(this);
        }
    }
}
