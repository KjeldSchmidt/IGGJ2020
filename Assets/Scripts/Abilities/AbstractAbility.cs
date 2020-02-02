using UnityEngine;

namespace Abilities
{
    public abstract class AbstractAbility : MonoBehaviour, IAbility
    {
        [SerializeField] private ElectricityAbility electricityAbility;
        
        public void Start()
        {
            //electricityAbility.RegisterAbility(this);
        }
        
        public abstract void StartUsingAbility();
        public abstract void Deactivate();
    }
}