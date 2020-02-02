using UnityEngine;

public class GrimReaper : MonoBehaviour
{
    [SerializeField] private Animation hpAnimation1;

    private int _hp = 2;

    public void InflictDamage()
    {
        _hp -= 1;
        if (_hp == 1)
        {
            hpAnimation1.Play();
        }
    }
}
