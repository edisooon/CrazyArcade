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
    }
    public abstract class Item : Block, IItem
    {
        public Item(Rectangle destination, Rectangle source, Texture2D texture) : base(destination, source, texture)
        {
        }
    }
}
