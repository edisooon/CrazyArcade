using System;
namespace CrazyArcade.CAFramework
{
	public abstract class CAEntity: CASprite, IEntity
	{
		public CAEntity()
		{
		}

        public void print()
        {
            Console.Out.Write("This is an Enitity");
        }
    }
}

