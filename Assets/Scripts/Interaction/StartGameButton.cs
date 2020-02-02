using System.Collections;
using System.Collections.Generic;
using Spawning;
using UnityEngine;

namespace Interaction
{
    public class StartGameButton: MonoBehaviour
    {
        [SerializeField] private Animation grimLeavesAnimation = default;
        [SerializeField] private Animation hideTitleAnimation = default;
        
        [SerializeField] private List<SpriteRenderer> spriteRenderers = default;
        [SerializeField] private List<TextMesh> textMeshes = default;
        [SerializeField] private Animation startAnimation = default;
        [SerializeField] private RagDollSpawner ragDollSpawner = default;
        
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

        private IEnumerator EndTitleScreen()
        {
            yield return new WaitForSeconds(2);
            startAnimation.Play();
            ragDollSpawner.SpawnRagDolls();
        }

        private void OnMouseUp()
        {
            grimLeavesAnimation.Play();
            hideTitleAnimation.Play();
            StartCoroutine(EndTitleScreen());
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

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}