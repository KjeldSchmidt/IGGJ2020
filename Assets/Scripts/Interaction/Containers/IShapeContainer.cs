using UnityEngine;

namespace Interaction.Containers
{
    public interface IShapeContainer
    {
        Transform Transform { get; }
        void Destroy();
        void StartLevel();
    }
}