using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.CAFrameWork.Transition
{
    public interface ISavable
    {
        public void Save(LevelPersistence level);
        public void Load(LevelPersistence level);
    }
}
