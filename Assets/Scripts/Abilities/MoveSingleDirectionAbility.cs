using System;
using Interaction.Containers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Abilities
{
    public class MoveSingleDirectionAbility : AbstractAbility
    {
        private ShapeContainer _shapeContainer;
        public Vector2 movementDirection;
        public float speed = 0.2f;
        
        public override void StartUsingAbility()
        {
            _shapeContainer = transform.parent.parent.GetComponent<ShapeContainer>();
            _shapeContainer.RegisterForce( movementDirection * speed );
        }

        public override void Deactivate() { }
    }
}