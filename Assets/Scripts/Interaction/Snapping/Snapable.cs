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

        public Transform Transform => transform;
        public IShapeContainer ShapeContainer => transform.parent.GetComponent<IShapeContainer>();

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
        
        public List<ISnapPoint> GetSnapPoints()
        {
            //Todo make pretty
            return new List<ISnapPoint>(snapables);
        }
    }
}