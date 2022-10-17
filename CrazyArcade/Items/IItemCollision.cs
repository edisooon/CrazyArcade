using CrazyArcade.PlayerStateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Items
{
    public interface IItemCollision : IGameSystem
    {
    }
    public class PowerupCollision : IItemCollision
    {
        private PlayerCharacter player;
        private List<Item> powerups;
        private IScene parentScene;

        public PowerupCollision(IScene scene)
        {
            this.powerups = new List<Item>();
            this.parentScene = scene;
        }
        public void AddSprite(IEntity toAdd)
        {
            if(toAdd is Item)
            {
                powerups.Add(toAdd as Item);
            }
            else if(toAdd is PlayerCharacter)
            {
                player = (PlayerCharacter)toAdd;
            }
        }
        public void RemoveSprite(IEntity toRemove)
        {
            if(toRemove is Item)
            {
                powerups.Remove(toRemove as Item);
            }
        }
        public void RemoveAll()
        {
            powerups.Clear();
        }
        public void Update(GameTime gameTime)
        {
            Item toRemove = null;
            foreach(Item powerup in powerups)
            {
                if(player.hitbox.Intersects(powerup.hitbox))
                {
                    toRemove = powerup;
                }
            }
            if(toRemove != null)
            {
                parentScene.RemoveSprite(toRemove);
                player.playerState.ProcessItem();
            }
        }
    }
}
