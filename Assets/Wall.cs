using UnityEngine;

public class Wall : MonoBehaviour
{
    private bool _isActive = true;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!_isActive) return;
        
        GrimReaper grimReaper = other.gameObject.GetComponent<GrimReaper>();
        if (!grimReaper) return;

        _isActive = false;
        grimReaper.InflictDamage();
    }
}
