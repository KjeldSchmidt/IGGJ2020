using UnityEngine;

namespace Interaction
{
    public interface ISnapable
    {
        ISnapable GetTriggeredSnapable();
        Transform GetTransform();
    }
}
