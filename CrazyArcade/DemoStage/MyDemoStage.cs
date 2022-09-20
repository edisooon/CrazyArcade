using System;
using CrazyArcade.CAFrameWork;
using Microsoft.Xna.Framework;

namespace CrazyArcade.DemoStage
{
	public class MyDemoStage: Stage
	{
		public MyDemoStage()
		{
		}

        public override void loadBackground()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    this.AddEntity(new DemoTile(new Point(x, y)));
                }
            }
        }

        public override void loadCharacters()
        {
            Console.Out.Write("load");
            this.AddEntity(new DemoCharacter(new WASDController(), new Point()));
        }
    }
}

