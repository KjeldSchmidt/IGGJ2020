using System.Collections.Generic;
using Interaction.Dragging;
using UnityEngine;

namespace Interaction.Snapping
{
    public interface ISnapable : IDraggable
    {
        List<ISnapPoint> GetSnapables();
        Transform GetBlockContainerTransform();
    }
}