using UnityEngine;

namespace Abilities
{
    public abstract class AbstractAbilty : MonoBehaviour, IAbility
    {
        public void Start()
        {
            GameObject.Find("StartButton").GetComponent<StartButton>().RegisterAbility( this );
        }
        
        public abstract void StartUsingAbility();
        public abstract void Deactivate();
    }
}