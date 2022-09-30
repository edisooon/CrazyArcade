using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrazyArcade.CAFramework
{
    public class SpriteManager
    {
        protected Texture2D Texture;
        public Vector2 Position = Vector2.Zero;
        public Color Color = Color.White;
        public Vector2 Origin;
        public float Rotation = 0f;
        //public float Scale = 1f;
        public SpriteEffects SpriteEffect;
        //OutputRectangle allows the consumer to change the size of the output sprite. Sprites sheet files are not always consistantly sized. 
        public Rectangle OutputRectangle;
        protected Rectangle[] Rectangles;
        protected int FrameIndex = 0;
        
        public SpriteManager(Texture2D texture, Rectangle rectangle)
        {

            this.Texture = texture;
            OutputRectangle = new Rectangle((int)Position.X, (int)Position.Y, texture.Width,texture.Height);
            Rectangles = new Rectangle[1];
            Rectangles[0] = rectangle;
        }

        public SpriteManager(Texture2D texture, Rectangle[] rectangleList)
        {
            Rectangles = rectangleList;
            this.Texture = texture;
            OutputRectangle = new Rectangle((int)Position.X, (int)Position.Y, texture.Width,texture.Height);
        }

        public SpriteManager(Texture2D texture, int frames) : this(texture, frames, 0, texture.Height) { }

        public SpriteManager(Texture2D Texture, int frames, int offset, int height)
        {
            this.Texture = Texture;
            int width = Texture.Width / frames;
            OutputRectangle = new Rectangle((int)Position.X, (int)Position.Y, width,height);
            Rectangles = new Rectangle[frames];
            for (int i = 0; i < frames; i++)
                Rectangles[i] = new Rectangle(i * width, offset, width, height);
        }

        public SpriteManager(Texture2D Texture, int startPositionX, int startPositionY, int frames, int width, int height)
        {
            this.Texture = Texture;
            OutputRectangle = new Rectangle((int)Position.X, (int)Position.Y, width,height);
            Rectangles = new Rectangle[frames];
            for (int i = 0; i < frames; i++)
                Rectangles[i] = new Rectangle(startPositionX, startPositionY, width, height);
        }

        public void setOutputRectangle(Rectangle outputRectangle)
        {
            OutputRectangle = outputRectangle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, OutputRectangle, Rectangles[FrameIndex], Color, Rotation, Origin, SpriteEffect, 0f);
        }



    }

    public class SpriteAnimation : SpriteManager
    {
        private float timeElapsed;
        public bool IsLooping = true;
        public bool playing = true;
        private float timeToUpdate;
        public int FramesPerSecond { set { timeToUpdate = (1f / value);  } }

        public SpriteAnimation(Texture2D texture, int frames, int fps = 5) : base(texture, frames) {
            FramesPerSecond = fps;
        }
        public SpriteAnimation(Texture2D texture, int frames, int offset, int height, int fps = 5) : base(texture, frames, offset, height)
        {
            FramesPerSecond = fps;
        }
        public SpriteAnimation(Texture2D texture, Rectangle rectangle) : base (texture, rectangle)
        {
            FramesPerSecond = 1;
        }

        public SpriteAnimation(Texture2D texture, Rectangle[] rectangle, int fps = 5) : base(texture, rectangle)
        {
            FramesPerSecond = fps;
        }

        public void Update(GameTime gameTime)
        {
            //if (!playing) return;
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > timeToUpdate)
            {
                timeElapsed -= timeToUpdate;

                if (FrameIndex < Rectangles.Length - 1)
                    FrameIndex++;

                else if (IsLooping)
                    FrameIndex = 0;
            }
        }

        

        public void setFrame(int frame)
        {
            FrameIndex = frame;
        }
        public int getCurrentFrame()
        {
            return FrameIndex;
        }
        public int getTotalFrames()
        {
            return Rectangles.Length;
        }
    }
}