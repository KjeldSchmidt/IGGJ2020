using System.Collections.Generic;
using Interaction.Containers;
using Interaction.Dragging;
using UnityEngine;

namespace Interaction.Snapping
{
    public interface ISnapable : IDraggable
    {
        IShapeContainer ShapeContainer { get; }
        List<ISnapPoint> GetSnapPoints();
        Transform GetBlockContainerTransform();
    }
}