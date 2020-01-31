using System.Collections.Generic;
using Interaction.Snapping;
using UnityEngine;

namespace Interaction.Dragging
{
    public interface IDraggable
    {
        void Highlight();
        void UnHighlight();
        void UpdatePosition(Vector2 pos);
    }
}
