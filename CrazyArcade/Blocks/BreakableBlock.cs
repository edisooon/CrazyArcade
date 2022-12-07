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
    public abstract class BreakableBlock : Block
    {
        private Item item;
        public BreakableBlock(Vector2 position, Rectangle source) : base(position, source, Content.TextureSingleton.GetDesertBlocks())
        {
            item = Item.Random(position);
        }

        public void DeleteSelf()
        {
            SceneDelegate.ToRemoveEntity(this);
        }

        public override bool Collide(IExplosion bomb)
        {
            DeleteSelf();
            return false;
        }
		public override void Deload()
		{
			base.Deload();
            SceneDelegate.ToAddEntity(item);
		}
	}
    public class BlueCrate : MoveableBlock
    {
        private static Rectangle source = new Rectangle(10, 306, 40, 63);
        public BlueCrate(Vector2 position) : base(position, source)
        {

        }
    }
    public class GreenCrate : MoveableBlock
	{
        private static Rectangle source = new Rectangle(60, 306, 40, 63);
        public GreenCrate(Vector2 position) : base(position, source)
        {

        }
    }
    public class CyanCrate : MoveableBlock
	{
        private static Rectangle source = new Rectangle(110, 306, 40, 63);
        public CyanCrate(Vector2 position) : base(position, source)
        {

        }
    }

}
