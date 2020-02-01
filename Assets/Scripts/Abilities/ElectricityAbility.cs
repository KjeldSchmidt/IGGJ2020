using Interaction.Containers;
using UnityEngine;

namespace Abilities
{
    public class ElectricityAbility : AbstractAbility
    {
        private bool _active;
        private ShapeContainer _shapeContainer;
        private Vector3 _movementDirection = Vector3.up;
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

    }
}