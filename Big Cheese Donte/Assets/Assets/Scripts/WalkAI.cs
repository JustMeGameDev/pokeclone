using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkAI : MonoBehaviour
{
    NavMeshAgent agent;
    
    public Transform[] waypoints;
    int waypointindex;
    Vector3 target;

    public float NPCtimer = 0f;
    public float NPCtimerMax = 7f;
    public bool Npctimerbool;

    public bool NPClooker;
    public GameObject Player;

    void Start()
    { 
        agent = GetComponent<NavMeshAgent>();
        UpdateDes();
        Npctimerbool = false;

        NPClooker = false;
       
    }

    void Update()
    {
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

}
