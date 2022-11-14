﻿using Microsoft.Xna.Framework;
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
        public float Scale = 1f;
        public SpriteEffects SpriteEffect;
        public bool playing = true;
        protected Rectangle[] Rectangles;
        protected int FrameIndex = 0;
        public int Width;
        public int Height;
        public int rectangleFlag = 0;

        public virtual void CopyFrom(SpriteManager manager)
        {
            this.Texture = manager.Texture;
            this.Position = manager.Position;
            this.Color = manager.Color;
            this.Rotation = manager.Rotation;
            this.Scale = manager.Scale;
            this.SpriteEffect = manager.SpriteEffect;
            this.Rectangles = manager.Rectangles;
            this.FrameIndex = manager.FrameIndex;
        }
        public SpriteManager()
        {
        }
        public SpriteManager(Texture2D texture, Rectangle rectangle)
        {
            this.Texture = texture;
            Rectangles = new Rectangle[1];
            Rectangles[0] = rectangle;
        }

        public SpriteManager(Texture2D texture, Rectangle[] rectangleList)
        {
            Rectangles = rectangleList;
            this.Texture = texture;
        }

        public SpriteManager(Texture2D texture, int frames) : this(texture, frames, 0, 0, texture.Width, texture.Height) { }
        public SpriteManager(Texture2D Texture, int frames, int offsetY, int height) : this(Texture, frames, 0, offsetY, Texture.Width, height) { }
        public SpriteManager(Texture2D Texture, int frames, int offsetX, int offsetY, int width, int height)
        {
            this.Texture = Texture;
            width = width / frames;
            Rectangles = new Rectangle[frames];
            for (int i = 0; i < frames; i++)
                Rectangles[i] = new Rectangle(offsetX + i * width, offsetY, width, height);
        }
        public SpriteManager(Texture2D Texture, int startPositionX, int startPositionY, int frames, int width, int height, int offset)
        {
            this.Texture = Texture;
            Rectangles = new Rectangle[frames];
            for (int i = 0; i < frames; i++)
                Rectangles[i] = new Rectangle(startPositionX + (i * width) + (offset * i), startPositionY, width, height);
        }
        //public SpriteManager(Texture2D Texture, int startPositionX, int startPositionY, int frames, int width, int height)
        //{
        //    this.Texture = Texture;
        //    Rectangles = new Rectangle[frames];
        //    for (int i = 0; i < frames; i++)
        //        Rectangles[i] = new Rectangle(startPositionX, startPositionY, width, height);
        //}

        public void Draw(SpriteBatch spriteBatch, float xShift, float yShift)
        {
            Vector2 drawPosition = new Vector2(Position.X + xShift, Position.Y + yShift);
            if (rectangleFlag == 1){
                spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, Width,Height), Rectangles[FrameIndex], Color, Rotation, Origin,SpriteEffect, 0f);
            }
            else
            {
                spriteBatch.Draw(Texture, drawPosition, Rectangles[FrameIndex], Color, Rotation, Origin, Scale, SpriteEffect, 0f);
            }
            
        }

        public void setWidthHeight(int w, int h)
        {
            this.Width = w;
            this.Height = h;
            this.rectangleFlag = 1;
        }
        public void setEffect(SpriteEffects effect)
        {
            this.SpriteEffect = effect;
        }

        public void SetScale(float newScale)
        {
            this.Scale = newScale;
        }

    }

    public class SpriteAnimation : SpriteManager
    {
        private float timeElapsed;
        public bool IsLooping = true;
        //public bool playing = true;
        private float timeToUpdate;
        public int FramesPerSecond { set { timeToUpdate = (1f / value); } }

        public override void CopyFrom(SpriteManager manager)
        {
            base.CopyFrom(manager);
            if (manager is SpriteAnimation)
            {
                SpriteAnimation animation = manager as SpriteAnimation;
                this.timeElapsed = animation.timeElapsed;
                this.IsLooping = animation.IsLooping;
                this.playing = animation.playing;
                this.timeToUpdate = animation.timeToUpdate;
            }
        }
        public SpriteAnimation(): base()
        {

        }

        public SpriteAnimation(Texture2D texture, int frames, int offsetX, int offsetY, int width, int height, int fps = 5) : base(texture, frames, offsetX, offsetY, width, height)
        {
            FramesPerSecond = fps;
        }

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
        public SpriteAnimation(Texture2D texture, int startX, int startY, int width, int height, int frames, int offset, int fps) : base(texture, startX, startY, frames, width, height, offset )
        {
            FramesPerSecond = fps;
        }
        public SpriteAnimation(Texture2D texture, Rectangle[] rectangle, int fps = 5) : base(texture, rectangle)
        {
            FramesPerSecond = fps;
        }

        public virtual void Update(GameTime gameTime)
        {
            if (!playing) return;
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