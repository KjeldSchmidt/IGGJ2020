using UnityEngine;

namespace Abilities
{
    class AbilityController: IAbilityController
    {
        private IAbilitySource _abilitySource;
        private bool _isDragging;

        public void OnTriggerStay2D(Collider2D other)
        {
            if (_abilitySource != null) return;
            
            IAbilitySource abilitySource = other.GetComponent<IAbilitySource>();
            if (abilitySource == null) return;

            if (_abilitySource != null && _abilitySource != abilitySource)
            {
                _abilitySource.UnHighlight();
            }
            
            abilitySource.Highlight();
            _abilitySource = abilitySource;
            
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            IAbilitySource abilitySource = other.GetComponent<IAbilitySource>();
            if ( abilitySource == null) return;

            _abilitySource?.UnHighlight();

            if (_abilitySource != abilitySource) return;
            _abilitySource = null;
        }

        public void MouseDown(Transform mouseTransform)
        {
            if (_abilitySource == null) return;

            Vector2 targetPos = mouseTransform.position;
            _abilitySource.Transform.position = targetPos;
            _isDragging = true;
            _abilitySource.SetIsTrigger(true);
        }
    
        public void MouseUp()
        {
            if (_abilitySource == null) return;

            _abilitySource.TryAssignToAbilityTarget();
            _abilitySource?.SetIsTrigger(false);
            _abilitySource = null;
            _isDragging = false;
        }

        public bool IsDragging()
        {
            return _isDragging;
        }
    }
}