using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shopmaster : MonoBehaviour
{
    public GameObject denyBandage;
    public GameObject denydildo;
    public GameObject denyAlcohol;
    public GameObject DenyCocaine;
    public GameObject Denyplaceholder;

    public static int money = 100;
   public TextMeshProUGUI moneytext;
    public GameObject shopwindow;
    public int BandageCost = 10;
    public int alcoholCost = 15;
    public int cocaineCost = 20;

    private void Awake()
    {
        moneytext.text = money.ToString();
    }
    private void Update()
    {
        if( money < BandageCost)
        {
            denyBandage.SetActive(true);
        }
        if (money < alcoholCost)
        {
            denyAlcohol.SetActive(true);
        }
        if (money < cocaineCost)
        {
            DenyCocaine.SetActive(true);
        }
    }
    public void ShopAway()
    {
        
        shopwindow.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void checkZeroMoney()
    {
        if (money <= 0)
        {
            money = 0; //broke ass hahahahahaha
        }
        moneytext.text = money.ToString();
    }

    public void Bandagebuy()
    {
        money -= BandageCost;
        moneytext.text = money.ToString();

        // krijg bandage in inventory

        checkZeroMoney();
    }
    public void cocainebuy()
    {
        money -= cocaineCost;
        moneytext.text = money.ToString();

        // krijg bandage in inventory

        checkZeroMoney();
    }
    public void alcoholbuy()
    {
        money -= alcoholCost;
        moneytext.text = money.ToString();

        // krijg bandage in inventory

        checkZeroMoney();
    }




}


