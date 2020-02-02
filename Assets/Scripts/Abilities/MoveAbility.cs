using Interaction.Containers;
using UnityEngine;

namespace Abilities
{
    public class MoveAbility : AbstractAbility
    {
        [SerializeField] private Vector2 movementDirection;
        [SerializeField] private float acceleration = 0.1f;
        [SerializeField] private float maxVelocity = 1f;
        [SerializeField] private float gravityScale = 0.01f;
        
        private ShapeContainer _shapeContainer;
        
        public override void StartUsingAbility()
        {
            _shapeContainer = transform.parent.parent.GetComponent<ShapeContainer>();
            _shapeContainer.SetGravityScale(gravityScale);
            _shapeContainer.SetAcceleration( movementDirection * acceleration );
            _shapeContainer.SetMaxVelocity(maxVelocity);
        }

        public override void Deactivate() { }
    }
}