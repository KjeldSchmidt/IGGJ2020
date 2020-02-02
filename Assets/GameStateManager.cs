using Spawning;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private Counter counter;
    [SerializeField] private Animation bulldozerAnimation;

    private int _stateId = 0;
    void Update()
    {
        switch (_stateId)
        {
            case 0:
                ShovelCorpses();
                break;
            case 1:
                //ToDo Display GrimReaper at Top
                //ToDo Destroy corpses
                //ToDo Drop Cloud Shapes & Abilities
                break;
            case 2:
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
}
