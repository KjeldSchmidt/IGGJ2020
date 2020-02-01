﻿using System;
using UnityEngine;

namespace Abilities
{
    public class MoveSideways : AbstractAbilty, IAbility
    {
        private bool _active;
        private Transform _blockCollection;
        private Vector3 _movementDirection = Vector3.right;
        private float speed = 0.2f;
        
        public override void StartUsingAbility()
        {
            _blockCollection = transform.parent.parent;
            _active = true;
        }

        public override void Deactivate()
        {
            _active = false;
        }

        public void Update()
        {
            if (_active)
            {
                _blockCollection.position += _movementDirection * (Time.deltaTime * speed);   
            }
        }
    }
   
}