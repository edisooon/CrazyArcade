using CrazyArcade.Items;
using CrazyArcade.BombFeature;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.CAFramework;
using CrazyArcade.Levels;

namespace CrazyArcade.Blocks
{
    public class BreakableBlock : Block
    {
        ISceneDelegate parentScene;

        public BreakableBlock(ISceneDelegate parentScene, Vector2 position, CreateLevel.LevelItem type) : base(position, getSource(type), Content.TextureSingleton.GetDesertBlocks())
        {
            this.parentScene = parentScene;
            this.parentScene.ToAddEntity(Item.Random(position));
        }
        private static Rectangle getSource(CreateLevel.LevelItem type)
        {
            /*BlueCrate = new Rectangle(10, 306, 40, 63);
            GreenCrate = new Rectangle(60, 306, 40, 63);
            CyanCrate = new Rectangle(110, 306, 40, 63);*/
            switch (type)
            {
                case CreateLevel.LevelItem.DarkSandPosition:
                    return new Rectangle(60, 10, 40, 44);
                //Default is light sand
                default:
                    return new Rectangle(10, 10, 40, 44);
            }
        }
        public void DeleteSelf()
        {
            parentScene.ToRemoveEntity(this);
        }

        public override bool Collide(IExplosion bomb)
        {
            DeleteSelf();
            return false;
        }
    }
}
