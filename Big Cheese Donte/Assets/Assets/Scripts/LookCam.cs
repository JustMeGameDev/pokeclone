using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCam : MonoBehaviour
{
  public float sensY;
  public float sensX;

    public Transform OR;

     float xRot;
     float YRot;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        YRot += mouseX;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRot, YRot, 0);
        OR.rotation = Quaternion.Euler(0, YRot, 0);
    }

}
