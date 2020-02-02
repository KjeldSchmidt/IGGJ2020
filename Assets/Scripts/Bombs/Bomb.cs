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
        [SerializeField] private float timeToExplode;
        [SerializeField] private float timeExploding;
        [SerializeField] private float explosionScale;

        private SpriteRenderer _spriteRenderer;
        void Start ()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            StartCoroutine (StartBombTimer ());

            timeToExplode = Random.Range(timeExploding - 1, timeToExplode + 2);
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