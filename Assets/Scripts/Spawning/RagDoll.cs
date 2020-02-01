using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawning
{
    public class RagDoll: MonoBehaviour
    {
        [SerializeField] private Vector2 startDragRange;
        [SerializeField] private Vector2 startAngularDragRange;
        [SerializeField] private Vector2 startTorqueRange;
        [SerializeField] private Vector2 startVelocityRange;
        [SerializeField] private List<Rigidbody2D> rigidbodies;

        private void Awake()
        {
            SetLinearDrag();
            SetAngularDrag();
            AddVelocity();
            AddTorque();
        }

        public void SetLinearDrag()
        {
            foreach (Rigidbody2D rb in rigidbodies)
            {
                rb.drag = Random.Range(startDragRange.x, startDragRange.y);
            }
        }

        public void SetAngularDrag()
        {
            foreach (Rigidbody2D rb in rigidbodies)
            {
                rb.angularDrag = Random.Range(startAngularDragRange.x, startAngularDragRange.y);
            } 
        }
        public void AddVelocity()
        {
            foreach (Rigidbody2D rb in rigidbodies)
            {
                Vector3 velocity = new Vector2(
                    Random.Range(-startVelocityRange.x, startVelocityRange.x),
                    Random.Range(-startVelocityRange.y, startVelocityRange.y)
                );
                rb.velocity = velocity;
            }

        }
        public void AddTorque()
        {
            foreach (Rigidbody2D rb in rigidbodies)
            {
                rb.AddTorque(Random.Range(startTorqueRange.x, startTorqueRange.y));
            }
        }
    }
}