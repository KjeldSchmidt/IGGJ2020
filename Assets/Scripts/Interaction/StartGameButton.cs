using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class StartGameButton: MonoBehaviour
    {
        [SerializeField] private List<SpriteRenderer> spriteRenderers;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<CursorController>() == null) return;
            
            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                spriteRenderer.color = Color.white;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<CursorController>() == null) return;
            
            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                spriteRenderer.color = Color.black;
            }
        }
    }
}