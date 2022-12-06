using System;
using System.Diagnostics;
using CrazyArcade.BombFeature;
using CrazyArcade.CAFramework;
using CrazyArcade.Items;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Enemies
{
	public abstract class EnemyEntity: CAEntity
	{
		public EnemyEntity()
		{
		}
        public override void Load()
        {
            SceneDelegate.IncreaseEnemyCount();
        }
        public override void Deload()
        {
            base.Deload();
			SceneDelegate.DecreaseEnemyCount();
            if (SceneDelegate.GetEnemyCount() <= 0)
            {
               
            }
        }
    }
}

