using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSwitch : MonoBehaviour
{
    public GameObject battleCanvas;

    public GameObject BattleOption;

    public GameObject run;

    public GameObject backButton;

    public GameObject battlebutton;

    public GameObject recuitbutton;

    public GameObject myTeamButtom;
    public GameObject myTeamoption;
    public int randomNumber = 0; //Random.Range(0, 5);

    //public Transition trans;
    Movement movement;
    LookCam cam;

    // Start is called before the first frame update
    public void Start()
    {
        movement.GetComponent<Movement>().enabled = false; 
        cam.GetComponent<LookCam>().enabled = false;
        //trans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transition>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Main()
    {
        battlebutton.SetActive(true);
        BattleOption.SetActive(false);
        run.SetActive(true);
        backButton.SetActive(false);
        myTeamButtom.SetActive(true);
        myTeamoption.SetActive(false);
    }
    public void battle()
    {
        battlebutton.SetActive(false);
        BattleOption.SetActive(true);
        run.SetActive(false);
        backButton.SetActive(true); 
        myTeamButtom.SetActive(false);
        myTeamoption.SetActive(false);
    }

    public void back()
    {
        battlebutton.SetActive(true);
        BattleOption.SetActive(false);
        run.SetActive(true);
        backButton.SetActive(false); 
        myTeamButtom.SetActive(true);
        myTeamoption.SetActive(false);
    }
    public void Run()
    {
       
 
    }
    public void recuit()
    {
        
    }
    public void MyTeam()
    {
        battlebutton.SetActive(false);
        BattleOption.SetActive(false);
        run.SetActive(false);
        backButton.SetActive(true);
        myTeamButtom.SetActive(false);
        myTeamoption.SetActive(true);
        recuitbutton.SetActive(false);
    }
}
