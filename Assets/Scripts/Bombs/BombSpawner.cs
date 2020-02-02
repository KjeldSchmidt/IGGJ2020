using UnityEngine;

namespace Bombs
{
    public class BombSpawner : MonoBehaviour
    {
        [SerializeField] private Transform spawnPosition = default;
        [SerializeField] private GameObject bombPrefab = default;

        public void SpawnBomb()
        {
            GameObject bomb = Instantiate(bombPrefab);
            bomb.transform.position = spawnPosition.position;
            bomb.transform.parent = null;
        }

        public void DestroyTractor()
        {
            Destroy(gameObject);
        }
        
    }
}
