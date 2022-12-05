using CrazyArcade.CAFramework;
using CrazyArcade.Content;
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

            yOffset = 35;
            initialX = character.X;
            initialY = character.Y;
            X = character.X+xOffset;
            Y = character.Y+yOffset;
            direction = character.direction;

        }

        public void Delete_Self()
        {
            character.SceneDelegate.ToRemoveEntity(this);
        }
    }
}
