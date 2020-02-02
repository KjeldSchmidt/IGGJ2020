using System;
using UnityEngine;

namespace Interaction.Snapping
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class SnapPoint: MonoBehaviour, ISnapPoint
    {
        [SerializeField] private Directions snapDirection = default;
        [SerializeField] private Sprite snappedSprite = default;
        
        private SpriteRenderer _spriteRenderer;
        private Sprite _baseSprite;
        private ISnapPoint _triggeredSnapPoint;

        public bool Snapped { get; private set; }

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

        private void OnTriggerStay2D(Collider2D other)
        {
            if (Snapped) return;
            
            ISnapPoint snapPoint = other.GetComponent<ISnapPoint>();
            if (snapPoint == null) return;

            if (snapPoint.Snapped) return;
            if (!AreOppositeDirections(snapDirection, snapPoint.GetSnapDirection())) return;
            
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
        
        private bool AreOppositeDirections(Directions dir1, Directions dir2)
        {
            if (dir1 == Directions.UP && dir2 == Directions.DOWN) return true;
            if (dir1 == Directions.DOWN && dir2 == Directions.UP) return true;
            if (dir1 == Directions.LEFT && dir2 == Directions.RIGHT) return true;
            if (dir1 == Directions.RIGHT && dir2 == Directions.LEFT) return true;
            return false;
        }

    }
}