using System;
using UnityEngine;

namespace Abilities
{
    public class AbilitySource : MonoBehaviour, IAbilitySource
    {
        public Transform Transform => transform;
        
        [SerializeField] private GameObject abilityPrefab = default;
        private Vector2 _highlightScale;
        
        private Vector2 _baseScale;
        private Collider2D _collider2D;
        private AbilityTarget _abilityTarget;

        private void Awake()
        {
            _baseScale = transform.localScale;
            _highlightScale = new Vector2(_baseScale.x* 1.2f, _baseScale.y*1.2f);
            _collider2D = GetComponent<Collider2D>();
        }

        private void OnTriggerStay2D(Collider2D other)
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
            transform.localScale = _highlightScale;
        }

        public void UnHighlight()
        {
            transform.localScale = _baseScale;
        }

        public void UpdatePosition(Vector2 pos)
        {
            transform.position = pos;
        }

        public void SetIsTrigger(bool val)
        {
            _collider2D.isTrigger = val;
        }

        public void TryAssignToAbilityTarget()
        {
            if (!_abilityTarget) return;
            
            bool success = _abilityTarget.AssignAbility(abilityPrefab); 
            if(success) Destroy(gameObject);
        }
        
    }
}
