using UnityEngine;

namespace Interaction.Snapping
{
    public interface ISnapPoint
    {
        ISnapPoint GetTriggeredSnapable();
        Transform GetTransform();
        void SetSnapped();
    }
}
