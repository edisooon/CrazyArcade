using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using CrazyArcade.GameGridSystems;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.CAFramework
{
	public abstract class CAEntity: IEntity, IGridable
	{

        // for each entity, it has to have a position and animations of sprite
        public virtual List<SpriteAnimation> SpriteAnimList {
            get
            {
                List<SpriteAnimation> list = new List<SpriteAnimation>();
                list.Add(SpriteAnim);
                return list;
            }
        }

        private SpriteAnimation spriteAnim = new SpriteAnimation(TextureSingleton.GetNull(), 1, 0, 0, 0);
        public virtual SpriteAnimation SpriteAnim { get => spriteAnim; }
        private ISceneDelegate sceneDelegate;
        public ISceneDelegate SceneDelegate
        {
            get => sceneDelegate;
            set => sceneDelegate = value;
        }
        private int x;
        private int y;
        public virtual int X { get => x; set => x = value; }
        public virtual int Y { get => y; set => y = value; }
        private Vector2 gamePos;
        private Vector2 pos;

        public Vector2 ScreenCoord
        {
            get => pos;
            set
            {
                pos = value;
                this.X = (int)value.X;
                this.Y = (int)value.Y;
            }
        }

        public Vector2 GameCoord
        {
            get => gamePos;
            set
            {
                gamePos = value;
                ScreenCoord = trans.Trans(value);
            }
        }
        private IGridTransform trans = new NullTransform();
        public IGridTransform Trans { get => trans; set => trans = value; }
        //why 2 trans?

        public abstract void Load();
        public virtual void Update(GameTime time)
        {
            // handled animation updated (position and frame) in abstract level
            foreach (SpriteAnimation Anim in SpriteAnimList)   {
                Anim.Update(time);
                if (pos.Equals(null))
                {
                    pos = new Vector2(X, Y);
                }
                else {
                    pos.X = X;
                    pos.Y = Y;
                }

                if (gamePos.Equals(null))
                {
                    gamePos = new Vector2(X, Y);
                }
                else
                {
                    gamePos.X = X;
                    gamePos.Y = Y;
                }

            }
        }
        public void Draw(GameTime time, SpriteBatch batch)
        {
            foreach (SpriteAnimation Anim in SpriteAnimList)
            {
                Anim.Update(time);
                Anim.Draw(batch, this.X, this.Y);
            }
        }
    }
}

