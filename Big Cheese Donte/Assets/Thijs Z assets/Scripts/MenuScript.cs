using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    //Edit for StartGame Mogelijk

    public void PlayGameSimple ()
    {
        SceneManager.LoadScene("New Scene");
    }

    public void PlayGame()
    {
        //Add transiton and save file loader
    }

    public void ExitGame()
    {
        print("GameHasClosed");
        Application.Quit();

    }


}
