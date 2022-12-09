using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventrory : MonoBehaviour
{
    //ZET DIT SCRIPT OP DE INVENTORYMAN
    public List<inventoryitem> inventory = new List<inventoryitem>();
    private Dictionary<Inventorydata, inventoryitem> itemDictionary = new Dictionary<Inventorydata, inventoryitem>();

    public GameObject holder;

    public GameObject inventoryUI;

    private void OnEnable()
    {
        Item.OnItemCollected += Add;
    }
    private void OnDisable()
    {
        
    }
    public void Add(Inventorydata itemdata)//is nieuwe item het zelfe type als de vorige?
    {
        if (itemDictionary.TryGetValue(itemdata, out inventoryitem Item))
        {
            // Nee add naar stack
            Item.AddToStack();
            print($"{Item.itemdata.displayname}Totaal stack is nu {Item.stackSize}");
        }
        else//ja Maak nieuwe item soort
        {
            inventoryitem newitem = new inventoryitem(itemdata);
            itemDictionary.Add(itemdata, newitem);
            print($"heeft {itemdata.displayname} voor de eerste keer toegevoegd");
        }

        if(holder)
        {
            Instantiate(itemdata);
        }
        

    }
    public void Remove(Inventorydata itemdata)
    {
        if (itemDictionary.TryGetValue(itemdata, out inventoryitem Item))
        {
            Item.RemoveToStack();
            if(Item.stackSize == 0)
            {
                inventory.Remove(Item);
                itemDictionary.Remove(itemdata);
            }
        }
    }


    public void invertroyUI()
    {

       
        
    }
}

