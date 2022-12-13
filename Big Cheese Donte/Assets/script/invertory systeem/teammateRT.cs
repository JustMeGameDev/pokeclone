using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teammateRT : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] TeamMate;

    // The maximum number of team mates that can be held in the group
    public int maxTeamMates = 35;

    void Start()
    {
        // Initialize the array of team Mates with the maximum number of team Mates
          TeamMate = new GameObject[maxTeamMates];
    }

    // Adds an team to the group
    public void Addteammate(GameObject TeamToAdd)
    {
        for (int i = 0; i < TeamMate.Length; i++)
        {
            if (TeamMate[i] == null)
            {
                //if ()
                //{

                //}
                // If there is an empty slot in the party, add the teamMate
                TeamMate[i] = TeamToAdd;
                return;
            }
        }
    }

    // Removes an team mate from the group
    public void RemoveTeammate(GameObject TeamToRemove)
    {
        for (int i = 0; i < TeamMate.Length; i++)
        {
            if (TeamMate[i] == TeamToRemove)
            {
                // If the team mate is in the party, remove it
                TeamMate[i] = null;
                return;
            }
        }
    }
}
