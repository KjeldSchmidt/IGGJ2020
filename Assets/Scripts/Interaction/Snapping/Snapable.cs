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
        public Transform Transform => transform;
        public IShapeContainer ShapeContainer => transform.parent.GetComponent<IShapeContainer>();
        
        [SerializeField] private List<SnapPoint> snapables;

        private Collider2D _collider2D;

        public override void Highlight()
        {
        }

        public override void UnHighlight()
        {
        }

        public Transform GetBlockContainerTransform()
        {
            return transform.parent;
        }

        public void SetIsTrigger(bool val)
        {
            GetComponent<Collider2D>().isTrigger = val;
        }

        public List<ISnapPoint> GetSnapPoints()
        {
            //Todo make pretty
            return new List<ISnapPoint>(snapables);
        }
    }
}