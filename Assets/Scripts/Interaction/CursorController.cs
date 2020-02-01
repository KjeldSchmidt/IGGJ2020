using Abilities;
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
        //ToDo Use DropableController instead similar to SnappingController by handing in OnTrigger & Mouse events
        private IDraggable _draggable;
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
            
            _snappingController.OnTriggerStay2D(other);
            
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            IDraggable draggable = other.GetComponent<IDraggable>();
            if ( draggable == null) return;
            
            _draggable?.UnHighlight();
            _draggable = null;
            
            _snappingController.OnTriggerExit2D(other);
        }

        private void Update()
        {
            UpdateMousePosition();

            if(Input.GetMouseButtonDown(0)) AssignAbility.AssignAbilityRaycast( _mainCamera, Input.mousePosition );
            if(Input.GetMouseButton(0)) MouseDown();
            if(Input.GetMouseButtonUp(0)) MouseUp();
        }

        private void UpdateMousePosition()
        {
            Vector2 pos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = pos;
        }

        private void MouseDown()
        {
            if (_draggable == null) return;
            
            //ToDo Call for Dropables only
            //_draggable.UpdatePosition(mousePosition);
            
            _snappingController.MouseDown(transform);
        }
    
        private void MouseUp()
        {
            _snappingController.MouseUp();
        }

    }
}
