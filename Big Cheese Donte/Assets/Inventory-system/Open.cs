using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using UnityEngine.Events;



public class Open : MonoBehaviour
{
    public KeyCode PushOpen;
    public bool IsOpen;
    public UnityEvent open;
    public UnityEvent close;


    private void FixedUpdate()
    {
        if (Input.GetKeyDown(PushOpen) && !IsOpen)
        {
            open.Invoke();
            IsOpen = true;
            muisstate();


        }
        else if (Input.GetKeyDown(PushOpen) && IsOpen)
        {
            close.Invoke();
            IsOpen = false;
            muisstate();
        }

    }
    public void muisstate()
    {
        if (IsOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (!IsOpen)
        {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        }
    }



}
