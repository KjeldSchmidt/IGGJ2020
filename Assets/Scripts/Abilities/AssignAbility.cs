using System;
using UnityEngine;

namespace Abilities
{
    public class AssignAbility
    {
        public static void AssignAbilityRaycast( Camera camera, Vector3 mousePos )
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity, ~(1 << 9));

            if (!hit) return;
            AbilityTarget target = hit.collider.gameObject.GetComponent<AbilityTarget>();
            
            if (target == null) return;
            
            var startButton = GameObject.Find("StartButton").GetComponent<StartButton>();
            var source = startButton.GetActiveAbilitySource()?.abilityPrefab;
            
            if (source == null) return;
            
            target.AssignAbility( source );
        }
    }
}