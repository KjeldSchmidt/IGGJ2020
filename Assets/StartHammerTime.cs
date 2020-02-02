using UnityEngine;

public class StartHammerTime : MonoBehaviour
{
    [SerializeField] private Animation hammertimeAnimation = default;

    public void StartAnimation()
    {
        hammertimeAnimation.Play();
    }
}
