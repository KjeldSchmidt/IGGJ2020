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

            draggable.Highlight();
            _draggables.Add(draggable);
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            IDraggable draggable = other.GetComponent<IDraggable>();
            if (draggable == null) return;

            draggable.UnHighlight();
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
            _draggables.Clear();
        }
    }
}