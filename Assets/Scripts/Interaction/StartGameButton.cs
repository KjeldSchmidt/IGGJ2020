using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Interaction
{
    public class StartGameButton: MonoBehaviour
    {
        [SerializeField] private List<SpriteRenderer> spriteRenderers;
        [SerializeField] private List<TextMesh> textMeshes;
        [SerializeField] private Animation startAnimation;
        
        private void OnTriggerEnter2D(Collider2D other)
        {

            if (other.GetComponent<CursorController>() == null) return;
            
            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                Color targetColor = Color.black;
                if (spriteRenderer.color == targetColor) targetColor = Color.white;
                spriteRenderer.color = targetColor;
            }
            foreach (TextMesh textMesh in textMeshes)
            {
                Color targetColor = Color.black;
                if (textMesh.color == targetColor) targetColor = Color.white;
                textMesh.color = targetColor;
            }
        }

        private void OnMouseUp()
        {
            
            startAnimation.Play();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<CursorController>() == null) return;
            
            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                Color targetColor = Color.black;
                if (spriteRenderer.color == targetColor) targetColor = Color.white;
                spriteRenderer.color = targetColor;
            }
            foreach (TextMesh textMesh in textMeshes)
            {
                Color targetColor = Color.black;
                if (textMesh.color == targetColor) targetColor = Color.white;
                textMesh.color = targetColor;
            }
        }
    }
}