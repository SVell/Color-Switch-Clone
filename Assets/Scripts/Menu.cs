using UnityEngine;
using UnityEngine.SceneManagement;

namespace ColorSwitch.UI
{
   public class Menu : MonoBehaviour
   {
      public void PauseGame()
      {
         Time.timeScale = 0;
      }

      public void ResumeGame()
      {
         Time.timeScale = 1;
      }

      public void LoadLevel(int index)
      {
         Time.timeScale = 1;
         SceneManager.LoadScene(index);
      }
   }
}
