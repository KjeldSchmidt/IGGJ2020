using System.Collections.Generic;
using Interaction.Containers;
using UnityEngine;

namespace Interaction.Snapping
{
    class SnappingController: ISnappingController
    {
        private ISnapable _snapable;
        private Vector2? _snapableOffset;

        public void OnTriggerStay2D(Collider2D other)
        {
            ISnapable snapable = other.GetComponent<ISnapable>();
            if (snapable == null) return;

            if (_snapable!= null && _snapable != snapable)
            {
                _snapable.UnHighlight();
            }
            
            snapable.Highlight();
            _snapable = snapable;
            
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            ISnapable snapable = other.GetComponent<ISnapable>();
            if ( snapable == null) return;
            
            _snapable?.UnHighlight();
            _snapable = null;
            _snapableOffset = null;
        }

        public void MouseDown(Transform mouseTransform)
        {
            if (_snapable == null) return;
            
            if (_snapableOffset == null)
            {
                _snapableOffset = _snapable.GetBlockContainerTransform().position - mouseTransform.position;
            }

            Vector2? targetPos = mouseTransform.position + _snapableOffset;
            _snapable.GetBlockContainerTransform().position =  (Vector3) targetPos;
            
        }
    
        public void MouseUp()
        {
            if (_snapable == null) return;

            TrySnapsnapable(_snapable);
            _snapableOffset = null;
        }

        private void TrySnapsnapable(ISnapable snapable)
        {
            List<ISnapPoint> snapPoints = snapable.GetSnapPoints();
            foreach (ISnapPoint snapPoint in snapPoints)
            {
                ISnapPoint targetSnapPoint = snapPoint.GetTriggeredSnapable();
                if (targetSnapPoint != null)
                {
                    if (!AreOppositeDirections(snapPoint.GetSnapDirection(), targetSnapPoint.GetSnapDirection())) continue;
                    
                    Snapsnapable(snapPoint, targetSnapPoint);
                    return;
                }
            }
        }

        private bool AreOppositeDirections(Directions dir1, Directions dir2)
        {
            if (dir1 == Directions.UP && dir2 == Directions.DOWN) return true;
            if (dir1 == Directions.DOWN && dir2 == Directions.UP) return true;
            if (dir1 == Directions.LEFT && dir2 == Directions.RIGHT) return true;
            if (dir1 == Directions.RIGHT && dir2 == Directions.LEFT) return true;
            return false;
        }

        private void Snapsnapable(ISnapPoint selected, ISnapPoint target)
        {
            //ToDo check for left/right/up/down pos?
            Transform targetTransform = target.GetTransform();
            Transform selectedParentTransform = selected.GetTransform().parent.transform;
            float xOffset = selected.GetTransform().position.x - selectedParentTransform.position.x;
            float yOffset = selected.GetTransform().position.y - selectedParentTransform.position.y;
            Vector2 targetPosition = new Vector2(targetTransform.position.x - xOffset, targetTransform.position.y -yOffset);

            //Debug.Log("xOffset: " + xOffset + "/yOffset: " + yOffset);
            //Debug.Log("curPos: " + selectedParentTransform.position);
            //Debug.Log("targetPos: " + targetPosition);
            
            selectedParentTransform.position = targetPosition;
            
            //Move to target BlockContainer
            IShapeContainer toDestroy = selectedParentTransform.parent.GetComponent<IShapeContainer>();
            selectedParentTransform.parent = targetTransform.parent.parent;
            toDestroy.Destroy();
            
            //Deactivates used Snapables
            selected.SetSnapped();
            target.SetSnapped();
        }
        
    }
}