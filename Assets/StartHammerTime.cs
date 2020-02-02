using UnityEngine;

public class StartHammerTime : MonoBehaviour
{
    [SerializeField] private Animation hammertimeAnimation;

    public void StartAnimation()
    {
        hammertimeAnimation.Play();
    }
}
