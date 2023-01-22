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

    //public GameObject[] vakjes;
    //public bool empty = true;

   
    // Start is called before the first frame update
    void Start()
    {
        BS = GameObject.Find("ui scripts").GetComponent<BattleSystem>();
        rec = ScriptUI.GetComponent<recruitment>();
        SetImages();
    }

    public void SetImages()
    {
        
         
            for(int i = 0; i < team.Length; i++)
            {
                GameObject currentFound = rec.teamMember[i];
                SpriteRenderer currentImage = currentFound.GetComponent<SpriteRenderer>();
                team[i].GetComponent<Image>().sprite = currentImage.sprite;
                team[i] = Instantiate(rec.teamMember[i]);

                 
            }

    }
    // Update is called once per frame
    public void Update()
    {
         SetImages();  
    }


    public void TeamMateInZetten(int TeamNumber)
    {
        print("je ben prosses");

        //als de team member niet active is destory object
        if(GameObject.FindGameObjectWithTag("ActiveMember") != null)
        { 
            Destroy(GameObject.FindGameObjectWithTag("ActiveMember"));
        }
        //
        GameObject playerGo = Instantiate(rec.teamMember[TeamNumber],BS.playerstation.transform);
        playerGo.transform.SetParent(GameObject.Find("playerstation").transform);
        playerGo.tag = "ActiveMember";
        BS.playerunit = playerGo.GetComponent<Unit>();

        inzetten(TeamNumber);
        print("click");
        StartCoroutine("inzetten",TeamNumber);
    }

    public IEnumerator inzetten(int team)
    {
        print("works");
        BS.playerGo.SetActive(false);

        yield return new WaitForSeconds(2f);

        rec.teamMember[team].SetActive(true);
        print("needs to be");
    }
    
}
