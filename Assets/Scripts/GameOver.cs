using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ColorSwitch.Manager 
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverScreen;
        [SerializeField] private AudioSource _dieAudio;
        public void RestartLevel()
        {
            _dieAudio.Play();
            Time.timeScale = 0;
            _gameOverScreen.SetActive(true);
        }

        
    }
}

