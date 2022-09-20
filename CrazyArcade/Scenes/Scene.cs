using CrazyArcade.Entities;
using CrazyArcade.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.Scenes
{
    internal class Scene
    {
        List<IEntity> EntityList;
        List<ITile> TileList;
        public void Update(GameTime gameTime)
        {
            foreach (IEntity entity in EntityList)
            {
                entity.Update(gameTime);
            }
            foreach (ITile tile in TileList)
            {
                tile.Update(gameTime); 
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (IEntity entity in EntityList)
            {
                entity.Draw(spriteBatch, gameTime);
            }
            foreach (ITile tile in TileList)
            {
                tile.Update(gameTime);
            }
        }

        public void AddEntity(IEntity entity)
        {
            EntityList.Add(entity);
        }

        public void RemoveEntity(IEntity entity)
        {
            EntityList.Remove(entity);
        }
        public Scene()
        {
            EntityList = new List<IEntity>();
            TileList = new List<ITile>();
        }
    }
}
