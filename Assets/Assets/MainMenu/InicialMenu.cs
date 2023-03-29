using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicialMenu : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void HighScores()
    {
        SceneManager.LoadScene("HighScores");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Exit()
    {
       
        Application.Quit();
    
    }
   
}
