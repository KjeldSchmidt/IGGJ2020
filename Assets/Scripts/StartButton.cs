using System;
using System.Collections;
using System.Collections.Generic;
using Abilities;
using UnityEngine;

public class StartButton : MonoBehaviour
{

    private List<IAbility> _registeredAbilities = new List<IAbility>();
    
    private void OnMouseDown()
    {
         foreach (var ability in _registeredAbilities)
         {
             ability.Activate();
         }
    }

    public void RegisterAbility(IAbility ability)
    {
        _registeredAbilities.Add(ability);
    }
}
