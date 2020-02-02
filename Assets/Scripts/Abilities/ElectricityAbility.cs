using System.Collections.Generic;
using Interaction.Containers;

namespace Abilities
{
    public class ElectricityAbility : AbstractAbility
    {
        private bool _active;
        private ShapeContainer _shapeContainer;
        private float speed = 0.2f;
        private bool started;
        
        private List<IAbility> _registeredAbilities = new List<IAbility>();
        private List<IShapeContainer> _registeredShapeContainers = new List<IShapeContainer>();

       public void StartAbilities()
        {
        }
        
        public override void StartUsingAbility()
        {
        }

        public override void Deactivate()
        {
        }


    }
}