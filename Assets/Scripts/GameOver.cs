using UnityEngine;
using UnityEngine.SceneManagement;

namespace ColorSwitch.Manager 
{
    public class GameOver : MonoBehaviour
    {
        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

