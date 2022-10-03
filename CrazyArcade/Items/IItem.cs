using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork;
using CrazyArcade.Blocks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

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
        public Item(Rectangle destination, Rectangle source, Texture2D texture) : base(destination, source, texture)
        {
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
    }
}
