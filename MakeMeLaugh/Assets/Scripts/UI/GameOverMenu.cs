using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
   public void Retry()
   {
        SceneManager.LoadScene(1);
   }

   public void MainMenu()
   {
        SceneManager.LoadScene(0);
    }
}
