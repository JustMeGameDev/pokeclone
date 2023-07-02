using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonMaster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void  quit()
    {
        Application.Quit();
    }
    public static void Menu()
    {
        SceneManager.LoadScene(2);
    }
    public static void Restart()
    {
        SceneManager.LoadScene("World");
    }
}
