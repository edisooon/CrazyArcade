using System;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFrameWork.EntityBehaviors
{
    public interface IGridTransformable: IEntity
    {
        double GridX { get; set; }
        double GridY { get; set; }
        public IGridTransform Transform { get; }
    }
}

