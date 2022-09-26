using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
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
    public class DemoBlock : Block, IBlock
    {
        private List<Block> blockTypeList = new List<Block>();
        private int index = 0;
        KeyboardState previousState;
        public DemoBlock(Rectangle destinationRectangle)
        {
            blockTypeList.Add(new BrickBlock(destinationRectangle));
            blockTypeList.Add(new SandBlock(destinationRectangle));
            this.destinationRectangle = destinationRectangle;
            this.sourceRectangle = blockTypeList[index].InputFrame;
            this.spriteTexture = blockTypeList[index].Texture;
        }
        
        public void Update()
        {
            KeyboardState current = Keyboard.GetState();
            if (current.IsKeyDown(Keys.Y) && !previousState.IsKeyDown(Keys.Y))
            {
                if (index == blockTypeList.Count - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
            }
            if (current.IsKeyDown(Keys.T) && !previousState.IsKeyDown(Keys.T))
            {
                if (index == 0)
                {
                    index = blockTypeList.Count - 1;
                }
                else
                {
                    index--;
                }
            }
            this.previousState = current;
            this.sourceRectangle = blockTypeList[index].InputFrame;
            this.spriteTexture = blockTypeList[index].Texture;
        }
    }
    public class DemoBlockController : IGameSystem
    {
        List<DemoBlock> blockList = new List<DemoBlock>();
        IScene currScene;
        public DemoBlockController(IScene currScene)
        {
            blockList.Add(new DemoBlock(new Rectangle(200, 200, 100, 100)));
            this.currScene = currScene;
        }
        public List<DemoBlock> BlockList => blockList;
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
            currScene.RemoveSprite(blockList[0]);
            blockList[0].Update();
            currScene.AddSprite(blockList[0]);
        }
    }
}
