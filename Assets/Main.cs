using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    int currentSceneIndex;
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
   public void PlayGame()
   {
        SceneManager.LoadScene(currentSceneIndex + 1);
   }

   public void QuitGame()
   {
    Application.Quit();
   }
   public void RestartGame()
   {
        SceneManager.LoadScene(0);
   }
}
