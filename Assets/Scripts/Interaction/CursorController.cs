using Abilities;
using Interaction.Snapping;
using UnityEngine;

namespace Interaction
{
    [RequireComponent(typeof(SpriteRenderer))]
    class CursorController : MonoBehaviour
    {
        private Camera _mainCamera;
        private ISnappingController _snappingController;
        private IAbilityController _abilityController;

        private void Awake()
        {
            Cursor.visible = false;
            _mainCamera = Camera.main;
            _snappingController = new SnappingController();
            _abilityController = new AbilityController();
        }
        
        private void OnTriggerStay2D(Collider2D other)
        {
            _snappingController.OnTriggerStay2D(other);
            _abilityController.OnTriggerStay2D(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _snappingController.OnTriggerExit2D(other);
            _abilityController.OnTriggerExit2D(other);
        }

        private void Update()
        {
            UpdateMousePosition();

            if (Input.GetMouseButtonDown(0))
            {
                //rotate on button down
                var rot = transform.eulerAngles;
                rot.z = 90;
                transform.eulerAngles = rot;
            }
            
            if(Input.GetMouseButton(0)) MouseDown();
            if(Input.GetMouseButtonUp(0)) MouseUp();
        }

        private void UpdateMousePosition()
        {
            Vector3 pos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            pos.z = -9;
            transform.position = pos;
        }

        private void MouseDown()
        {
            _abilityController.MouseDown(transform);
            if (_abilityController.IsDragging()) return;
            
            _snappingController.MouseDown(transform);
        }
    
        private void MouseUp()
        {
            //reset rotate on button up
            var rot = transform.eulerAngles;
            rot.z = 45;
            transform.eulerAngles = rot;
            
            _snappingController.MouseUp();
            _abilityController.MouseUp();
        }

    }
}
