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

        public PlayerRide(Character character)
        {
            ridesTexture = TextureSingleton.GetRides();
            this.character = character;
            X = character.X;
            Y = character.Y;
            DrawOrder = character.ActualDrawOrder - 2;

            yOffset = 35;
            direction = character.direction;

        }

        public void Delete_Self()
        {
            character.SceneDelegate.ToRemoveEntity(this);
        }
    }
}
