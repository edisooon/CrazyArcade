using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.CAFrameWork.Transition
{
    //This class is loaded at the end of a previous level, and the start of a next level
    public class LevelPersnstance
    {
        public Dictionary<string, int> SavedStatInt;
        public LevelPersnstance() 
        {
            SavedStatInt = new();
        }
    }
}
