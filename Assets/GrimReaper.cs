using UnityEngine;

public class GrimReaper : MonoBehaviour
{
    [SerializeField] private Animation hpAnimation1 = default;
    [SerializeField] private Animation hpAnimation2 = default;
    [SerializeField] private Level1Controller level1Controller = default;
    [SerializeField] private Level2Controller level2Controller = default;
    private int _hp = 2;

    public void InflictDamage()
    {
        _hp -= 1;
        if (_hp == 1)
        {
            hpAnimation1.Play();
            level1Controller.FinishLevel();
        }
        if (_hp == 2)
        {
            hpAnimation2.Play();
            level2Controller.FinishLevel();
        }
    }
}
