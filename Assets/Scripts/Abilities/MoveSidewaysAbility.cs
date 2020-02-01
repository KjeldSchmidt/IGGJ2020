using System;
using Interaction.Containers;
using UnityEngine;

namespace Abilities
{
    public class MoveSidewaysAbility : AbstractAbility
    {
        private bool _active;
        private ShapeContainer _shapeContainer;
        private Vector3 _movementDirection = Vector3.right;
        private float speed = 0.2f;
        
        public override void StartUsingAbility()
        {
            _shapeContainer = transform.parent.parent.GetComponent<ShapeContainer>();
            _active = true;
        }

        public override void Deactivate()
        {
            _active = false;
        }

        public void Update()
        {
            if (_active)
            {
                   
            }
        }
    }
}