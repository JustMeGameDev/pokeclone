using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fightwithTeamma : MonoBehaviour
{
    //the teamMate member need to be showcase
    public GameObject[] team;
    Unit u;
    BattleSystem BS;
    public GameObject teammate;

    public GameObject ScriptUI;
    recruitment rec;
   // public GameObject scrollview;

    public int chosenTeam;
    public SaveHandler save;
    // Start is called before the first frame update
    void Start()
    {
       // save = GameObject.FindGameObjectWithTag("DataHandler").GetComponent<SaveHandler>();
        fillTeam();
        BS = GameObject.Find("ui scripts").GetComponent<BattleSystem>();
        rec = ScriptUI.GetComponent<recruitment>();
        SetImages();
    }
    
    public void SetImages()
    {
        try
        {

            for(int i = 0; i < team.Length; i++)
            {
                GameObject currentFound = rec.teamMember[i];
                Image currentImage = currentFound.GetComponent<Image>();
                team[i].GetComponent<Image>().sprite = currentImage.sprite;
                team[i] = Instantiate(rec.teamMember[i]);

                 
            }
        }
        catch
        {

        }
    }
    // Update is called once per frame
    public void Update()
    {
         SetImages();
        
    }

    public void fillTeam()
    {
       // save.Load();
        //print(save.enemystats.enemys);
        //team = save.enemystats.enemys;
    }


    public void TeamMateInZetten(int TeamNumber)
    {

        print("je ben in prosses");

       // als de team member niet active is destory object
        if (GameObject.FindGameObjectWithTag("ActiveMember_Enemy") != null || GameObject.FindGameObjectWithTag("ActiveMember_Player") != null)
        {
            print("Character verwisselt");
            Destroy(GameObject.FindGameObjectWithTag("ActiveMember_Enemy"));

            Destroy(GameObject.FindGameObjectWithTag("ActiveMember_Player"));
        }
        GameObject playerGo = Instantiate(rec.teamMember[TeamNumber], BS.playerstation);
        playerGo.transform.SetParent(GameObject.Find("playerstation").transform);
        playerGo.tag = "ActiveMember_Player";
        BS.playerunit = playerGo.GetComponent<Unit>();

        inzetten(TeamNumber);
        print("click");
        StartCoroutine("inzetten", TeamNumber);
    }

    public IEnumerator inzetten(int team)
    {
        print("works");
      //  BS.playerGo.SetActive(false);

        yield return new WaitForSeconds(2f);

        rec.teamMember[team].SetActive(true);
        print("needs to be");
    }

}
