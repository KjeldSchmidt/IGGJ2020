﻿using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawning
{
    public class RagDollSpawner: MonoBehaviour
    {
        [SerializeField] private GameObject ragDollPrefab;
        [SerializeField] private int ragDollCount;
        [SerializeField] private Vector2 rectangleOrigin;
        [SerializeField] private Vector2 rectangleFinish;
        [SerializeField] private Vector2 scaleRange;
        [SerializeField] private Vector2 startVelocityRange;

        private void Awake()
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
                ragDoll.transform.position = targetPos;
                ragDoll.transform.localScale = targetScale;
                ragDoll.transform.Rotate(0,0, Random.Range(0, 360));
            }
        }
    }
}