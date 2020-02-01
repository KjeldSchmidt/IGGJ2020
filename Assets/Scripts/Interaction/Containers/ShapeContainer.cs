using UnityEngine;

namespace Interaction.Containers
{
    public class ShapeContainer: MonoBehaviour, IShapeContainer
    {
        public Transform Transform => transform;

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}