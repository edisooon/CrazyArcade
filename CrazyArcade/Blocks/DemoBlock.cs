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
        public DemoBlock(Rectangle destinationRectangle)
        {
            blockTypeList.Add(new BrickBlock(destinationRectangle));
            blockTypeList.Add(new SandBlock(destinationRectangle));
            this.destinationRectangle = destinationRectangle;
            this.sourceRectangle = blockTypeList[index].InputFrame;
            this.spriteTexture = blockTypeList[index].Texture;
        }
        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Y))
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
            if (Keyboard.GetState().IsKeyDown(Keys.T))
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
            this.sourceRectangle = blockTypeList[index].InputFrame;
            this.spriteTexture = blockTypeList[index].Texture;
        }
    }
    public class DemoBlockController : IGameSystem
    {
        List<DemoBlock> blockList = new List<DemoBlock>();
        List<ISprite> sprites = new List<ISprite>();
        public DemoBlockController()
        {
            blockList.Add(new DemoBlock(new Rectangle(200, 200, 100, 100)));
        }
        public void AddSprite(ISprite sprite)
        {
            foreach(DemoBlock block in blockList)
            {
                sprites.Add(block);
            }
        }

        public void RemoveAll()
        {
            foreach(ISprite block in sprites)
            {
                sprites.Remove(block);
            }
        }

        public bool RemoveSprite(ISprite sprite)
        {
            return sprites.Remove(sprite);
        }

        public void Update(GameTime time)
        {
            blockList[0].Update();
        }
    }
}
