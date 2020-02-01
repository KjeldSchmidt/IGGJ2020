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

            if (hit)
            {
                Debug.Log(hit.transform.name);
            }
        }
    }
}