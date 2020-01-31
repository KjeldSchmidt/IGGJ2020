using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    [RequireComponent(typeof(SpriteRenderer))]
    class CursorController : MonoBehaviour
    {

        private SpriteRenderer _spriteRenderer;
        private Camera _mainCamera;
        private IDraggable _draggable;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        private void OnTriggerStay2D(Collider2D other)
        {
            IDraggable draggable = other.GetComponent<IDraggable>();
            if (draggable == null) return;

            if (_draggable!= null && _draggable != draggable)
            {
                _draggable.UnHighlight();
            }
            
            draggable.Highlight();
            _draggable = draggable;
            
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            IDraggable draggable = other.GetComponent<IDraggable>();
            if (draggable == null) return;
            
            _draggable?.UnHighlight();
            _draggable = null;
        }

        private void Update()
        {
            UpdateMousePosition();
            
            if(Input.GetMouseButton(0))
                MouseDown();
            if(Input.GetMouseButtonUp(0))
                MouseUp();
        }

        private void UpdateMousePosition()
        {
            Vector2 pos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = pos;
        }

        private void MouseDown()
        {
            if (_draggable == null) return;
            
            _draggable.GetBlockContainerTransform().position = transform.position;
        }
    
        private void MouseUp()
        {
            if (_draggable == null) return;
            
            TrySnapDraggable(_draggable);
        }
        
        //ToDo move into another script

        private void TrySnapDraggable(IDraggable draggable)
        {
            List<ISnapable> snapables = draggable.GetSnapables();
            foreach (ISnapable snapable in snapables)
            {
                ISnapable targetSnapable = snapable.GetTriggeredSnapable();
                if (targetSnapable != null)
                {
                    SnapDraggable(snapable, targetSnapable);
                    return;
                }
            }
        }

        private void SnapDraggable(ISnapable selected, ISnapable target)
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
            GameObject selectedContainer = selectedParentTransform.parent.gameObject;
            selectedParentTransform.parent = targetTransform.parent.parent;
            Destroy(selectedContainer);
            
            //Deactivates used Snapables
            selected.SetSnapped();
            target.SetSnapped();
        }
        
    }
}