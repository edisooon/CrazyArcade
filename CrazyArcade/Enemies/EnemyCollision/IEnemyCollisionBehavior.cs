using CrazyArcade.CAFrameWork.GridBoxSystem;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.EnemyCollision
{

    public interface IEnemyCollisionBehavior: IBoxOccupy
	{
        //The rectangle that detects the collision
        public Rectangle BlockBoundingBox { get; }
        //The code that is executed when a collision is detected. (Called by the block and defined in Enemy class)
        public void TurnEnemy();
    }
}
