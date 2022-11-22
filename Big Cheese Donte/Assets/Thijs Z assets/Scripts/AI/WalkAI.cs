using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class WalkAI : MonoBehaviour
{
    NavMeshAgent agent;
    
    public Transform[] waypoints;
    int waypointindex;
    Vector3 target;

    public float NPCtimer = 0f;
    public float NPCtimerMax = 7f;
    public bool Npctimerbool;

    public GameObject Crosshaircanv;
    public GameObject Textcanv;
    public string Textvalue;
    public TMP_Text textelement;


    public bool NPClooker;
    public GameObject Player;

    void Start()
    {
        textelement.text = Textvalue;
        agent = GetComponent<NavMeshAgent>();
        UpdateDes();
        Npctimerbool = false;
        NPClooker = false;
       
    }

    void Update()
    {
        textelement.text = Textvalue;
        if (Vector3.Distance(transform.position, target) < 1)
        {

            ITWwaypointIndex();
            UpdateDes();

        }
        if (Npctimerbool == true)
        {
            
            agent.enabled = false;
            NPCtimer -= Time.deltaTime;
            transform.LookAt(Player.transform);
            if (NPCtimer <= 0f)
            {
                Npctimerbool = false;
                
                agent.enabled = true;

                ITWwaypointIndex();
                UpdateDes();
                Textcanv.SetActive(false);
                Crosshaircanv.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

            }
        }
    }
    void UpdateDes()
    {
        target = waypoints[waypointindex].position;
        agent.SetDestination(target);
    }

    void ITWwaypointIndex()
    {
        waypointindex++;
        if (waypointindex== waypoints.Length)
        {
            waypointindex = 0;
        }
    }
    public void Interacttimer()
    {
        Npctimerbool = true;
        NPCtimer = NPCtimerMax;
    }

    public void Mousecursoron()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void QuitDiolog()
    {
        ITWwaypointIndex();
        UpdateDes();
        Textcanv.SetActive(false);
        Crosshaircanv.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


}
