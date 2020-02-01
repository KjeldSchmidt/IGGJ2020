using System;
using System.Collections.Generic;
using Interaction;
using Interaction.Dragging;
using Interaction.Snapping;
using UnityEngine;

namespace Abilities
{
    public class AbilitySource : MonoBehaviour
    {
        public GameObject abilityPrefab;
        private StartButton _startButton;

        private void Awake()
        {
            _startButton = GameObject.Find("StartButton").GetComponent<StartButton>();
        }

        public void OnMouseDown()
        {
            transform.localScale = Vector3.one * 1.2f;
            _startButton.ActivateAbilitySource( this ); // If this ability is already activated, activating it again will deactivate it 
        }

        public void Deactivate()
        {
            transform.localScale = Vector3.one;
        }
    }
}
