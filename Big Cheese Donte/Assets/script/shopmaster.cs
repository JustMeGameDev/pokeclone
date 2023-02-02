using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shopmaster : MonoBehaviour
{
    public GameObject denyBandage;
    public GameObject denyAlcohol;
    public GameObject DenyCocaine;

    public static shopmaster Instance;

    public int money = 100;
    public TextMeshProUGUI moneytext;
    public TextMeshProUGUI moneytextShop;
    public GameObject shopwindow;
    public int BandageCost = 10;
    public int alcoholCost = 15;
    public int cocaineCost = 20;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        GameObject[] objs = GameObject.FindGameObjectsWithTag("ShopManager");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
     //   moneytext.text = money.ToString();
       // moneytextShop.text = money.ToString();
        Instance = this;
    }
    public void MoneyCheck()
    {
       // moneytext.text = money.ToString();
        //moneytextShop.text = money.ToString();
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
        MoneyCheck();
    }

    public void Bandagebuy()
    {
        money -= BandageCost;
        MoneyCheck();

        // krijg bandage in inventory

        checkZeroMoney();
    }
    public void cocainebuy()
    {
        money -= cocaineCost;
        MoneyCheck();

        // krijg bandage in inventory

        checkZeroMoney();
    }
    public void alcoholbuy()
    {
        money -= alcoholCost;
        MoneyCheck();

        // krijg bandage in inventory

        checkZeroMoney();
    }




}


