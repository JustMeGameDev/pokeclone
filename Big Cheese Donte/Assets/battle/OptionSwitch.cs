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
    }
    public void battle()
    {
        battlebutton.SetActive(false);
        BattleOption.SetActive(true);
        run.SetActive(false);
        backButton.SetActive(true);
    }

    public void back()
    {
        battlebutton.SetActive(true);
        BattleOption.SetActive(false);
        run.SetActive(true);
        backButton.SetActive(false);
    }
    public void Run()
    {
       
        
            //roep transition aan en bool true
            //trans.transition = true;
        
        
        
    }
}
