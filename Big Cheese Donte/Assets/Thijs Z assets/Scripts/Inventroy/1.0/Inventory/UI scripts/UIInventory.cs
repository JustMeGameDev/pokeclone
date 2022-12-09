using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public GameObject InventoryCanvas;
   // public bool INVYES;
    void Awake()
    {
        //INVYES = false;
        InventoryCanvas.SetActive(false);
    }
    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) ) //INVYES == true
        {

            InventoryCanvas.gameObject.SetActive(true);
           // INVYES = true;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            InventoryCanvas.gameObject.SetActive(false);
        }
        
       

      

    }


}
