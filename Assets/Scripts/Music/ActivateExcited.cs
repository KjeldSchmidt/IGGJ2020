using UnityEngine;

namespace Music
{
    public class ActivateExcited : MonoBehaviour
    {
        private SoundCarrier _soundCarrier;

        public void Start()
        {
            _soundCarrier = GameObject.Find("SoundCarrier").GetComponent<SoundCarrier>();
        }

        private void OnMouseDown()
        {
            _soundCarrier.ActivateExcited();
        }
    }
}
