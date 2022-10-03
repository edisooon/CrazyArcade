using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork;
using CrazyArcade.Demo1;
using CrazyArcade.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.Blocks
{
    public class Sprint2Manager : IGameSystem
    {
        private const int block = 0;
        private const int item = 1;
        private List<Block> blockTypeList;
        private List<Item> itemTypeList;
        private List<IEntity> entities;
        private int blockIndex = 0;
        private int itemIndex = 0;
        KeyboardState current;
        KeyboardState previousState;
        Rectangle blockDestination = new(200, 200, 50, 50);
        Rectangle itemDestination = new(400, 200, 50, 50);
        CAScene scene;
        public Sprint2Manager(CAScene scene)
        {
            entities = new List<IEntity>();
            MakeBlockTypeList();
            MakeItemTypeList();
            this.scene = scene;
        }
        private static int Increment(int size, int index)
        {
            if (index == 0)
            {
                index = size - 1;
            }
            else
            {
                index--;
            }
            return index;
        }
        private static int Decrement(int size, int index)
        {
            if (index == size - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
            return index;
        }

        public void Update(GameTime gameTime)
        {
            scene.RemoveSprite(entities[block]);
            scene.RemoveSprite(entities[item]);
            current = Keyboard.GetState();
            UpdateBlock();
            UpdateItem();
            QuitReset();
            previousState = current;
            foreach (IEntity entity in entities)
            {
                scene.AddSprite(entity);
            }
        }
        public void UpdateBlock()
        {
            if (current.IsKeyDown(Keys.Y) && !previousState.IsKeyDown(Keys.Y))
            {
                blockIndex = Decrement(blockTypeList.Count, blockIndex);
            }
            if (current.IsKeyDown(Keys.T) && !previousState.IsKeyDown(Keys.T))
            {
                blockIndex = Increment(blockTypeList.Count, blockIndex);
            }
            entities[block] = blockTypeList[blockIndex];
        }
        public void UpdateItem()
        {
            if (current.IsKeyDown(Keys.I) && !previousState.IsKeyDown(Keys.I))
            {
                itemIndex = Decrement(itemTypeList.Count, itemIndex);
            }
            if (current.IsKeyDown(Keys.U) && !previousState.IsKeyDown(Keys.U))
            {
                itemIndex = Increment(itemTypeList.Count, itemIndex);
            }
            entities[item] = itemTypeList[itemIndex];
        }
        public void QuitReset()
        {
            if (current.IsKeyDown(Keys.Q))
            {
                scene.gameRef.Exit();
            }
            if (current.IsKeyDown(Keys.R))
            {
                scene.gameRef.scene = new DemoScene(scene.gameRef);
                scene.gameRef.scene.Load();
            }
        }
        private void MakeBlockTypeList()
        {
            blockTypeList = new List<Block>
            {
                new LightSandBlock(blockDestination),
                new SandBlock(blockDestination),
                new Rock(blockDestination),
                new Tree(blockDestination),
                new DarkTree(blockDestination),
                new Cactus(blockDestination)
            };
            entities.Add(blockTypeList[blockIndex]);
        }
        private void MakeItemTypeList()
        {
            itemTypeList = new List<Item>
            {
                new CoinBag(itemDestination),
                new Balloon(itemDestination),
                new Sneaker(itemDestination),
                new Turtle(itemDestination),
                new Potion(itemDestination)
            };
            entities.Add(itemTypeList[itemIndex]);
        }

        public void AddSprite(IEntity sprite)
        {
        }

        public void RemoveSprite(IEntity sprite)
        {

        }

        public void RemoveAll()
        {
            entities.Clear();
        }
    }
}
