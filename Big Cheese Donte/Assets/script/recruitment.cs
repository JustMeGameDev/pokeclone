using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class recruitment : FightUI
{
    //andere scripts
    moves move;
    ICollectible col;
    Unit u;

    //recruit options
    public GameObject tacklrRT;
    public GameObject PunchRT;
    public GameObject BribeRT;
    public GameObject convinceRT;

    public GameObject Enemystation;

    //tijdelijk geld 
    public int geld;
    public GameObject geldOpgeven;

    public GameObject plusGeld;
    public GameObject minGeld;
    public TextMeshProUGUI geldText;

    //varibles
    public int bribeChance;

    public int WantToTeamUp = 2;
    public int refuse = 0;

    //gift
    public GameObject Gift;


   // public List<GameObject> teamMember = new List<GameObject>();

    //text 
    public TextMeshProUGUI LinkerRecruitText;
    
    List<string> smartTalk = new List<string> { "\"if you join me then i take care of your family \"" };
    List<string> enemyTalk = new List<string> { "\"okie dokie \"" };


    private void Start()
    {
       
    }

    private void Update()
    {
      //  geldText.text = geld.ToString(); 
        //Debug.Log("work");
    }

    public void punch()
    {
        move.PunchRT();
    }

    public void Bribe()
    {
        for (int i = 10; i <geld ;i += 10 )
        {
            bribeChance++;
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

    public void DirectRT()
    {
        int diceroll = Random.Range(refuse, WantToTeamUp);


        if (diceroll == refuse)
        {
            print("test tekst");
            //niet joinen
            LinkerRecruitText.text = RecruitQuip[Random.Range(0, RecruitQuip.Count)];
            
        }
        else
        {
            //wel joinen
            //teamMember.Add(Enemystation.GetComponentInChildren<GameObject>());
            //teamMember.Add(GameObject.FindGameObjectWithTag("enemy"));
            Enemystation.GetComponent<Unit>().Recruit();
            //u.Recruit();

        }


    }
    public void smart()
    {
        // SmartRT();
        StartCoroutine("SmartRT");
        print("works");
    }

    public IEnumerator SmartRT()
    {

        
        print("Smart manier");
            //niet joinen
        LinkerRecruitText.text = randomName + smartTalk[Random.Range(0, smartTalk.Count)];
       
        yield return new WaitForSeconds(2f);
        LinkerRecruitText.text = randomName + enemyTalk[Random.Range(0, enemyTalk.Count)];

        //teamMember.Add(GameObject.FindGameObjectWithTag("enemy"));

       


    }

   
}
