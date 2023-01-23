using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventorycanv : MonoBehaviour
{
    public GameObject invcanvas;
    public GameObject Minimapcanv;
    public GameObject Crosshaircanv;

    public bool InfStatus = false;
    public float Invcooldown = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Crosshaircanv.gameObject.SetActive(true);
        Minimapcanv.gameObject.SetActive(true);
        invcanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)& InfStatus == false)
        {
            InvOn();
            InfStatus = true;


        }

        if (Input.GetKeyDown(KeyCode.I) & InfStatus == true)
        {
            InvOff();
            InfStatus = false;
        }
    }
    public void InvOff()
    {
        Crosshaircanv.gameObject.SetActive(true);
        Minimapcanv.gameObject.SetActive(true);
        invcanvas.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void InvOn()
    {
        Crosshaircanv.gameObject.SetActive(false);
        Minimapcanv.gameObject.SetActive(false);
        invcanvas.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}


