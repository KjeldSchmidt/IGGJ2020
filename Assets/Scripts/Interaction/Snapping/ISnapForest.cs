using System.Collections.Generic;

namespace Interaction.Snapping
{
    public interface ISnapForest
    {
        void Join(Snapable a, Snapable b);
        (List<Snapable>, List<Snapable>) Split(Snapable a, Snapable b);
    }
}