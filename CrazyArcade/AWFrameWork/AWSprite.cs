using System;

namespace AWFrameWork
{
	public abstract class AWSprite: Sprite
	{
		public AWSprite()
		{

		}

        private Scene scene = null;
        public Scene Scene {
            get
            {
                return scene;
            }
            set
            {
                if (scene != null)
                {
                    scene.Remove(this);
                }
                scene = value;
            }
        }
        private Rectangle frame = new Rectangle();
        public virtual Rectangle Frame
        {
            get
            {
                return frame;
            }
            set
            {
                frame = value;
            }
        }
        protected Rectangle inputFrame = new Rectangle();
        public virtual Rectangle InputFrame
        {
            get
            {
                return inputFrame;
            }
        }
        private Scene superScene = null;
        public Scene SuperScene
        {
            get
            {
                return superScene;
            }
            set
            {
                superScene = value;
            }
        }
        protected Texture2D graphics;
        public Texture2D Graphics
        {
            get
            {
                return graphics;
            }
        }
        private Color tint = Color.White;
        public Color Tint
        {
            get
            {
                return tint;
            }
            set
            {
                tint = value;
            }
        }

        public abstract void Load();

        public virtual void Update(GameTime time)
        {
            
        }

        public virtual void RemoveFromScene()
        {
            if (superScene != null) {
                superScene.Remove(this);
            }
        }

        public virtual void click(MouseState state)
        {
            
        }
    }
}

