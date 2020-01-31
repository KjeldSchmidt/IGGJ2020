using System.Collections.Generic;
using Interaction.Dragging;
using UnityEngine;

namespace Interaction.Snapping
{
    public interface ISnapable : IDraggable
    {
        List<ISnapPoint> GetSnapPoints();
        Transform GetBlockContainerTransform();
    }
}