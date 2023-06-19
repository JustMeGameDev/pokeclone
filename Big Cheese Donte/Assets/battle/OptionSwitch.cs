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
    
    public float randomNumber = Random.Range(0, 5);

    Movement movement;
    LookCam cam;

    // Start is called before the first frame update
    void Start()
    {
        movement.GetComponent<Movement>().enabled = false; 
        cam.GetComponent<LookCam>().enabled = false;
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
        if(randomNumber == 0)
        {
            battleCanvas.SetActive(false);
            movement.GetComponent<Movement>().enabled = true;
            cam.GetComponent<LookCam>().enabled = true;
        }
        else
        {
            Debug.Log("runnen is mis lukt");
        }
        
    }
}
