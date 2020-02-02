using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
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

        [SerializeField] private float toolChance;
        [SerializeField] private List<GameObject> toolPrefabs;
        [SerializeField] private List<Transform> toolSlots;

        [SerializeField] private SpriteRenderer deadEyesSpriteRenderer;

        private Counter _counter;
    //    private bool _hitGround;
        
        public void SetDead()
        {
            deadEyesSpriteRenderer.enabled = true;
            _counter?.IncreaseCounter();
        }

        public void SetCounter(Counter counter)
        {
            _counter = counter;
        }
        
        private void Awake()
        {
            SetTools();
            SetLinearDrag();
            SetAngularDrag();
            AddVelocity();
            AddTorque();
        }

       // private void Update()
       // {
       //     //Destroy after ragdoll joined camera & left it again
       //     if (transform.position.y < 8) _hitGround = true;
       //     if(_hitGround && transform.position.y > 10 || transform.position.y < -10 || transform.position.x < -5 || transform.position.x > 20) Destroy(gameObject);
       //     
       // }

        private void SetTools()
        {
            foreach (Transform toolSlotTransform in toolSlots)
            {
                if (Random.Range(0, 2) < toolChance) continue;
                GameObject prefab = toolPrefabs[Random.Range(0, toolPrefabs.Count)];
                Instantiate(prefab, toolSlotTransform);
            }
        }

        private void SetLinearDrag()
        {
            foreach (Rigidbody2D rb in rigidbodies)
            {
                rb.drag = Random.Range(startDragRange.x, startDragRange.y);
            }
        }

        private void SetAngularDrag()
        {
            foreach (Rigidbody2D rb in rigidbodies)
            {
                rb.angularDrag = Random.Range(startAngularDragRange.x, startAngularDragRange.y);
            } 
        }
        private void AddVelocity()
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
        private void AddTorque()
        {
            foreach (Rigidbody2D rb in rigidbodies)
            {
                rb.AddTorque(Random.Range(startTorqueRange.x, startTorqueRange.y));
            }
        }
    }
}