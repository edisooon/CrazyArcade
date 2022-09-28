using CrazyArcade.CAFramework;
using CrazyArcade.Items;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.Blocks
{
    public class DemoBlockAndItemController : IGameSystem
    {
        List<Block> blockList = new List<Block>();
        IScene currScene;
        public DemoBlockAndItemController(IScene currScene)
        {
            blockList.Add(new DemoBlock(new Rectangle(200, 200, 50, 50)));
            blockList.Add(new DemoItem(new Rectangle(400, 200, 50, 50)));
            this.currScene = currScene;
        }
        public List<Block> BlockList => blockList;
        public void AddSprite(ISprite sprite)
        {
        }

        public void RemoveAll()
        {
        }

        public bool RemoveSprite(ISprite sprite)
        {
            return false;
        }

        public void Update(GameTime time)
        {
            foreach (var entity in blockList)
            {
                currScene.RemoveSprite(entity);
                entity.Update(time);
                currScene.AddSprite(entity);
            }
        }
    }
}
