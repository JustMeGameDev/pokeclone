using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    //Edit for StartGame Mogelijk
    public void Main()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void settings ()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("world");
    }

    public void ExitGame()
    {
        print("GameHasClosed");
        Application.Quit();

    }


}
