using System.Collections.Generic;
using Interaction.Snapping;
using UnityEngine;

namespace Interaction.Dragging
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Draggable: MonoBehaviour, IDraggable
    {
        private SpriteRenderer _spriteRenderer;
        private Color _baseColor;
        

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _baseColor = _spriteRenderer.color;
        }

        public void Highlight()
        {
            _spriteRenderer.color = Color.black;
        }

        public void UnHighlight()
        {
            _spriteRenderer.color = _baseColor;
        }

        public void UpdatePosition(Vector2 pos)
        {
            transform.position = pos;
        }
    }
}