using System;
using UnityEngine;

namespace ColorSwitch.Score 
{
    public class StarCollision : MonoBehaviour
    {
        public static event Action updateScore;

        [SerializeField] private AudioSource audio;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Star"))
            {
                updateScore?.Invoke();
                audio.Play();
                Destroy(other.gameObject);
            }
        }
    }
}
