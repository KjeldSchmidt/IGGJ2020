using UnityEngine;

namespace Abilities
{
    public interface IAbilityController
    {
        void OnTriggerStay2D(Collider2D other);
        void OnTriggerExit2D(Collider2D other);
        void MouseDown(Transform mouseTransform);
        void MouseUp();
        bool IsDragging();
    }
}