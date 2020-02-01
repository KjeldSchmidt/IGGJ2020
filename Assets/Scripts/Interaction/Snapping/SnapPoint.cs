using UnityEngine;

namespace Interaction.Snapping
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class SnapPoint: MonoBehaviour, ISnapPoint
    {
        [SerializeField] private Directions snapDirection;
        [SerializeField] private Sprite snappedSprite;
        
        private SpriteRenderer _spriteRenderer;
        private Sprite _baseSprite;
        private readonly Color _highlightColor = Color.black;
        private ISnapPoint _triggeredSnapPoint;

        public bool Snapped { get; private set; }
        public ISnapable Snapable => transform.parent.GetComponent<ISnapable>();

        public Directions GetSnapDirection()
        {
            return snapDirection;
        }

        public ISnapPoint GetTriggeredSnapable()
        {
            if (Snapped) return null;
            
            return _triggeredSnapPoint;
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public void SetSnapped()
        {
            Snapped = true;
            _spriteRenderer.sprite = snappedSprite;
        }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _baseSprite = _spriteRenderer.sprite;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (Snapped) return;
            
            ISnapPoint snapPoint = other.GetComponent<ISnapPoint>();
            if (snapPoint == null) return;

            if (snapPoint.Snapped) return;

            _spriteRenderer.sprite = snappedSprite;
            _triggeredSnapPoint = snapPoint;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (Snapped) return;
            
            ISnapPoint snapPoint = other.GetComponent<ISnapPoint>();
            if (snapPoint == null) return;

            _spriteRenderer.sprite = _baseSprite;
            _triggeredSnapPoint = null;
        }
    }
}