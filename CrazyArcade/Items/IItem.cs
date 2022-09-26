using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.CAFramework;
using CrazyArcade.Blocks;

namespace CrazyArcade.Items
{
    public interface IItem : IEntity
    {
    }
    public abstract class Item : Block, IItem
    {
        
    }
}
