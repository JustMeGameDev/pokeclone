using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class FightUI : MonoBehaviour
{
    Unit unit;

    
    public GameObject Main;
    public GameObject Fight;
    public GameObject Items;
    public GameObject Recruit;
    public GameObject RTbribe;
    public GameObject Rtpersuade;

<<<<<<< HEAD:Big Cheese Donte/Assets/script/fighting UI/FightUI.cs
    public string scene;

    List<string> Names = new List<string> {"Jhon: ", "Jesse: ", "Finn: ", "Driss: ", "Thijs: ", "Kornee: ", "Jarno: ", "David: ", "Walter: ", "Jessie: ", "Niels: ","Jesper: ", "Arjen: ","Storm: ", "Max:s " };
    List<string> FightQuip = new List<string> { "\"Why don't you come at me if you want to die that bad\"", "\"You really do have a death wish or am i wrong?\"", "\"You think you can beat me?! don`t make me laugh\"", "\"You cant defeat me, if you want to defeat me you have to train for another 1000 years!!\"" }; // quips voor het vechten
    List<string> ItemQuip = new List<string> { "\"Using items now, cant beat me without drugs? \"", "\"Did i beat you that hard that you need to use an item to beat me now?\"", "\"Thats pretty cowardly using items in the middle of battle\"", "\"Using items in a battle, thats a bold move pipsqueak\"" }; // quips voor items
    List<string> RecruitQuip = new List<string> { "\"Do you really think you can make me join you? you sure dream big \"", "\"I am not going to betray my boss to join a wannabe like you!\"", "\"Do you really think you can make me join you in the middle of a battle?\"", "\"I am not going to join you, no way you don`t know what my boss does to traitors\"" };// quips voor recruiten
    List<string> RunQuip = new List<string> { "\"So you actually ran away.... coward \"", "\"Why are you running away coward, come and face me like a real man \"", "\" Am i too strong for you that you need to run away? \"" };// quips voor het wegrennen
=======
    public List<string> Names = new List<string> {"Jhon: ", "Jesse: ", "Finn: ", "Driss: ", "Thijs: ", "Kornee: ", "Jarno: ", "David: ", "Walter: ", "Jessie: ", "Niels: ","Jesper: ", "Arjen: ","Storm: ", "Max:s " };
    public List<string> FightQuip = new List<string> { "\"Why don't you come at me if you want to die that bad\"", "\"You really do have a deadwish or am i wrong?\"", "\"You think you can beat me?! dont make me laugh\"", "\"You cant defeat me, if you want to defeat me you have to train for another 1000 years!!\"" }; // quips voor het vechten
    public List<string> ItemQuip = new List<string> { "\"Using items now, cant beat me without drugs? \"", "\"Did i beat you that hard that you need to use an item to beat me now?\"", "\"Thats pretty cowardly using items in the middle of battle\"", "\"Using items in a battle, thats a bold move pipsqueek\"" }; // quips voor items
    public List<string> RecruitQuip = new List<string> { "\"Do you relly think you can make me join you? you sure dream big \"", "\"I am not going to betray my boss to join a wannabe like you!\"", "\"Do you really think you can make me join you in the middle of a battle?\"", "\"I am not going to join you, no way you dont know what my boss does to traitors\"" };// quips voor recruiten
    public List<string> RunQuip = new List<string> { "\"So you actualy ran away.... coward \"", "\"Why are you runing away coward, come and face me like a real man \"", "\" Am i too strong for you that you need to run away? \"" };// quips voor het wegrennen
>>>>>>> fighting-ui-thijs:Big Cheese Donte/Assets/script/FightUI.cs
    
    public GameObject YouRan;
    public TextMeshProUGUI LinkerFightText;
    public TextMeshProUGUI LinkerItemsText;
    public TextMeshProUGUI LeftRecruitText;
    public TextMeshProUGUI LinkerMainText;
    
    public string randomName;

    public void Awake()
    {
        randomName = Names[Random.Range(0, Names.Count)];
    }
    

    public void FightMenu()
    {
        Main.SetActive(false);
        Fight.SetActive(true);
        LinkerFightText.text = randomName + FightQuip[Random.Range(0, FightQuip.Count)]; // dit zorgt ervoor dat je een random quip krijgt als je op fight klikt
    }
    public void ItemMenu()
    {
         Main.SetActive(false);
        Items.SetActive(true);
        LinkerItemsText.text = randomName + ItemQuip[Random.Range(0, ItemQuip.Count)];// dit zorgt ervoor dat je een random item quip krijgt
    }
    public void RecruitMenu()
    {
        Main.SetActive(false);
        Recruit.SetActive(true);
        LeftRecruitText.text = randomName + RecruitQuip[Random.Range(0, RecruitQuip.Count)];
    }
    public void RecruitBribe()
    {
        Recruit.SetActive(false);
        RTbribe.SetActive(true);

    }
    public void RecruitPersaude()
    {
        Recruit.SetActive(false);
        Rtpersuade.SetActive(true);

    }

    public void Run()
    {
        Debug.Log("you ran");
        LinkerMainText.text = randomName + RunQuip[Random.Range(0, RunQuip.Count)];
        YouRan.SetActive(true);
        SceneManager.LoadScene(scene);
        // na 3 seconden YouRan.SetActive(false);
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
}
