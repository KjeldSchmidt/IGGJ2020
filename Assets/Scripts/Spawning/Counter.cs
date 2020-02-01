using UnityEngine;

namespace Spawning
{
    public class Counter: MonoBehaviour
    {
        [SerializeField] private TextMesh textMeshCounter;
        private int _count = 0;

        public void IncreaseCounter()
        {
            if (_count >= 100) return;
            
            _count++;
            int displayCount = (_count * 2);
            if (displayCount > 100) displayCount = 100;
            textMeshCounter.text = displayCount.ToString();
        }
    }
}