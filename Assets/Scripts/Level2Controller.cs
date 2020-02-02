using Interaction;
using Spawning;
using UnityEngine;

public class Level2Controller : MonoBehaviour
{
    [SerializeField] private CursorController cursorController = default;
    [SerializeField] private GameObject reaperMover = default;
    [SerializeField] private Animation moveReaperToRight = default;
    [SerializeField] private GameObject level2ShapesContainer = default;
    [SerializeField] private GameObject level2AbilitiesContainer = default;
    [SerializeField] private Animation raiseWallAnimation = default;
    [SerializeField] private Animation moveRightScreenBlockAnimation = default;
    
    private GameStateManager _gameStateManager;
    
    // Start is called before the first frame update
    public void StartLevel(GameStateManager gameStateManager)
    {
        _gameStateManager = gameStateManager;
        
        //Move Reaper to Top
        reaperMover.SetActive(true);
        moveRightScreenBlockAnimation.Play("MoveInBlockRightScreen");
        cursorController.maxCursorPosition = new Vector2(10, 20);
        moveReaperToRight.Play("MoveReaperRight");
        DropLevelShapes();
        raiseWallAnimation.Play();
    }

    private void DropLevelShapes()
    {
        level2ShapesContainer.SetActive(true);
        level2AbilitiesContainer.SetActive(true);
    }
    
    public void FinishLevel()
    {
        moveRightScreenBlockAnimation.Play("MoveOutBlockRightScreen");
        _gameStateManager.FinishLevel2();
    }
}
