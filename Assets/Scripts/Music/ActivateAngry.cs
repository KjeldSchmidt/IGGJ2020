using UnityEngine;

namespace Music
{
    public class ActivateAngry : MonoBehaviour
    {
        private SoundCarrier _soundCarrier;

        public void Start()
        {
            _soundCarrier = GameObject.Find("SoundCarrier").GetComponent<SoundCarrier>();
        }

        private void OnMouseDown()
        {
            _soundCarrier.ActivateAngry();
        }
    }
}
