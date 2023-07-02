using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiWalking : MonoBehaviour
{

    public Transform[] targetWaypoints;
    public float movementSpeed = 5f;
    public float rotationSpeed = 10f;

    private int currentWaypointIndex = 0;

    public Animator anim;
    public void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (targetWaypoints.Length > 0)
        {
            Transform currentWaypoint = targetWaypoints[currentWaypointIndex];

            // Calculate direction to the current waypoint
            Vector3 direction = currentWaypoint.position - transform.position;
            direction.Normalize();

            // Rotate towards the current waypoint
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);


            transform.position += direction * movementSpeed * Time.deltaTime;


            if (Vector3.Distance(transform.position, currentWaypoint.position) < 0.1f)
            {
                currentWaypointIndex++;


                if (currentWaypointIndex >= targetWaypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
            }
        }

    }
}
