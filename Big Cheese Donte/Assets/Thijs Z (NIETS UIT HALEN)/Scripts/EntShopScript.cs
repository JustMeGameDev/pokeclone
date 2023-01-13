using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntShopScript : MonoBehaviour
{
    public GameObject ShopCanvas;
    public GameObject ShopCam;
    public GameObject PlayerCam; 

    void Start()
    {
        ShopCanvas.gameObject.SetActive(false);
        ShopCam.gameObject.SetActive(false);
        PlayerCam.gameObject.SetActive(true); //Odd
    }


    void Update()
    {
        
    }
    public void ShopCanvasOn()
    {
        PlayerCam.gameObject.SetActive(false);//Odd
       
        ShopCanvas.gameObject.SetActive(true);
        ShopCam.gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ShopCanvasOff()
    {
        PlayerCam.gameObject.SetActive(true);//Odd
        ShopCanvas.gameObject.SetActive(false);
        ShopCam.gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

}
