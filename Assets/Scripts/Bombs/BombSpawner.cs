using UnityEngine;

namespace Bombs
{
    public class BombSpawner : MonoBehaviour
    {
        [SerializeField] private Transform spawnPosition;
        [SerializeField] private GameObject bombPrefab;

        public void SpawnBomb()
        {
            GameObject bomb = Instantiate(bombPrefab);
            bomb.transform.position = spawnPosition.position;
            bomb.transform.parent = null;
        }
    }
}
