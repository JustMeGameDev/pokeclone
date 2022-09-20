using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    List<string> RunQuip = new List<string> { "\"So you actualy ran away.... coward \"", "\"Why are you runing away coward, come and face me like a real man \"", "\" Am i too strong for you that you need to run away? \"" };// quips voor het wegrennen
    public GameObject YouRan;
    public TextMeshProUGUI LinkerFightText;
    public TextMeshProUGUI LinkerItemsText;
    public TextMeshProUGUI LinkerRecruitText;
    public TextMeshProUGUI LinkerMainText;
    
    //BG = battleground BGI = battleground image (zijn images voor de battlegrounds)
    public Image OldImage;
    public bool BG1 = false;
    public Sprite BGI1;
    public bool BG2 = false;
    public Sprite BGI2;
    public bool BG3 = false;
    public Sprite BGI3;

    public float Health;
    public float MaxHealth;

    //range of damage. (I chance this later voor each weapon)
    public int minDmg = 1;
    public int maxDmg = 10;

    public GameObject HealthBar;
    public Slider Slider;

    public TextMeshProUGUI healthText;


    private void awake()
    {
        //if (BG1 == true)
        //{
           
        //}
        //else if (BG2 == true)
        //{
           
        //}
        //else if (BG3 == true)
        //{
           
        //}


    }

    public void Damage(int amount)
    {
        Health -= Random.Range(minDmg, maxDmg);

        Health -= amount;
       
    }
    public void Start()
    {


        Health = MaxHealth;
        Slider.value = CalculateHealth();
        //scoreText.text = "Points: " + 1;
    }


    public void Update()
    {
        Slider.value = CalculateHealth();

        if (Health <= 0 )
        {

       
            //hier moet wat gebeuren als de enemy of de player 0 is
           

        }

        healthText.text = Health.ToString() + " / " + MaxHealth.ToString();


    }

    float CalculateHealth()
    {//als de max health 100 is en health 10 veranderd de healthbar
        return Health / MaxHealth;
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
        LinkerMainText.text = RunQuip[Random.Range(0, RunQuip.Count)];
        YouRan.SetActive(true);
        // na 3 seconden YouRan.SetActive(false);
    }


}
