using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pauze : MonoBehaviour
{
    public GameObject menu;
    public bool on = false;
    private void Awake()
    {
        menu = GameObject.FindGameObjectWithTag("pauze");
        
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && on ==true)
        {
            canvansON(false);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && on != true)
        {
            canvansON(true);
        }
    }

    public bool canvansON(bool b)
    {
        menu.SetActive(b);
        Cursor.visible = b;
        on = b;
        if (b)
        {  
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;        
        }
        else if(!b)
        {           
            Time.timeScale = default;
            Cursor.lockState = CursorLockMode.Locked;     
        }
        return b;
    }

}
