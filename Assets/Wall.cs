using UnityEngine;

public class Wall : MonoBehaviour
{
    private bool _isActive = true;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (!_isActive) return;
        
        GrimReaper grimReaper = other.GetComponent<GrimReaper>();
        if (!grimReaper) return;

        _isActive = false;
        grimReaper.InflictDamage();
    }
}
