using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public GameObject InventoryCanvas;
    public bool INVYES;
    void Start()
    {
        INVYES = false;
        InventoryCanvas.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) & INVYES == true)
        {
            InventoryCanvas.gameObject.SetActive(true);
            INVYES = true;
        }

        if (Input.GetKeyDown(KeyCode.E) & INVYES == false)
        {
            InventoryCanvas.gameObject.SetActive(false);
            INVYES = false;
        }

    }


}
