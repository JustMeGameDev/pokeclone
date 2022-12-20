using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invertory : MonoBehaviour
{

    //string[] TeamMate = {"teammate 1","teammate 2","teammate 3","teamate 4","teammate 5","teammate 6"};

    // The inventory is represented as an array of items
    public GameObject[] ItemArray;

    // The maximum number of items that can be held in the inventory
    public int maxItems = 10;

    void Start()
    {
        // Initialize the array of items with the maximum number of items
        ItemArray = new GameObject[maxItems];
    }

    // Adds an item to the inventory
    public void AddItem(GameObject itemToAdd)
    {
        for (int i = 0; i < ItemArray.Length; i++)
        {
            if (ItemArray[i] == null)
            {
                // If there is an empty slot in the inventory, add the item
                ItemArray[i] = itemToAdd;
                return;
            }
        }
    }

    // Removes an item from the inventory
    public void RemoveItem(GameObject itemToRemove)
    {
        for (int i = 0; i < ItemArray.Length; i++)
        {
            if (ItemArray[i] == itemToRemove)
            {
                // If the item is in the inventory, remove it
                ItemArray[i] = null;
                return;
            }
        }
    }
}

   





