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
    List<string> FightQuip = new List<string> { "\"Why don't you come at me if you want to die that bad\"", "\"You really do have a deadwish or am i wrong?\"", "\"You think you can beat me?! dont make me laugh\"", "\"You cant defeat me, if you want to defeat me you have to train for another 1000 years!!\"" }; // quips voor het vechten
    List<string> ItemQuip = new List<string> { "\"Using items now, cant beat me without drugs? \"", "\"Did i beat you that hard that you need to use an item to beat me now?\"", "\"Thats pretty cowardly using items in the middle of battle\"", "\"Using items in a battle, thats a bold move pipsqueek\"" }; // quips voor items
    List<string> RecruitQuip = new List<string> { "\"Do you relly think you can make me join you? you sure dream big \"", "\"I am not going to betray my boss to join a wannabe like you!\"", "\"Do you really think you can make me join you in the middle of a battle?\"", "\"I am not going to join you, no way you dont know what my boss does to traitors\"" };// quips voor recruiten
    public TextMeshProUGUI LinkerFightText;
    public TextMeshProUGUI LinkerItemsText;
    public TextMeshProUGUI LinkerRecruitText;

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
        LinkerItemsText.text = ItemQuip[Random.Range(0, ItemQuip.Count)];// dit zorgt ervoor dat je een random item quip krijgt
    }
    public void RecruitMenu()
    {
        Main.SetActive(false);
        Recruit.SetActive(true);
        LinkerRecruitText.text = RecruitQuip[Random.Range(0, RecruitQuip.Count)];
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
