using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public interface IDraggable
    {
        void Highlight();
        void UnHighlight();
        void UpdatePosition(Vector2 pos);
        List<ISnapable> GetSnapables();
    }
}
