using UnityEngine;

namespace Interaction.Snapping
{
    public interface ISnapable
    {
        ISnapable GetTriggeredSnapable();
        Transform GetTransform();
        void SetSnapped();
    }
}
