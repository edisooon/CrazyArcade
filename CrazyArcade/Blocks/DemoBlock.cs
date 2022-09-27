using CrazyArcade.CAFramework;
using CrazyArcade.Items;
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
            blockTypeList.Add(new LightSandBlock(destinationRectangle));
            blockTypeList.Add(new SandBlock(destinationRectangle));
            blockTypeList.Add(new Rock(destinationRectangle));
            blockTypeList.Add(new Tree(destinationRectangle));
            blockTypeList.Add(new DarkTree(destinationRectangle));
            blockTypeList.Add(new Cactus(destinationRectangle));

            this.destinationRectangle = blockTypeList[index].OutputFrame;
            this.sourceRectangle = blockTypeList[index].InputFrame;
            this.spriteTexture = blockTypeList[index].Texture;
        }
        
        public override void Update(GameTime gameTime)
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
            this.destinationRectangle = blockTypeList[index].OutputFrame;
            this.sourceRectangle = blockTypeList[index].InputFrame;
            this.spriteTexture = blockTypeList[index].Texture;
        }
    }
}
