using System;
using System.Collections.Generic;
using Interaction;
using Interaction.Dragging;
using Interaction.Snapping;
using UnityEngine;

namespace Abilities
{
    public class AbilitySource : MonoBehaviour, IAbilitySource
    {
        public GameObject abilityPrefab;
        private StartButton _startButton;
        private AbilityTarget _abilityTarget;
        
        public Transform Transform => transform;

        private void Awake()
        {
            _startButton = GameObject.Find("StartButton").GetComponent<StartButton>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            AbilityTarget abilityTarget = other.GetComponent<AbilityTarget>();
            if (!abilityTarget) return;

            Debug.Log("set ability target");
            _abilityTarget = abilityTarget;
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            AbilityTarget abilityTarget = other.GetComponent<AbilityTarget>();
            if (!abilityTarget) return;

            Debug.Log("reset ability target");
            _abilityTarget = null;
        }

        public void Deactivate()
        {
        //    transform.localScale = Vector3.one;
        }

        public void Highlight()
        {
            transform.localScale = Vector3.one * 1.2f;
        }

        public void UnHighlight()
        {
            transform.localScale = Vector3.one;
        }

        public void UpdatePosition(Vector2 pos)
        {
            transform.position = pos;
        }
        
        public void TryAssignToAbilityTarget()
        {
            if (!_abilityTarget) return;
            
            Debug.Log("try assign to existing ability target");
            _abilityTarget.AssignAbility(abilityPrefab); 
            //_startButton.ActivateAbilitySource( this ); // If this ability is already activated, activating it again will deactivate it 
        }
        
    }
}
