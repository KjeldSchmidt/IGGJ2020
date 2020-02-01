using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawning
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Limb: MonoBehaviour
    {
        [SerializeField] private RagDoll ragDoll;
        
        private int _detachedLimbsCount = 0;
        private bool _isDead;

       // void Start () {
       //     StartCoroutine (WaitToDie ());
       // }
     
        //IEnumerator WaitToDie()
        //{
        //    while (true)
        //    {Debug.Log("wait");
        //        int time = Random.Range(0, 30);
        //        Debug.Log(time);
        //        yield return new WaitForSeconds(time);
        //        Debug.Log("set dead");
        //        ragDoll.SetDead();
        //        break;
        //    }
        //}

        private void OnJointBreak2D(Joint2D brokenJoint)
        {
            Debug.Log(brokenJoint.name);
            Debug.Log("Joint break");
            if (_isDead) return;
            
            _detachedLimbsCount++;
            if (_detachedLimbsCount >= 2 || brokenJoint.name == "Head")
            {
                _isDead = true;
              //  ragDoll.SetDead();
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