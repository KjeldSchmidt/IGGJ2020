using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawning
{
    public class RagDollSpawner: MonoBehaviour
    {
        [SerializeField] private GameObject ragDollPrefab = default;
        [SerializeField] private int ragDollCount = default;
        [SerializeField] private Vector2 rectangleOrigin = default;
        [SerializeField] private Vector2 rectangleFinish = default;
        [SerializeField] private Vector2 scaleRange = default;
        [SerializeField] private Counter counter = default;
        
        public void SpawnRagDolls()
        {
            for (int i = 0; i < ragDollCount; i++)
            {
                Vector2 targetPos = new Vector2(
                    Random.Range(rectangleOrigin.x, rectangleFinish.x),  
                    Random.Range(rectangleOrigin.y, rectangleFinish.y)
                );
                float scale = Random.Range(scaleRange.x, scaleRange.y);
                Vector2 targetScale = new Vector2(scale, scale);
                
                
                GameObject ragDoll = Instantiate(ragDollPrefab);
                ragDoll.GetComponent<RagDoll>().SetCounter(counter);
                ragDoll.transform.position = targetPos;
                ragDoll.transform.localScale = targetScale;
                ragDoll.transform.Rotate(0,0, Random.Range(0, 360));
            }
        }
    }
}