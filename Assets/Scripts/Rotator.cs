using System;
using UnityEngine;

namespace ColorSwitch.Obstacle
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private float speed = 100f;

        private void Update()
        {
            transform.Rotate(0f, 0f, speed * Time.deltaTime);
        }
    }
}
