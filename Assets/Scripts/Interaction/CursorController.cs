using System.Collections.Generic;
using Interaction.Dragging;
using Interaction.Snapping;
using UnityEngine;

namespace Interaction
{
    [RequireComponent(typeof(SpriteRenderer))]
    class CursorController : MonoBehaviour
    {

        private SpriteRenderer _spriteRenderer;
        private Camera _mainCamera;
        private IDraggable _draggable;
        private Vector2? _draggableOffset;
        private ISnappingController _snappingController;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _snappingController = new SnappingController();
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

            if (Input.GetMouseButtonDown(0))
            {
                foreach (IDraggable draggable in _draggables)
                {
                    draggable.MouseDown();
                }
            }
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

            if (_draggableOffset == null)
            {
                _draggableOffset = _draggable.GetBlockContainerTransform().position- transform.position;
            }

            Vector2? targetPos = transform.position + _draggableOffset;
            _draggable.GetBlockContainerTransform().position = (Vector3) targetPos;
        }
    
        private void MouseUp()
        {
            if (_draggable == null) return;
            
            _snappingController.TrySnapDraggable(_draggable);
            _draggableOffset = null;
            _draggable.MouseUp();
        }

    }
}
