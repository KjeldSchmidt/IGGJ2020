using Interaction.Containers;
using UnityEngine;

namespace Abilities
{
    public class SawAbility : AbstractAbility
    {
        [SerializeField] private Animation sawAnimation = default;
        
        private ShapeContainer _shapeContainer;
        private bool _isActive;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_isActive) return;
            GrimReaper grimReaper = other.GetComponent<GrimReaper>();
            if (!grimReaper) return;
            Debug.Log("Grim");

            _isActive = false;
            grimReaper.InflictDamage();
        }

        public override void StartUsingAbility()
        {
            _isActive = true;
            sawAnimation.Play();
        }

        public override void Deactivate() { }
    }
}