using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("OYUN BITTI!!");
        Application.Quit();
    }




    public void PassNextLevel() {
        if (SceneManager.GetActiveScene().buildIndex == 3) { SceneManager.LoadScene(1); }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        }

    public void GoToMainMenu() {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(1);
    }



}
