using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.CAFramework
{
	public abstract class CAEntity: IEntity
	{

        // for each entity, it has to have a position and animations of sprite
        List<SpriteAnimation> spriteAnimList;
        public virtual List<SpriteAnimation> SpriteAnimList {
            get
            {
                List<SpriteAnimation> list = new List<SpriteAnimation>();
                list.Add(SpriteAnim);
                return list;
            }
        }
        public virtual SpriteAnimation SpriteAnim { get; }
        public int X, Y;

        public abstract void Load();
        public virtual void Update(GameTime time)
        {
            // handled animation updated (position and frame) in abstract level
            foreach (SpriteAnimation Anim in SpriteAnimList)   {
                Anim.Update(time);
         
            }
        }
        public void Draw(GameTime time, SpriteBatch batch)
        {
            foreach (SpriteAnimation Anim in SpriteAnimList)
            {
                //Anim.Update(time);
                Anim.Draw(batch, this.X, this.Y);
            }
        }
    }
}

