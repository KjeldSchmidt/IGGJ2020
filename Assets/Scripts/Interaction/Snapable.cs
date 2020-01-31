using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Snapable: MonoBehaviour, ISnapable
    {
       // [SerializeField] private List<Transform> snapTransforms;

        private SpriteRenderer _spriteRenderer;
        private Color _baseColor;
        private readonly Color _highlightColor = Color.black;
        private ISnapable _triggeredSnapable;
        
        public ISnapable GetTriggeredSnapable()
        {
            return _triggeredSnapable;
        }

        public Transform GetTransform()
        {
            return transform;
        }
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _baseColor = _spriteRenderer.color;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            ISnapable snapable = other.GetComponent<ISnapable>();
            if (snapable == null) return;

            _spriteRenderer.color = _highlightColor;
            _triggeredSnapable = snapable;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            ISnapable snapable = other.GetComponent<ISnapable>();
            if (snapable == null) return;

            _spriteRenderer.color = _baseColor;
            _triggeredSnapable = null;
        }
    }
}