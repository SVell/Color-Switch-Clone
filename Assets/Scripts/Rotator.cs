using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ColorSwitch.Obstacle
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private float maxSpeed = 100f;
        [SerializeField] private float minSpeed = 100f;

        private float speed;

        private void Start()
        {
            speed = Random.Range(minSpeed, maxSpeed);
            int dir = Random.Range(0, 2);

            if (dir == 0)
            {
                speed *= -1;
            }
        }

        private void Update()
        {
            transform.Rotate(0f, 0f, speed * Time.deltaTime);
        }
    }
}
