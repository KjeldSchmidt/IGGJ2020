using UnityEngine;

namespace Interaction
{
    public interface IDraggable
    {
        void Highlight();
        void UnHighlight();
        void MouseDown();
        void MouseUp();
        void UpdatePosition(Vector2 pos);
    }
}
