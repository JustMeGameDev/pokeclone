using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shopmaster : MonoBehaviour
{
   public static int money = 100;
   public TextMeshProUGUI moneytext;


    private void Awake()
    {
        moneytext.text = money.ToString();
    }

    public void Bandagebuy()
    {
        money -= 10;
        moneytext.text = money.ToString();
        // krijg bandage in inventory
       if(money <= 0)
        {
            money = 0; //broke ass hahahahahaha
        }
        moneytext.text = money.ToString();

    }
    
 


}


