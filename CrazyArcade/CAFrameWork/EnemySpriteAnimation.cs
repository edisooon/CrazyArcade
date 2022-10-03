using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrazyArcade.CAFramework
{   //edited SpriteManager and SpriteAnimation 
    public class EnemySpriteManager
    {
        protected Texture2D Texture;
        public Vector2 Position = Vector2.Zero;
        public Color Color = Color.White;
        public Vector2 Origin;
        public float Rotation = 0f;
        public float Scale = 1f;
        public SpriteEffects SpriteEffect;
        public int Height;
        public int Width;
        protected Rectangle[] Rectangles;
        protected int FrameIndex = 0;
        
        
        public EnemySpriteManager(Texture2D texture, Rectangle rectangle)
        {

            this.Texture = texture;

            Rectangles = new Rectangle[1];
            Rectangles[0] = rectangle;
        }

        public EnemySpriteManager(Texture2D texture, Rectangle[] rectangleList)
        {
            Rectangles = rectangleList;
            this.Texture = texture;

          
        }

        public EnemySpriteManager(Texture2D texture, int frames) : this(texture, frames, 0, texture.Height) { 

        }

        public EnemySpriteManager(Texture2D texture, int frames, int offset, int height)
        {
            this.Texture = texture;
            int width = texture.Width / frames;
            Rectangles = new Rectangle[frames];
            for (int i = 0; i < frames; i++)
                Rectangles[i] = new Rectangle(i * width, offset, width, height);
        }

        public EnemySpriteManager(Texture2D Texture, int startPositionX, int startPositionY, int frames, int width, int height)
        {
            this.Texture = Texture;
            Rectangles = new Rectangle[frames];
            for (int i = 0; i < frames; i++)
                Rectangles[i] = new Rectangle(startPositionX, startPositionY, width, height);
        }

        public void setWidthHeight(int w, int h)
        {
            Width = w;
            Height = h;
        }
        public void setEffect(SpriteEffects effect)
        {
            SpriteEffect = effect;
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, Width, Height), Rectangles[FrameIndex], Color, Rotation, Origin, SpriteEffect, 0f);
        }



    }

    public class EnemySpriteAnimation : EnemySpriteManager
    {
        private float timeElapsed;
        public bool IsLooping = true;
        public bool playing = true;
        private float timeToUpdate;
        public int FramesPerSecond { set { timeToUpdate = (1f / value);  } }

        public EnemySpriteAnimation(Texture2D texture, int frames, int fps = 5) : base(texture, frames) {
            FramesPerSecond = fps;
        }
        public EnemySpriteAnimation(Texture2D texture, int frames, int offset, int height, int fps = 5) : base(texture, frames, offset, height)
        {
            FramesPerSecond = fps;
        }
        public EnemySpriteAnimation(Texture2D texture, Rectangle rectangle) : base (texture, rectangle)
        {
            FramesPerSecond = 1;
        }

        public EnemySpriteAnimation(Texture2D texture, Rectangle[] rectangle, int fps = 5) : base(texture, rectangle)
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