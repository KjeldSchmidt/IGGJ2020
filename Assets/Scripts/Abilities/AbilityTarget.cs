using System;
using UnityEngine;

namespace Abilities
{
    public class AbilityTarget : MonoBehaviour
    {
        private StartButton _startButton;
        public int maxAbilities = 1;
        private int remainingAbilities;

        public void Start()
        {
            remainingAbilities = maxAbilities;
        }

        public bool AssignAbility( GameObject abilityPrefab )
        { 
            if (remainingAbilities == 0) return false;
            Instantiate( abilityPrefab, transform );
            remainingAbilities--;
            return true;
        }
    }
}