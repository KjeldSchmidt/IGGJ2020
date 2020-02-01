using System.Collections.Generic;
using Interaction.Containers;
using Interaction.Dragging;
using UnityEngine;
using UnityEngine.Serialization;

namespace Interaction.Snapping
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Snapable: Draggable, ISnapable
    {
        [SerializeField] private List<SnapPoint> snapables;
        private SpriteRenderer _spriteRenderer;
        private Color _baseColor;
        
        public Transform Transform => transform;
        public IShapeContainer ShapeContainer => transform.parent.GetComponent<IShapeContainer>();
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _baseColor = _spriteRenderer.color;
        }

        public void UpdatePosition(Vector2 pos)
        {
            transform.position = pos;
        }
        
        public Transform GetBlockContainerTransform()
        {
            return transform.parent;
        }
        
        public List<ISnapPoint> GetSnapPoints()
        {
            //Todo make pretty
            //return new List<ISnapPoint>(snapables);
            return null;
        }
    }
}