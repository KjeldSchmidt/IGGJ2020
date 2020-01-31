using UnityEngine;

namespace Interaction.Snapping
{
    public interface ISnappingController
    {
        void OnTriggerStay2D(Collider2D other);
        void OnTriggerExit2D(Collider2D other);
        void MouseDown(Transform mouseTransform);
        void MouseUp();
    }
}