using Abilities;
using UnityEngine;

namespace Interaction.Containers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ShapeContainer: MonoBehaviour, IShapeContainer
    {
        public Transform Transform => transform;
        private Vector2 _acceleration;
        private float _maxVelocity;
        private Rigidbody2D _rigidbody2D;
        
        private bool _sufficientPower;

        public void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void PrepareStart()
        {
            ElectricityAbility electricityAbility = GetComponentInChildren<ElectricityAbility>();
            if (!electricityAbility) return;
            
            foreach (IAbility ability in transform.GetComponentsInChildren<IAbility>())
            {
                ability.StartUsingAbility();
            }

            int powerNeeded = 0;
            AbilityTarget[] targets = GetComponentsInChildren<AbilityTarget>();
            foreach (var target in targets)
            {
                if (!target.requiresElectricity) continue;
                if (target.GetComponentsInChildren<IAbility>().Length == 0) continue;
                powerNeeded++;
            }
            ElectricityAbility[] powerSources = GetComponentsInChildren<ElectricityAbility>();

            _sufficientPower = powerSources.Length >= powerNeeded;
        }

        public void AddAcceleration( Vector2 force )
        {
            if (_rigidbody2D.velocity.magnitude < _maxVelocity){
                _rigidbody2D.AddForce(force);
            }
        }

        public void SetGravityScale(float val)
        {
            _rigidbody2D.gravityScale = val;
        }

        public void SetMaxVelocity(float val)
        {
            _maxVelocity = val;
        }
        
    }
}