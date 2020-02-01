using System;
using System.Linq;
using Abilities;
using UnityEngine;

namespace Interaction.Containers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ShapeContainer: MonoBehaviour, IShapeContainer
    {
        public Transform Transform => transform;
        private StartButton _startButton;
        private bool _sufficientPower;

        public void Start()
        {
            _startButton = GameObject.Find("StartButton").GetComponent<StartButton>();
            _startButton.RegisterShapeContainer(this);
        }

        public void Destroy()
        {
            _startButton.UnregisterShapeContainer(this);
            Destroy(gameObject);
        }

        public void StartLevel()
        {
            if (!_sufficientPower)
            {
                // Show flashing electriccity symbols or something, idc
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(transform.up*10f);
            }
        }

        public void PrepareStart()
        {
            int powerNeeded = 0;
            AbilityTarget[] targets = GetComponentsInChildren<AbilityTarget>();
            foreach (var target in targets)
            {
                powerNeeded++;
            }
            ElectricityAbility[] powerSources = GetComponentsInChildren<ElectricityAbility>();

            _sufficientPower = powerSources.Length >= powerNeeded;
        }
    }
}