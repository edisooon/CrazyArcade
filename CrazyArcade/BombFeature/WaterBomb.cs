using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.BombFeature
{
    public class WaterBomb : CAEntity
    {
        Point position = new(100, 100);
        int BlastLength = 1;
        public override Texture2D Texture => TextureSingleton.GetBallons();
        public override Rectangle InputFrame => new Rectangle(0, 67, 56, 67);
        public override Rectangle OutputFrame => new Rectangle(position.X, position.Y, 56, 67);
        public override Color Tint => Color.White;
        private List<Rectangle> AnimationFrames;
        public WaterBomb()
        {
            AnimationFrames = GetAnimationFrames();
        }
        private static List<Rectangle> GetAnimationFrames()
        {
            List<Rectangle> NewFrames = new();
            NewFrames.Add(new Rectangle(11, 51, 42, 42));
            NewFrames.Add(new Rectangle(56, 51, 42, 42));
            NewFrames.Add(new Rectangle(97, 51, 46, 42));
            return NewFrames;
        }
        public override void Update(GameTime time)
        {
            //Implemented
        }
    }
}
