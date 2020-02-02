using Interaction.Snapping;
using UnityEngine;

public class SafetyFloor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        ISnapable snapable = other.GetComponent<ISnapable>();
        if (snapable == null) return;
        
        foreach (var snapable2 in snapable.GetBlockContainerTransform().GetComponentsInChildren<ISnapable>())
        {
            snapable2.SetIsTrigger(false);
        }
    }
}
