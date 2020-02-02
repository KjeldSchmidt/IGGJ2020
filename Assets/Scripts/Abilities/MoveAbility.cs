using Interaction.Containers;
using UnityEngine;

namespace Abilities
{
    public class MoveAbility : AbstractAbility
    {
        [SerializeField] private Vector2 movementDirection = default;
        [SerializeField] private float acceleration = 0.1f;
        [SerializeField] private float maxVelocity = 1f;
        [SerializeField] private float gravityScale = 0.01f;
        
        private ShapeContainer _shapeContainer;
        private bool _started;

        public override void StartUsingAbility()
        {
            _shapeContainer = transform.parent.parent.GetComponent<ShapeContainer>();
            _shapeContainer.SetGravityScale(gravityScale);
            _shapeContainer.SetMaxVelocity(maxVelocity);
            _started = true;
        }
        
        private void Update()
        {
            if (!_started) return;
            
            _shapeContainer.AddAcceleration(movementDirection * acceleration);
        }

        public override void Deactivate() { }
    }
}