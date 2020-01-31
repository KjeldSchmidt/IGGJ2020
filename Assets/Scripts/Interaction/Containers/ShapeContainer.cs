using UnityEngine;

namespace Interaction.Containers
{
    public class ShapeContainer: MonoBehaviour, IShapeContainer
    {
        public void Destroy()
        {
            Destroy(this);
        }
    }
}