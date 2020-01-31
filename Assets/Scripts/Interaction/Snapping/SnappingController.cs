using System.Collections.Generic;
using Interaction.Containers;
using Interaction.Dragging;
using UnityEngine;

namespace Interaction.Snapping
{
    class SnappingController: ISnappingController
    {
        public void TrySnapDraggable(ISnapable snapable)
        {
            List<ISnapPoint> snapPoints = snapable.GetSnapables();
            foreach (ISnapPoint snapPoint in snapPoints)
            {
                ISnapPoint targetSnapPoint = snapPoint.GetTriggeredSnapable();
                if (targetSnapPoint != null)
                {
                    SnapDraggable(snapPoint, targetSnapPoint);
                    return;
                }
            }
        }

        private void SnapDraggable(ISnapPoint selected, ISnapPoint target)
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