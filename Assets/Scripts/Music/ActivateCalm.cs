using UnityEngine;

namespace Music
{
    public class ActivateCalm : MonoBehaviour
    {
        private SoundCarrier _soundCarrier;

        public void Start()
        {
            _soundCarrier = GameObject.Find("SoundCarrier").GetComponent<SoundCarrier>();
        }

        private void OnMouseDown()
        {
            _soundCarrier.ActivateCalm();
        }
    }
}
