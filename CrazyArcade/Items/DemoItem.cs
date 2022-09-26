using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CrazyArcade.Items
{
    public class DemoItem : Item, IItem
    {
        private List<Block> itemTypeList = new List<Block>();
        private int index = 0;
        KeyboardState previousState;
        public DemoItem(Rectangle destinationRectangle)
        {
            itemTypeList.Add(new Coin(destinationRectangle));
            itemTypeList.Add(new Balloon(destinationRectangle));
            this.destinationRectangle = destinationRectangle;
            this.sourceRectangle = itemTypeList[index].InputFrame;
            this.spriteTexture = itemTypeList[index].Texture;
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState current = Keyboard.GetState();
            if (current.IsKeyDown(Keys.Y) && !previousState.IsKeyDown(Keys.Y))
            {
                if (index == itemTypeList.Count - 1)
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
                    index = itemTypeList.Count - 1;
                }
                else
                {
                    index--;
                }
            }
            this.previousState = current;
            this.sourceRectangle = itemTypeList[index].InputFrame;
            this.spriteTexture = itemTypeList[index].Texture;
        }
    }
}

