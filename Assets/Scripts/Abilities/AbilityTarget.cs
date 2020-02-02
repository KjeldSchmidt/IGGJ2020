using UnityEngine;

namespace Abilities
{
    public class AbilityTarget : MonoBehaviour
    {
        public bool requiresElectricity = false;
        [SerializeField] private int maxAbilities = 1;
        [SerializeField] private Transform abilitySlot;
        
        private StartButton _startButton;
        private int remainingAbilities;

        public void Start()
        {
            remainingAbilities = maxAbilities;
        }

        public bool AssignAbility( GameObject abilityPrefab )
        { 
            if (remainingAbilities == 0) return false;
            GameObject go = Instantiate( abilityPrefab, transform );
            go.transform.position = abilitySlot.transform.position;
            remainingAbilities--;
            return true;
        }
    }
}