﻿using UnityEngine;

namespace Spawning
{
    public class Counter: MonoBehaviour
    {
        [SerializeField] private TextMesh textMeshCounter;
        private int _count = 0;

        public void IncreaseCounter()
        {
            if (_count >= 100) return;

            _count += 2;
            if (_count > 100) _count = 100;
            textMeshCounter.text = _count.ToString();
        }
        
        public int GetCount()
        {
            return _count;
        }
    }
}