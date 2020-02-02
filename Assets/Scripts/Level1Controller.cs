using Interaction;
using Spawning;
using UnityEngine;
using UnityEngine.Serialization;

public class Level1Controller : MonoBehaviour
{
    [SerializeField] private CursorController cursorController = default;
    [SerializeField] private Animation hideStartButtonAnimation = default;
    [SerializeField] private GameObject reaperMover = default;
    [SerializeField] private Animation moveReaperToTop = default;
    [SerializeField] private GameObject level1ShapesContainer = default;
    [SerializeField] private GameObject level1AbilitiesContainer = default;
    [SerializeField] private Animation moveBlockUpperScreenAnimation = default;
    
    private GameStateManager _gameStateManager;
    
    // Start is called before the first frame update
    public void StartLevel(GameStateManager gameStateManager)
    {
        _gameStateManager = gameStateManager;
        
        //Move Reaper to Top
        reaperMover.SetActive(true);
        moveBlockUpperScreenAnimation.Play("MoveInBlockUpperScreen");
        cursorController.maxCursorPosition = new Vector2(19, 5);
        moveReaperToTop.Play();
        hideStartButtonAnimation.Play("HideStartButton");
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
    
    public void FinishLevel()
    {
        moveBlockUpperScreenAnimation.Play("MoveOutBlockUpperScreen");
        _gameStateManager.FinishLevel1();
    }
}
