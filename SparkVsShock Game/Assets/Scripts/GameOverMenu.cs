using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{  
    private int sceneToContinue;
    public GameObject gameOverUI;

    public void Continue()
    {  
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");
        SceneManager.LoadScene(sceneToContinue);
    }

    public void QuitGame()
    {
        Debug.Log("Qutting Game...");
        Application.Quit();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
