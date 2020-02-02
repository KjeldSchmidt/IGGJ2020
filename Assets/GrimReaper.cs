using System;
using UnityEngine;

public class GrimReaper : MonoBehaviour
{
    [SerializeField] private Animation hpAnimation1 = default;
    [SerializeField] private Animation hpAnimation2 = default;
    [SerializeField] private Level1Controller level1Controller = default;
    [SerializeField] private Level2Controller level2Controller = default;
    
    private int _hp = 2;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void InflictDamage()
    {
        _hp -= 1;
        if (_hp == 1)
        {
            hpAnimation1.Play();
            level1Controller.FinishLevel();
        }
        if (_hp == 0)
        {
            hpAnimation2.Play();
            _rigidbody2D.constraints = RigidbodyConstraints2D.None;
            _rigidbody2D.AddForce(new Vector2(20, 2));
            level2Controller.FinishLevel();
        }
    }
}
