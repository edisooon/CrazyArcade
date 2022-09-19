using System;
namespace CrazyArcade.CAFrameWork.EntityBehaviors
{
    public interface IGridTransformable: IEntity
    {
        public IGridTransform Transform { get; }
    }
}

