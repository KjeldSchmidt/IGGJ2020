using UnityEngine;

namespace Abilities
{
    public class AbilitySource : MonoBehaviour, IAbilitySource
    {
        [SerializeField] private GameObject abilityPrefab;
        private AbilityTarget _abilityTarget;
        
        public Transform Transform => transform;

        private void OnTriggerEnter2D(Collider2D other)
        {
            AbilityTarget abilityTarget = other.GetComponent<AbilityTarget>();
            if (!abilityTarget) return;
            
            _abilityTarget = abilityTarget;
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            AbilityTarget abilityTarget = other.GetComponent<AbilityTarget>();
            if (!abilityTarget) return;

            _abilityTarget = null;
        }

        public void Highlight()
        {
            transform.localScale = Vector3.one * 1.2f;
        }

        public void UnHighlight()
        {
            transform.localScale = Vector3.one;
        }

        public void UpdatePosition(Vector2 pos)
        {
            transform.position = pos;
        }
        
        public void TryAssignToAbilityTarget()
        {
            if (!_abilityTarget) return;
            
            _abilityTarget.AssignAbility(abilityPrefab); 
            Destroy(gameObject);
        }
        
    }
}
