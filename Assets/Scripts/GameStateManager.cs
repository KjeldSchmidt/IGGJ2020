using Spawning;
using UnityEngine;
using UnityEngine.Serialization;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private Counter counter = default;
    [SerializeField] private GameObject bullDozer = default;
    [SerializeField] private Animation bulldozerAnimation = default;
    [SerializeField] private Level1Controller level1Controller = default;
    [SerializeField] private Level2Controller level2Controller = default;
    [SerializeField] private Animation mainCameraAnimation = default;
    
    private int _stateId = 0;
    
    void Update()
    {
        switch (_stateId)
        {
            case 0:
                ShovelCorpses();
                break;
            case 1:
                StartLevel1();
                break;
            case 2:
                break;
            case 3:
                StartLevel2();
                break;
            case 4:
                break;
            case 5:
                break;
            default:
                break;
        }
    }

    private void ShovelCorpses()
    {
        if (counter.GetCount() < 100) return;
        bulldozerAnimation.Play();
        _stateId++;
    }
    
    public void StartLevel1()
    {
        if (bullDozer&& bulldozerAnimation.isPlaying) return;
        
        level1Controller.StartLevel(this);
        _stateId++;
    }

    public void FinishLevel1()
    {
        _stateId++;
    }
    
    public void StartLevel2()
    {
        level2Controller.StartLevel(this);
        _stateId++;
    }

    public void FinishLevel2()
    {
        mainCameraAnimation.Play();
    }
}
