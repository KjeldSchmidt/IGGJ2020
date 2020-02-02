using System;
using System.Collections;
using Spawning;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Bombs
{
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Bomb: MonoBehaviour
    {
        [SerializeField] private float timeToExplode = default;
        [SerializeField] private float timeExploding = default;
        [SerializeField] private float explosionScale = default;
        private AudioSource _explosionSounds;

        private SpriteRenderer _spriteRenderer;
        void Start ()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            StartCoroutine (StartBombTimer ());

            timeToExplode = Random.Range(timeExploding - 1, timeToExplode + 2);
            _explosionSounds = gameObject.AddComponent<AudioSource>();
            _explosionSounds.clip = Resources.Load("SoundEffects/Explosion/Explosion") as AudioClip;
        }

        private bool exploding;
        IEnumerator StartBombTimer()
        {
            while (true) {
                yield return new WaitForSeconds(timeToExplode);
                Explode();
                _spriteRenderer.enabled = false;
                yield return new WaitForSeconds(timeExploding);
                Destroy(gameObject);
                break;
            }
        }

        private void Explode()
        {    
            transform.localScale = new Vector3(explosionScale,explosionScale, 1);
            exploding = true;
            _spriteRenderer.enabled = false;
            _explosionSounds.Play();
        }
        
        void OnCollisionEnter2D( Collision2D other)
        {
            if (!exploding) return;
            
            Limb limb = other.gameObject.GetComponent<Limb>();
            if (!limb) return;

            float scale = Random.Range(-2, 2);
            Vector2 force = new Vector2(1.5f*scale, 3);
            other.rigidbody.AddForce(force, ForceMode2D.Impulse);
        }
        
    }
}