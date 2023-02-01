using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fightwithTeamma : MonoBehaviour
{
    //the teamMate member need to be showcase
    public GameObject[] team;

    BattleSystem BS;

    public GameObject ScriptUI;
    recruitment rec;
   // public GameObject scrollview;

    public int chosenTeam;
    public SaveHandler save;

    //public GameObject[] vakjes;
    //public bool empty = true;

    private void OnLevelWasLoaded(int level)
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        save = GameObject.FindGameObjectWithTag("DataHandler").GetComponent<SaveHandler>();
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
                SpriteRenderer currentImage = currentFound.GetComponent<SpriteRenderer>();
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
        save.Load();
        //print(save.enemystats.enemys);
        //team = save.enemystats.enemys;
    }


    public void TeamMateInZetten(int TeamNumber)
    {



        
        //print("je ben in prosses");

        ////als de team member niet active is destory object
        //if(GameObject.FindGameObjectWithTag("ActiveMember") != null)
        //{ 
        //    Destroy(GameObject.FindGameObjectWithTag("ActiveMember"));
        //}
        ////
        //GameObject playerGo = Instantiate(rec.teamMember[TeamNumber],BS.playerstation.transform);
        //playerGo.transform.SetParent(GameObject.Find("playerstation").transform);
        //playerGo.tag = "ActiveMember";
        //BS.playerunit = playerGo.GetComponent<Unit>();

        //inzetten(TeamNumber);
        //print("click");
        //StartCoroutine("inzetten",TeamNumber);
    }

   // public IEnumerator inzetten(int team)
    //{
        //print("works");
        //BS.playerGo.SetActive(false);

        //yield return new WaitForSeconds(2f);

        //rec.teamMember[team].SetActive(true);
        //print("needs to be");
    //}
    
}
