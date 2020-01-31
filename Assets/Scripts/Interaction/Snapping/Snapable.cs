using UnityEngine;

namespace Interaction.Snapping
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

        private bool snapped = false;
        
        public ISnapable GetTriggeredSnapable()
        {
            if (snapped) return null;
            
            return _triggeredSnapable;
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
            
            ISnapable snapable = other.GetComponent<ISnapable>();
            if (snapable == null) return;

            _spriteRenderer.color = _highlightColor;
            _triggeredSnapable = snapable;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (snapped) return;
            
            ISnapable snapable = other.GetComponent<ISnapable>();
            if (snapable == null) return;

            _spriteRenderer.color = _baseColor;
            _triggeredSnapable = null;
        }
    }
}