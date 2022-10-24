using System;
namespace CrazyArcade.BombFeature
{
	public interface IBombCollectable
	{
		//Called when bomb exploded, generally will restore the number of bombs
		void recollectBomb();
	}
}

