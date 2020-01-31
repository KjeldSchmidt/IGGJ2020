using Interaction.Dragging;

namespace Interaction.Snapping
{
    public interface ISnappingController
    {
        void TrySnapDraggable(IDraggable draggable);
    }
}