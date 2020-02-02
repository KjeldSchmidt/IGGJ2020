using UnityEngine;

public class Level1Controller : MonoBehaviour
{
    [SerializeField] private Animation moveReaperToTop;
    [SerializeField] private GameObject level1ShapesContainer;
    [SerializeField] private GameObject level1AbilitiesContainer;
    
    private GameStateManager _gameStateManager;
    
    // Start is called before the first frame update
    public void StartLevel(GameStateManager gameStateManager)
    {
        _gameStateManager = gameStateManager;
        
        //Move Reaper to Top
        moveReaperToTop.Play();
        DestroyRagDolls();
        DropLevelShapes();
    }

    private void DestroyRagDolls()
    {
        //todo destroy ragdolls
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
