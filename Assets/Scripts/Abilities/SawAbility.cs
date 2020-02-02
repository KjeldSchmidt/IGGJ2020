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

            _isActive = false;
            transform.parent.parent.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5, 2));
            grimReaper.InflictDamage();
        }

        public override void StartUsingAbility()
        {
            AudioSource audio = gameObject.AddComponent<AudioSource>();
            audio.clip = Resources.Load("SoundEffects/Chainsaw/Saw") as AudioClip;
            audio.Play();
            _isActive = true;
            sawAnimation.Play();
        }

        public override void Deactivate() { }
    }
}