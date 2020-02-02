using Interaction.Containers;
using UnityEngine;

namespace Abilities
{
    public class AbilityTarget : MonoBehaviour
    {
        public bool requiresElectricity = false;

        [SerializeField] private int maxAbilities = 1;
        [SerializeField] private Transform abilitySlot = default;
        
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
            
            IShapeContainer shapeContainer = transform.parent.GetComponent<IShapeContainer>();
            shapeContainer.PrepareStart();

            return true;
        }
    }
}