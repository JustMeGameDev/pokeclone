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

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDes();
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, target)< 1)
        {
            ITWwaypointIndex();
            UpdateDes();
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
    void Interacttimer()
    {
        
    }
    public bool interact(bool a)
    {

    }
}
