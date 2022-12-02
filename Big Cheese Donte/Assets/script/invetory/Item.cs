using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Item : MonoBehaviour,ICollectible
{
    public static event ItemColect OnItemCollected;
    public delegate void ItemColect(Inventorydata itemdata);
    public Inventorydata Itemdata;

 public void Collect()
    {
        Destroy(gameObject);
        OnItemCollected?.Invoke(Itemdata);
    }
}
