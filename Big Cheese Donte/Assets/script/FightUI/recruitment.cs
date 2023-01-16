using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class recruitment : FightUI
{
    //andere scripts
    moves move;
    ICollectible col;
    Unit u;
    shopmaster shopm;

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


    public List<GameObject> teamMember = new List<GameObject>();

    //text 
    public TMP_Text LeftRecruitTextt;
    
    List<string> smartTalk = new List<string> { "\"If you do not join me i will obtain several kidney diseases \"" };
    List<string> enemyTalk = new List<string> { "\"ait sure\"" };


    private void Start()
    {
        shopm = GetComponent<shopmaster>();

        shopm.money = geld;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        geldText.text = geld.ToString(); 
        //Debug.Log("work");
    }

    public void Bribe()
    {
        for (int i = 10; i < geld ;i += 10 )
        {
            bribeChance++;

            if ()
            {

            }
        }

        if (bribeChance++ > 50)
        {
            
            switchScene();
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
            teamMember.Add(Enemystation.GetComponentInChildren<GameObject>());
            teamMember.Add(GameObject.Find("enemy"));
            Enemystation.GetComponent<Unit>();
            switchScene();

        }


    }

    public IEnumerator switchScene()
    {
        teamMember.Add(GameObject.Find("enemy"));

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(scene);
    }

    public void smart()
    {
        SmartRT();
        StartCoroutine("SmartRT");
        print("works");
    }

    public IEnumerator SmartRT()
    {
        print("Smart manier");
            //niet joinen
       // LeftRecruitTextt.text = randomName + smartTalk[Random.Range(0, smartTalk.Count)];
       
        yield return new WaitForSeconds(2f);
       // LeftRecruitTextt.text = randomName + enemyTalk[Random.Range(0, enemyTalk.Count)];

        teamMember.Add(GameObject.Find("enemy"));

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(scene);
    
    }


   
}
