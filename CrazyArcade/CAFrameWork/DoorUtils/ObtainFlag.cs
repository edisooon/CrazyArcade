using CrazyArcade.CAFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.CAFrameWork.DoorUtils
{
    //This class is loaded and unloaded immediately once per level to set the correct flags
    public class ObtainFlag : CAEntity
    {
        public bool flag;
        public ObtainFlag(bool flag)
        {
            this.flag = flag;
        }
        public override void Load()
        {
        }
    }
}
