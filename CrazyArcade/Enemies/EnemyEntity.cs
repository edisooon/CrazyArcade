using System;
using CrazyArcade.CAFramework;

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
        }
    }
}

