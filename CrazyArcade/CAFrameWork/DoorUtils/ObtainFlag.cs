using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.CAFrameWork.DoorUtils
{
    //This class is loaded and unloaded immediately once per level to set the correct flags
    public class ObtainFlag : CAEntity
    {
        public bool flag;
        public Vector2 keyPos;
        public ObtainFlag(bool flag, Vector2 keyPos)
        {
            this.flag = flag;
            this.keyPos = keyPos;
        }
        public override void Load()
        {
        }
    }
}
