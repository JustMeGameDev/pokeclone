using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class inventoryitem
{
    public Inventorydata itemdata;
    public int stackSize;

    public inventoryitem(Inventorydata item)
    {
        itemdata = item;
        AddToStack();
    }
    public void AddToStack()
    {
        stackSize++;
    }
    public void RemoveToStack()
    {
        stackSize--;
    }
}