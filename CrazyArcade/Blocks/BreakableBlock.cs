using CrazyArcade.Items;
using CrazyArcade.BombFeature;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.CAFramework;

namespace CrazyArcade.Blocks
{
    public abstract class BreakableBlock : Block, IBlock, IExplosionCollidable
    {
        ISceneDelegate parentScene;

        public BreakableBlock(ISceneDelegate parentScene, Vector2 position, Rectangle source) : base(position, source, Content.TextureSingleton.GetDesertBlocks())
        {
            this.parentScene = parentScene;
        }

        public void DeleteSelf()
        {
            parentScene.ToRemoveEntity(this);
        }

        public bool Collide(IExplosion bomb)
        {
            DeleteSelf();
            return false;
        }
    }
    public class BlueCrate : BreakableBlock
    {
        private static Rectangle source = new Rectangle(10, 306, 40, 63);
        public BlueCrate(ISceneDelegate parentScene, Vector2 position) : base(parentScene, position, source)
        {

        }
    }
    public class GreenCrate : BreakableBlock
    {
        private static Rectangle source = new Rectangle(60, 306, 40, 63);
        public GreenCrate(ISceneDelegate parentScene, Vector2 position) : base(parentScene, position, source)
        {

        }
    }
    public class CyanCrate : BreakableBlock
    {
        private static Rectangle source = new Rectangle(110, 306, 40, 63);
        public CyanCrate(ISceneDelegate parentScene, Vector2 position) : base(parentScene, position, source)
        {

        }
    }

}
