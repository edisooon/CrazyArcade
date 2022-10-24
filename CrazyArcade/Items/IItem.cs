using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.CAFramework;
using CrazyArcade.Blocks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CrazyArcade.GameGridSystems;

namespace CrazyArcade.Items
{
    public interface IItem : IEntity
    {
        //void Update(GameTime time, Rectangle rectangle, int fps);
    }
    public abstract class Item : Block, IItem
    {
        //Rectangle[] frames;
        //Rectangle current;
        public Item(Rectangle destination, Rectangle source, Texture2D texture, int frames, int fps) : base(destination, source, texture, frames, fps)
        {
            spriteAnimation = new SpriteAnimation(texture, frames, fps);
            this.X = destination.X;
            this.Y = destination.Y;
            //frames = sources;
            //current = frames[0];
        }
        /**public void Update(GameTime time, Rectangle rectangle, int fps = 5) {
            int millisec = (int)((int)time.ElapsedGameTime.TotalMilliseconds);
            int milliPure = millisec - ((int)time.ElapsedGameTime.TotalSeconds);
            int durationPerFrame = 1000 / fps;
            int currentFrame = milliPure / durationPerFrame;
            current = frames[currentFrame];
        }**/
        public override SpriteAnimation SpriteAnim => this.spriteAnimation;

        public override void Update(GameTime time)
        {

        }
        public override void Load()
        {
        }
    }
}
