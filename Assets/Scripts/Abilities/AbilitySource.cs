using System;
using Interaction;
using UnityEngine;

namespace Abilities
{
    public class AbilitySource : MonoBehaviour, IDraggable
    {
        public GameObject abilityPrefab;
        private Vector3 _originalPosition;

        private void Start()
        {
            _originalPosition = transform.position;
        }


        public void Highlight() { }

        public void UnHighlight() { }
        public void MouseDown() { }

        public void UpdatePosition(Vector2 pos)
        {
            transform.position = pos;
        }

        public void MouseUp()
        {
            transform.position = _originalPosition;
        }
    }
}
