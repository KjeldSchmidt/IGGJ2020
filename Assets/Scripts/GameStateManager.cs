using Spawning;
using UnityEngine;
using UnityEngine.Serialization;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private Counter counter;
    [SerializeField] private GameObject bullDozer;
    [SerializeField] private Animation bulldozerAnimation;
    [SerializeField] private Level1Controller level1Controller;
    
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
                FinishLevel1();
                //ToDo Damage GrimReaper & move him behind wall
                //ToDo Throw in Tractor parts to demolish wall
                break;
            case 3:
                //ToDo Damage GrimReaper & make him leave
                //ToDo Show Credits
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
        return; //ToDo
        _stateId++;
    }
}
