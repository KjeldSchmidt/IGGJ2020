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
        [SerializeField] private Vector2 massRange;
        [SerializeField] private List<Rigidbody2D> rigidbodies;

        [SerializeField] private float toolChance;
        [SerializeField] private List<GameObject> toolPrefabs;
        [SerializeField] private List<Transform> toolSlots;
        
        private void Awake()
        {
            SetTools();
            SetLinearDrag();
            SetAngularDrag();
            SetMass();
            AddVelocity();
            AddTorque();
        }

        private void SetTools()
        {
            foreach (Transform toolSlotTransform in toolSlots)
            {
                if (Random.Range(0, 2) < toolChance) continue;
                GameObject prefab = toolPrefabs[Random.Range(0, toolPrefabs.Count)];
                Instantiate(prefab, toolSlotTransform);
            }
        }
        
        public void SetMass()
        {
            foreach (Rigidbody2D rb in rigidbodies)
            {
                rb.mass = Random.Range(massRange.x, massRange.y);
            }
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