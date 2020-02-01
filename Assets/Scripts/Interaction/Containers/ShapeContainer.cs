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
        private Vector2 forces;

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
                Debug.Log("Insufficient Power");
                // Show flashing electricity symbols or something, idc
            }
            else
            {
                Debug.Log("Starting container!");
                print(forces);
                GetComponent<Rigidbody2D>().AddForce( forces );
            }
        }

        public void PrepareStart()
        {
            Debug.Log("Prepare Container!");
            int powerNeeded = 0;
            AbilityTarget[] targets = GetComponentsInChildren<AbilityTarget>();
            foreach (var target in targets)
            {
                if (!target.requiresElectricity) continue;
                if (target.GetComponentsInChildren<IAbility>().Length == 0) continue;
                powerNeeded++;
            }
            ElectricityAbility[] powerSources = GetComponentsInChildren<ElectricityAbility>();

            _sufficientPower = powerSources.Length >= powerNeeded;
        }

        public void RegisterForce( Vector2 force )
        {
            Debug.Log("Register force!");
            Debug.Log(forces);
            forces += force;
            Debug.Log(forces);
        }
    }
}