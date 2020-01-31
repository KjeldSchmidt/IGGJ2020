using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    [RequireComponent(typeof(SpriteRenderer))]
    class CursorController : MonoBehaviour
    {

        private SpriteRenderer _spriteRenderer;
        private Camera _mainCamera;
        private List<IDraggable> _draggables = new List<IDraggable>();

        private void Awake()
        {
            _mainCamera = Camera.main;
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            IDraggable draggable = other.GetComponent<IDraggable>();
            if (draggable == null) return;

           // draggable.Highlight();
            _draggables.Add(draggable);
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            IDraggable draggable = other.GetComponent<IDraggable>();
            if (draggable == null) return;

         //   draggable.UnHighlight();
            _draggables.Remove(draggable);
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
            foreach (IDraggable draggable in _draggables)
            {
                draggable.UpdatePosition(transform.position);
            }
        }
    
        private void MouseUp()
        {
            foreach (IDraggable draggable in _draggables)
            {
                bool snapped = TrySnapDraggable(draggable);
                if (snapped) return;
            }
            _draggables.Clear();
        }
        
        //ToDo move into another script

        private bool TrySnapDraggable(IDraggable draggable)
        {
            List<ISnapable> snapables = draggable.GetSnapables();
            foreach (ISnapable snapable in snapables)
            {
                ISnapable targetSnapable = snapable.GetTriggeredSnapable();
                if (targetSnapable != null)
                {
                    SnapDraggable(snapable, targetSnapable);
                    return true;
                }
            }

            return false;
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
        }
        
    }
}