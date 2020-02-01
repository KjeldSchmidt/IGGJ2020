using UnityEngine;

namespace Interaction.Snapping
{
    public interface ISnapPoint
    {
        ISnapable Snapable { get; }
        bool Snapped { get; }
        Directions GetSnapDirection();
        ISnapPoint GetTriggeredSnapable();
        Transform GetTransform();
        void SetSnapped();
    }
}
