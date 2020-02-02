﻿using System;
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
        private Vector2 _acceleration;
        private float _maxVelocity;
        private Rigidbody2D _rigidbody2D;
        private bool _started;
        
        private bool _sufficientPower;

        public void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _startButton = GameObject.Find("StartButton").GetComponent<StartButton>();
            _startButton.RegisterShapeContainer(this);
        }

        private void Update()
        {
            if (!_started) return;
            
            if (_rigidbody2D.velocity.magnitude < _maxVelocity){
                _rigidbody2D.AddForce(_acceleration);
            }
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
                return;
                // Show flashing electricity symbols or something, idc
            }
            
            _started = true;
        }

        public void PrepareStart()
        {
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

        public void SetAcceleration( Vector2 force )
        {
            this._acceleration += force;
        }

        public void SetGravityScale(float val)
        {
            _rigidbody2D.gravityScale = val;
        }

        public void SetMaxVelocity(float val)
        {
            _maxVelocity = val;
        }
        
    }
}