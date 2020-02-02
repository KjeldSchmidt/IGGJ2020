using Spawning;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Controller : MonoBehaviour
{
    [SerializeField] private GameObject startGameButton;
    [SerializeField] private GameObject reaperMover;
    [SerializeField] private Animation moveReaperToTop;
    [SerializeField] private GameObject level1ShapesContainer;
    [SerializeField] private GameObject level1AbilitiesContainer;
    
    private GameStateManager _gameStateManager;
    
    // Start is called before the first frame update
    public void StartLevel(GameStateManager gameStateManager)
    {
        _gameStateManager = gameStateManager;
        
        //Move Reaper to Top
        reaperMover.SetActive(true);
        moveReaperToTop.Play();
        Destroy(startGameButton);
        DestroyRagDolls();
        DropLevelShapes();
    }

    private void DestroyRagDolls()
    {
        foreach (GameObject go in gameObject.scene.GetRootGameObjects())
        {
            RagDoll ragDoll = go.GetComponent<RagDoll>();
            if (!ragDoll) continue;
            
            Destroy(ragDoll.gameObject);
        }
    }

    private void DropLevelShapes()
    {
        level1ShapesContainer.SetActive(true);
        level1AbilitiesContainer.SetActive(true);
    }
    
    private void FinishLevel()
    {
        _gameStateManager.FinishLevel1();
    }
}
