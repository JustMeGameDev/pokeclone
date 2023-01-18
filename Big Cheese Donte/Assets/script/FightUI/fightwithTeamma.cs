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
    public GameObject scrollview;

    // Start is called before the first frame update
    void Start()
    {
        rec = ScriptUI.GetComponent<recruitment>();
    }

    // Update is called once per frame
    public void Update()
    {
        GameObject currentFound = rec.TeamMember[rec.teamMember.Count -1];
        SpriteRenderer currentImage = currentFound.GetComponent<SpriteRenderer>();
        team[0].GetComponent<Image>().sprite = currentImage.sprite;
        team[1].GetComponent<Image>().sprite = currentImage.sprite;
        team[2].GetComponent<Image>().sprite = currentImage.sprite;
        team[3].GetComponent<Image>().sprite = currentImage.sprite;

       
        
    }

    public void TeamMateInZetten()
    {
        print(team.Length);
        GameObject playerGo = Instantiate( team[team.Length]);
        BS.playerunit = playerGo.GetComponent<Unit>();

        if (scrollview)
        { 
            if (Input.GetMouseButtonDown(0))
            {
               inzetten();
               StartCoroutine("inzetten");

            }

        }
       

        
       
        
    }

    public IEnumerator inzetten()
    {  
        BS.playerprefab.SetActive(false);

        yield return new WaitForSeconds(1f);

        team[1].SetActive(true);

    }
    
}
