using System;
using UnityEngine;

namespace Music
{
    public class SoundCarrier : MonoBehaviour
    {
        // Start is called before the first frame update
        private AudioSource _calmCarrier;
        private AudioSource _excitedCarrier;
        private AudioSource _angryCarrier;
        public AudioSource currentSoundtrack;
        public float fadeSpeed = 1.0f;
        void Start()
        {
            _calmCarrier = transform.GetChild(0).gameObject.GetComponent<AudioSource>();
            _excitedCarrier = transform.GetChild(1).gameObject.GetComponent<AudioSource>();
            _angryCarrier = transform.GetChild(2).gameObject.GetComponent<AudioSource>();
        }

        private void Update()
        {
            float maxChange = Time.deltaTime * fadeSpeed / 3;
            float actualChange = 0.0f;

            actualChange += Math.Min(maxChange, _calmCarrier.volume);
            actualChange += Math.Min(maxChange, _excitedCarrier.volume);
            actualChange += Math.Min(maxChange, _angryCarrier.volume);

            _calmCarrier.volume = Math.Max(0, _calmCarrier.volume - maxChange);
            _excitedCarrier.volume = Math.Max(0, _excitedCarrier.volume - maxChange);
            _angryCarrier.volume = Math.Max(0, _angryCarrier.volume - maxChange);

            currentSoundtrack.volume += actualChange;
        }

        public void ActivateCalm()
        {
            currentSoundtrack = _calmCarrier;
        }
    
        public void ActivateExcited()
        {
            currentSoundtrack = _excitedCarrier;
        }
    
        public void ActivateAngry()
        {
            currentSoundtrack = _angryCarrier;
        }
    }
}
