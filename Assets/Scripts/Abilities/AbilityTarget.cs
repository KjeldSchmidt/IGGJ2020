using System;
using UnityEngine;

namespace Abilities
{
    public class AbilityTarget : MonoBehaviour
    {
        private StartButton _startButton;

        private void Awake()
        {
            _startButton = GameObject.Find("StartButton").GetComponent<StartButton>();
        }

        public void OnMouseDown()
        {
            Debug.Log("Target clicked!");
            var source = _startButton.GetActiveAbilitySource();
            if (source != null)
            {
                Instantiate(
                    _startButton.GetActiveAbilitySource().abilityPrefab,
                    this.transform
                );   
            }
        }
    }
}