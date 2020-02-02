using Interaction.Dragging;
using UnityEngine;

namespace Abilities
{
    public interface IAbilitySource : IDraggable
    {
        Transform Transform { get; }
        void TryAssignToAbilityTarget();
    }
}