using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.Items
{
    public class ItemManager : IGameSystem
    {
        private List<Item> _items;
        private IScene scene;
        public ItemManager(IScene scene)
        {
            this.scene = scene;
            _items = new List<Item>();
            scene.AddSprite(new Balloon(new Rectangle(400, 200, 100, 100)));
        }
        public void AddSprite(IEntity sprite)
        {
            if(sprite is Item)
            {
                _items.Add(sprite as Item);
            }
        }

        public void RemoveAll()
        {
            _items.Clear();
        }

        public void RemoveSprite(IEntity sprite)
        {
            if(sprite is Item)
            {
                _items.Remove(sprite as Item);
            }
        }

        public void Update(GameTime time)
        {
            foreach(Item item in _items)
            {
                
            }
        }
    }
}
