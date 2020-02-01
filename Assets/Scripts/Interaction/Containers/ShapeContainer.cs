using UnityEngine;

namespace Interaction.Containers
{
    public class ShapeContainer: MonoBehaviour, IShapeContainer
    {
        public void Destroy()
        {
            Debug.Log(gameObject.name);
            Debug.Log(transform);
            Destroy(gameObject);
        }
    }
}