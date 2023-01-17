using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fightwithTeamma : MonoBehaviour
{
    //the teamMate member need to be showcase
    public GameObject[] team;
    

    public GameObject ScriptUI;
    recruitment rec;

    // Start is called before the first frame update
    void Start()
    {
        rec = ScriptUI.GetComponent<recruitment>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject currentFound = rec.TeamMember[0];
        SpriteRenderer currentImage = currentFound.GetComponent<SpriteRenderer>();
        team[0].GetComponent<Image>().sprite = currentImage.sprite;
        team[1].GetComponent<Image>().sprite = currentImage.sprite;
        team[3].GetComponent<Image>().sprite = currentImage.sprite;
        team[4].GetComponent<Image>().sprite = currentImage.sprite;

        //for ()
        //{

        //}

    }
}
