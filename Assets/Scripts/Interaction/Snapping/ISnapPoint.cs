using UnityEngine;

namespace Interaction.Snapping
{
    public interface ISnapPoint
    {
        bool Snapped { get; }
        Directions GetSnapDirection();
        ISnapPoint GetTriggeredSnapable();
        Transform GetTransform();
        void SetSnapped();
    }
}
