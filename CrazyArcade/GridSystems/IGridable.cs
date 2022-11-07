using System;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;

namespace CrazyArcade.GameGridSystems
{
	public interface IGridable: IEntity
    {
		/*	contains helper methods to transform coordinates
		 *	this will be assigned by the grid systems
		 *	you can use Trans.<method name> for your gridable entities
		 *	It is optional to use it for your convinience
		 */
        IGridTransform Trans { get; set; }


        /*	You need to implement the display of your gridables based 
		 *	on ScreenCoord.
		 *  It will be update in the Grid method, but to keep it most 
		 *  relevant, you can always assign ScreenCoord by overriding 
		 *  GameCoord's setter (see example gameCoord)
		 */
        Vector2 ScreenCoord { get; set; }


        /*  You need to implement GameCoord and use GameCoord for movement.
		 *  GridSystem will need gameCoord to adjust ScreenCoord.
		 *  
		 *	Example:
		 *	get => gameCoord;
		 *	set {
		 *		ScreenCoord = Trans.Trans(value);
		 *		gameCoord = value;
		 *  }
		 */
        Vector2 GameCoord { get; set; }
		
    }
}

