using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;
using TMPro;



public class FightUI : MonoBehaviour
{
    public GameObject Main;
    public GameObject Fight;
    public GameObject Items;
    public GameObject Recruit;
    List<string> FightQuip = new List<string> { \"Why don't you come at me if you want to die that bad\"", "quip 2", "quip 3", "quip 4" }; // quips voor het vechten
    public TextMeshProUGUI LinkerFightText;

    private void Start()
    {
        

    }


    public void FightMenu()
    {
        Main.SetActive(false);
        Fight.SetActive(true);
        LinkerFightText.text = FightQuip[Random.Range(0, FightQuip.Count)]; // dit zorgt ervoor dat je een random quip krijgt als je op fight klikt
    }
    public void ItemMenu()
    {
        Main.SetActive(false);
        Items.SetActive(true);
    }
    public void RecruitMenu()
    {
        Main.SetActive(false);
        Recruit.SetActive(true);
    }
    public void GoBackFight()
    {
        Fight.SetActive(false);
        Main.SetActive(true);
    }
    public void GoBackItems()
    {
        Items.SetActive(false);
        Main.SetActive(true);
    }
    public void GoBackRecruit()
    {
        Recruit.SetActive(false);
        Main.SetActive(true);
    }
    public void Run()
    {
        Debug.Log("you ran");
    }


}
