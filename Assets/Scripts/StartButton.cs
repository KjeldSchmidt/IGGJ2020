using System;
using System.Collections;
using System.Collections.Generic;
using Abilities;
using UnityEngine;

public class StartButton : MonoBehaviour
{

    private List<IAbility> _registeredAbilities = new List<IAbility>();
    private AbilitySource _activeAbilitySource;
    
    private void OnMouseDown()
    {
         foreach (var ability in _registeredAbilities)
         {
             ability.StartUsingAbility();
         }
    }

    public void RegisterAbility(IAbility ability)
    {
        _registeredAbilities.Add(ability);
    }

    public void ActivateAbilitySource( AbilitySource abilitySource )
    {
        if ( _activeAbilitySource != null ) _activeAbilitySource.Deactivate();
        if (_activeAbilitySource == abilitySource)
        {
            abilitySource.Deactivate();
        }
        else
        {
            _activeAbilitySource = abilitySource;   
        }
    }

    public AbilitySource GetActiveAbilitySource()
    {
        return _activeAbilitySource;
    }
}
