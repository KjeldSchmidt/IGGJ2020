using UnityEngine;

namespace Interaction.Snapping
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class SnapPoint: MonoBehaviour, ISnapPoint
    {
        [SerializeField] private Sprite snappedSprite;
        
        private SpriteRenderer _spriteRenderer;
        private Sprite _baseSprite;
        private readonly Color _highlightColor = Color.black;
        private ISnapPoint _triggeredSnapPoint;

        private bool _snapped = false;
        
        public ISnapPoint GetTriggeredSnapable()
        {
            if (_snapped) return null;
            
            return _triggeredSnapPoint;
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public void SetSnapped()
        {
            _snapped = true;
            _spriteRenderer.sprite = snappedSprite;
        }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _baseSprite = _spriteRenderer.sprite;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_snapped) return;
            
            ISnapPoint snapPoint = other.GetComponent<ISnapPoint>();
            if (snapPoint == null) return;

            _spriteRenderer.sprite = snappedSprite;
            _triggeredSnapPoint = snapPoint;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (_snapped) return;
            
            ISnapPoint snapPoint = other.GetComponent<ISnapPoint>();
            if (snapPoint == null) return;

            _spriteRenderer.sprite = _baseSprite;
            _triggeredSnapPoint = null;
        }
    }
}