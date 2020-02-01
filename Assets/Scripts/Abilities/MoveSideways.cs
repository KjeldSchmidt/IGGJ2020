using System;
using UnityEngine;

namespace Abilities
{
    public class MoveSideways : MonoBehaviour, IAbility
    {
        private bool _active;
        private Transform _blockCollection;
        private Vector3 _movementDirection = Vector3.right;
        private float speed = 0.2f;
        
        public void StartUsingAbility()
        {
            Debug.Log(name);
            Debug.Log(transform.parent.name);
            Debug.Log(transform.parent.parent.name);
            _blockCollection = transform.parent.parent;
            _active = true;
        }

        public void Deactivate()
        {
            _active = false;
        }

        public void Start()
        {
            GameObject.Find("StartButton").GetComponent<StartButton>().RegisterAbility( this );
        }

        public void Update()
        {
            if (_active)
            {
                _blockCollection.position += _movementDirection * (Time.deltaTime * speed);   
            }
        }
    }
   
}