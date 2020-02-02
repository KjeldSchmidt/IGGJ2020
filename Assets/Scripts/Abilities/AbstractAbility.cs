using UnityEngine;

namespace Abilities
{
    public abstract class AbstractAbility : MonoBehaviour, IAbility
    {
        public abstract void StartUsingAbility();
        public abstract void Deactivate();
    }
}