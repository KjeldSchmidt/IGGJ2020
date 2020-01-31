using UnityEngine;

namespace Interaction.Snapping
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class SnapPoint: MonoBehaviour, ISnapPoint
    {
       // [SerializeField] private List<Transform> snapTransforms;

        private SpriteRenderer _spriteRenderer;
        private Color _baseColor;
        private readonly Color _highlightColor = Color.black;
        private ISnapPoint _triggeredSnapPoint;

        private bool snapped = false;
        
        public ISnapPoint GetTriggeredSnapable()
        {
            if (snapped) return null;
            
            return _triggeredSnapPoint;
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public void SetSnapped()
        {
            snapped = true;
            _spriteRenderer.color = _baseColor;
        }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _baseColor = _spriteRenderer.color;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (snapped) return;
            
            ISnapPoint snapPoint = other.GetComponent<ISnapPoint>();
            if (snapPoint == null) return;

            _spriteRenderer.color = _highlightColor;
            _triggeredSnapPoint = snapPoint;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (snapped) return;
            
            ISnapPoint snapPoint = other.GetComponent<ISnapPoint>();
            if (snapPoint == null) return;

            _spriteRenderer.color = _baseColor;
            _triggeredSnapPoint = null;
        }
    }
}