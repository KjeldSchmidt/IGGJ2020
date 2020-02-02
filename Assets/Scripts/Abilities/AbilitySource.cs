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
        private Rigidbody2D _rigidbody2D;
        private float _lastGravityScale;


        private Vector2 _colliderBaseScale;
     private Vector2 _colliderDragScale;
     private float _colliderBaseRadius;
     private float _colliderDragRadius;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _baseScale = transform.localScale;
            _highlightScale = new Vector2(_baseScale.x* 1.4f, _baseScale.y*1.4f);
            _collider2D = GetComponent<Collider2D>();

         if (_collider2D is BoxCollider2D)
         {
             BoxCollider2D boxCollider2D = (BoxCollider2D) _collider2D;
             _colliderBaseScale = boxCollider2D.size;
             _colliderDragScale = new Vector2(boxCollider2D.size.x/4f, boxCollider2D.size.y/4f);
         }
         
         if (_collider2D is CircleCollider2D)
         {
             CircleCollider2D circleCollider2D = (CircleCollider2D) _collider2D;
             _colliderBaseRadius = circleCollider2D.radius;
             _colliderDragRadius = circleCollider2D.radius / 4f;
         }

        }

        private void OnTriggerStay2D(Collider2D other)
        {
            AbilityTarget abilityTarget = other.GetComponent<AbilityTarget>();
            if (!abilityTarget) return;
            
            if (Math.Abs(_rigidbody2D.gravityScale) >0.001f) _lastGravityScale = _rigidbody2D.gravityScale;
            _rigidbody2D.gravityScale = 0;
            _abilityTarget = abilityTarget;
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            AbilityTarget abilityTarget = other.GetComponent<AbilityTarget>();
            if (!abilityTarget) return;
            
           if (_collider2D is BoxCollider2D)
           {
               BoxCollider2D boxCollider2D = (BoxCollider2D) _collider2D;
               boxCollider2D.size = _colliderBaseScale;
           }
           else  if (_collider2D is CircleCollider2D)
           {
               CircleCollider2D circleCollider2D = (CircleCollider2D) _collider2D;
               circleCollider2D.radius = _colliderBaseRadius;
           }
          _rigidbody2D.gravityScale = _lastGravityScale;
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
          // if (_collider2D is BoxCollider2D)
          // {
          //     BoxCollider2D boxCollider2D = (BoxCollider2D) _collider2D;
          //     boxCollider2D.size = _colliderDragScale;
          // }
          // else  if (_collider2D is CircleCollider2D)
          // {
          //     CircleCollider2D circleCollider2D = (CircleCollider2D) _collider2D;
          //     circleCollider2D.radius = _colliderDragRadius;
          // }

        }

        public void TryAssignToAbilityTarget()
        {
            if (!_abilityTarget) return;
            
            bool success = _abilityTarget.AssignAbility(abilityPrefab); 
            if(success) Destroy(gameObject);
        }
        
    }
}
