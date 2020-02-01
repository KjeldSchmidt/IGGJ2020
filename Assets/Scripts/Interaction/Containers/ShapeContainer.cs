using System;
using UnityEngine;

namespace Interaction.Containers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ShapeContainer: MonoBehaviour, IShapeContainer
    {
        public Transform Transform => transform;
        private StartButton _startButton;

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
            GetComponent<Rigidbody2D>().AddForce(transform.up*0.2f);
        }
    }
}