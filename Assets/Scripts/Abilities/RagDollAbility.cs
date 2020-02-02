using System.Collections;
using UnityEngine;

namespace Abilities
{
    public class RagDollAbility : AbstractAbility
    {

        [SerializeField] private GameObject ragDollPrefab = default;
        [SerializeField] private Vector2 shootForce = default;
        [SerializeField] private float shootCooldown = default;
        [SerializeField] private Transform spawnPosition = default;
        
        private bool _isActive;

        IEnumerator StartRagDollCanon()
        {
            while (_isActive) {
                yield return new WaitForSeconds(shootCooldown);
                ShootRagDoll();
             //   shootCooldown = shootCooldown * 0.8f;
            }
        }

        private void ShootRagDoll()
        {
            GameObject ragDoll = Instantiate(ragDollPrefab, spawnPosition);
            ragDoll.transform.parent = null;

            foreach (Rigidbody2D rb in ragDoll.GetComponentsInChildren<Rigidbody2D>())
            {
                float xForce = shootForce.x;
                float yForce = Random.Range(-2, 2);
                rb.AddForce(new Vector2(xForce, yForce), ForceMode2D.Impulse);
                shootForce *= 0.9f;
            }
        }

        public override void StartUsingAbility()
        {
            _isActive = true;
            StartCoroutine (StartRagDollCanon ());
        }

        public override void Deactivate()
        {
            _isActive = false;
        }
    }
}