using UnityEngine;

namespace Spawning
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Limb: MonoBehaviour
    {
        [SerializeField] private RagDoll ragDoll;
        
        private int _detachedLimbsCount = 0;
        private bool _isDead;
        
        private void OnJointBreak2D(Joint2D brokenJoint)
        {
            if (_isDead) return;
            
            _detachedLimbsCount++;
            if (_detachedLimbsCount >= 2 || brokenJoint.name == "Head")
            {
                _isDead = true;
            }
        }

        private void Update()
        {
            if (!_isDead) return;

            if (transform.position.y <= 8)
            {
                ragDoll.SetDead();
                Destroy(this);
            }
        }
    }
}