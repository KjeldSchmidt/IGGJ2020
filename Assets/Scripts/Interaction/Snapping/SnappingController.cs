using System;
using System.Collections.Generic;
using Interaction.Containers;
using UnityEngine;

namespace Interaction.Snapping
{
    class SnappingController: ISnappingController
    {
        private ISnapable _snapable;
        private Vector2? _snapableOffset;
        private bool _isDragging;
        private ISnapForest _snapForest = new SnapForest();
        private AudioSource _snapSound;
        private float _lastGravityScale;

        public void OnTriggerStay2D(Collider2D other)
        {
            if (_snapable != null) return;
            
            ISnapable snapable = other.GetComponent<ISnapable>();
            if (snapable == null) return;

            if (_snapable != null && _snapable != snapable)
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

            if (_snapable != snapable) return;
            
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

            foreach (ISnapable snapable in _snapable.ShapeContainer.Transform.GetComponentsInChildren<ISnapable>())
            {
                snapable.SetIsTrigger(true);
            }
            _isDragging = true;
            Vector2? targetPos = mouseTransform.position + _snapableOffset;
            _snapable.GetBlockContainerTransform().position = (Vector3) targetPos;

            Rigidbody2D snapableRb = _snapable.Transform.parent.GetComponent<Rigidbody2D>();
            if (Math.Abs(snapableRb.gravityScale) > 0.001f) _lastGravityScale = snapableRb.gravityScale;
            snapableRb.gravityScale = 0;
        }
    
        public void MouseUp()
        {
            if (_snapable == null) return;

            foreach (ISnapable snapable in _snapable.ShapeContainer.Transform.GetComponentsInChildren<ISnapable>())
            {
                TrySnap(snapable);
                _snapable.SetIsTrigger(false);
            }
            _snapable.Transform.parent.GetComponent<Rigidbody2D>().gravityScale = _lastGravityScale;
            _isDragging = false;
            _snapableOffset = null;
            _snapable = null;
        }
        
        private void TrySnap(ISnapable snapable)
        {
            List<ISnapPoint> snapPoints = snapable.GetSnapPoints();
            foreach (ISnapPoint snapPoint in snapPoints)
            {
                ISnapPoint targetSnapPoint = snapPoint.GetTriggeredSnapable();
                if (targetSnapPoint != null && snapPoint.GetTransform().parent.parent != targetSnapPoint.GetTransform().parent.parent)
                {
                    Snapsnapable(snapPoint, targetSnapPoint);
                    return;
                }
            }
        }
        
        private void Snapsnapable(ISnapPoint selected, ISnapPoint target)
        {
            Transform selectedSnapPoint = selected.GetTransform();
            Transform selectedSnapable = selectedSnapPoint.parent;
            Transform selectedShapeContainer = selectedSnapable.parent;
            Transform targetSnapPoint = target.GetTransform();
            Transform targetSnapable = targetSnapPoint.parent;
            Transform targetShapeContainer = targetSnapable.parent;
 
            float xOffset = selectedSnapPoint.position.x - selectedSnapable.position.x;
            float yOffset = selectedSnapPoint.position.y - selectedSnapable.position.y;
            Vector2 targetPosition = new Vector2(targetSnapPoint.position.x - xOffset, targetSnapPoint.position.y -yOffset);

            Vector2 startPos = selectedSnapable.position;

            float xOffsetTotal = startPos.x - targetPosition.x ;
            float yOffsetTotal = startPos.y - targetPosition.y;
            
            //Move to target BlockContainer
            foreach (ISnapable snapable in selectedShapeContainer.GetComponentsInChildren<ISnapable>())
            {
                Transform shape = snapable.Transform;
                shape.parent = targetShapeContainer;

                Vector3 position = shape.position;
                position = new Vector2(position.x - xOffsetTotal, position.y -yOffsetTotal);
                shape.position = position;
            }
            targetShapeContainer.GetComponent<IShapeContainer>().PrepareStart();
            
            //Destroy old Container
            selectedShapeContainer.GetComponent<IShapeContainer>().Destroy();
            
            _snapForest.Join(
                selected.GetTransform().parent.GetComponent<Snapable>(),
                target.GetTransform().parent.GetComponent<Snapable>()
            );
            
            //Deactivates used Snapables
            selected.SetSnapped();
            target.SetSnapped();

            if (_snapSound == null) PrepareSnapSound( );
            _snapSound.Play();
        }

        private void PrepareSnapSound( )
        {
            Debug.Log("Prepare snap sound!");
            GameObject soundObj = new GameObject("Snap Sound Object");
            _snapSound = soundObj.AddComponent<AudioSource>();
            _snapSound.clip = Resources.Load("SoundEffects/Snap/SnapSound") as AudioClip;
        }
        
        public bool IsDragging()
        {
            return _isDragging;
        }
    }
}