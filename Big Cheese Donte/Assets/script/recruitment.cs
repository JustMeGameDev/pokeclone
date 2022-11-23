using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class recruitment : MonoBehaviour
{
    //andere scripts
    moves move;

    //recruit options
    public GameObject tacklrRT;
    public GameObject PunchRT;
    public GameObject BribeRT;
    public GameObject convinceRT;

    //tijdelijk geld 
    public int geld;
    public GameObject geldOpgeven;

    public GameObject plusGeld;
    public GameObject minGeld;

    public TextMeshProUGUI geldText;


    private void Update()
    {
        geldText.text = geld.ToString(); 
        Debug.Log("work");
    }

    public void punch()
    {
        move.PunchRT();
    }

    public void Bribe()
    {
        foreach(geld += 10)
        {

        }
   
    }

    public void geldErop()
    {
        geld++;  
    }
    public void geldEraf()
    {
          geld--;
    
    }
}
