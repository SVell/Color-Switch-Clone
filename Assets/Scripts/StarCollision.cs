using System;
using UnityEngine;

namespace ColorSwitch.Score 
{
    public class StarCollision : MonoBehaviour
    {
        public static event Action updateScore;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Star"))
            {
                updateScore?.Invoke();
                Destroy(other.gameObject);
            }
        }
    }
}
