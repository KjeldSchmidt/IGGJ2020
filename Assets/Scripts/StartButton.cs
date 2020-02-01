using System;
using System.Collections;
using System.Collections.Generic;
using Abilities;
using Interaction.Containers;
using UnityEngine;

public class StartButton : MonoBehaviour
{

    private List<IAbility> _registeredAbilities = new List<IAbility>();
    private List<IShapeContainer> _registeredShapeContainers = new List<IShapeContainer>();
    private AbilitySource _activeAbilitySource;
    private bool started;
    
    private void OnMouseDown()
    { 
        if (started) return;
        started = true;
        foreach (var shapeContainer in _registeredShapeContainers)
        {
            shapeContainer.PrepareStart();
        }
        foreach (var ability in _registeredAbilities)
        {
             ability.StartUsingAbility();
        }

        foreach (var shapeContainer in _registeredShapeContainers)
        {
             shapeContainer.StartLevel();
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

    public void RegisterShapeContainer(ShapeContainer shapeContainer)
    {
        _registeredShapeContainers.Add(shapeContainer);
    }
    
    public void UnregisterShapeContainer(ShapeContainer shapeContainer)
    {
        _registeredShapeContainers.Remove(shapeContainer);
    }
}
