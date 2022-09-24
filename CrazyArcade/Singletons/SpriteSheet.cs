using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.Singletons
{
	public static class SpriteSheet
	{
		public static ContentManager Content;
        //private static Texture2D character;
        private static Texture2D characterWalkUp;
        private static Texture2D characterWalkDown;
        private static Texture2D characterWalkLeft;
        private static Texture2D characterWalkRight;
        public static void LoadAllTextures(ContentManager content)
        {
            //character = content.Load<Texture2D>("walk");
            characterWalkUp = content.Load<Texture2D>("walk_up");
            characterWalkDown = content.Load<Texture2D>("walk_down");
            characterWalkLeft = content.Load<Texture2D>("walk_left");
            characterWalkRight = content.Load<Texture2D>("walk_right");
        }

        public static Texture2D CharacterWalkUp
        {
            get
            {
                if (characterWalkUp == null)
                {
                    characterWalkUp = Content.Load<Texture2D>("walk_up");
                }
                return characterWalkUp;
            }
        }

        public static Texture2D CharacterWalkDown
        {
            get
            {
                if (characterWalkDown == null)
                {
                    characterWalkDown = Content.Load<Texture2D>("walk_down");
                }
                return characterWalkDown;
            }
        }

        public static Texture2D CharacterWalkLeft
        {
            get
            {
                if (characterWalkLeft == null)
                {
                    characterWalkLeft = Content.Load<Texture2D>("walk_left");
                }
                return characterWalkLeft;
            }
        }

        public static Texture2D CharacterWalkRight
        {
            get
            {
                if (characterWalkRight == null)
                {
                    characterWalkRight = Content.Load<Texture2D>("walk_right");
                }
                return characterWalkRight;
            }
        }

        //      public static Texture2D Character
        //{
        //	get
        //	{

        //              if (character == null)
        //              {
        //			character = Content.Load<Texture2D>("walk");
        //              }
        //		return character;
        //          }
        //}
    }
}

