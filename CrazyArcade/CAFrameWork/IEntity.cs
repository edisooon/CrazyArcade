using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.CAFramework
{
    public interface IEntity
    {
        void Load();
        void Deload(); //Excuete after removed from scene,
                       //i.e. return to pool or other behaviours
        void Update(GameTime time);
        void Draw(GameTime time, SpriteBatch batch);
        ISceneDelegate SceneDelegate { get; set; }
        public int ActualDrawOrder { get; }
        public void RemoveFromStage();
    }
}

