using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;


public class recruitment : FightUI
{
    //andere scripts
    moves move;

    //ICollectible col;
    public Unit enemy;
    shopmaster shopm;

    //recruit options
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


    public List<GameObject> teamMember = new List<GameObject>();
    public GameObject[] TeamMember;
    public SaveHandler.Enemystats enemystats;
    public SaveHandler save;

    //text 
    public TMP_Text LeftRecruitTextt;
    
    List<string> smartTalk = new List<string> { "\"If you do not join me i will obtain several kidney diseases \"" };
    List<string> enemyTalk = new List<string> { "\"ait sure\"" };


    private void OnLevelWasLoaded(int level)
    {
        //enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<Unit>();
        //enemy = GameObject.Find("enemy").GetComponent<Unit>();
    }
    private void Start()
    {
        teamMember = TeamMember.ToList();
        enemystats = GameObject.FindGameObjectWithTag("DataHandler").GetComponent<SaveHandler.Enemystats>();
        save = GameObject.FindGameObjectWithTag("DataHandler").GetComponent<SaveHandler>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Unit>();
        shopm = GameObject.FindGameObjectWithTag("ShopManager").GetComponent<shopmaster>();

        shopm.money = geld;
        
    }

    private void Update()
    {
        geldText.text = geld.ToString();
        //Debug.Log("work");
        TeamMember = teamMember.ToArray();
    }

    public void Bribe()
    {
        // every 10% chance that the enemy can recruit  
        for (int i = 10; i < geld ;i += 10 )
        {
            bribeChance++;
        }



    }

    public void bribeRT()
    {
        if (bribeChance > 50 || bribeChance == 50)
        {
            // is join the c
            recruit();
            StartCoroutine("switchScene");
            print("join de groep");
        }
        else
        {
            //no 
            print("no");
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
            LeftRecruitTextt.text = RecruitQuip[Random.Range(0, RecruitQuip.Count)];
            
        }
        else
        {
            //wel joinen
            GameObject teamMemberStorage = GameObject.FindGameObjectWithTag("Enemy");
            print(teamMemberStorage);
            if (teamMemberStorage == null)
            {
                print("No gameobject with that tag!");
            }
            teamMember.Add(Enemystation.GetComponentInChildren<GameObject>());
            teamMember.Add(GameObject.FindGameObjectWithTag("Enemy").GetComponent<GameObject>());
            
            Enemystation.GetComponent<Unit>();
             
            recruit();
            StartCoroutine("switchScene");

        }


    }
    public void recruit()
    {
        teamMember.Add(GameObject.FindGameObjectWithTag("enemy"));
        //enemystats.names.Add(enemy.name);
        //enemystats.Levels.Add(enemy.unitLevelEnemy);
        //enemystats.damages.Add(enemy.damage);
        //enemystats.maxHP.Add(enemy.maxHP);
        //enemystats.curHP.Add(enemy.currentHP);
        //enemystats.enemys.Add(GameObject.FindGameObjectWithTag("enemy"));
        //save.enemystats.enemys.Add(GameObject.FindGameObjectWithTag("enemy"));
        //save.Save();
        //  SceneManager.LoadScene(scene);
    }

    public IEnumerator switchScene()
    {
        

        yield return new WaitForSeconds(4f);

    }

    public void smart()
    {
        recruit();
        print("works");
    }

   
}
