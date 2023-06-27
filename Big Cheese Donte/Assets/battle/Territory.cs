using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Territory : MonoBehaviour
{
    public GameObject[] enemyTerritories;

    public Material enemyTerritoryMaterial;
    public Material almostTerritoryMaterial;
    public Material myTerritoryMaterial;

    public int interactionCount = 0;
    public int interactionCount1 = 0;
    public int interactionCount2 = 0; 
    public int interactionCount3 = 0;

    public GameObject player;

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void InteractWithEnemyTerritory(int territoryIndex)
    {  
        Renderer territoryRenderer = enemyTerritories[territoryIndex].GetComponent<Renderer>(); 

        // als de player in een territory zit en de player win 
        // dan moet de territory waar de player in zit van kleur veranderen
        if (player && enemyTerritories.Length == 0)
        {
            if (interactionCount == 0)
            {
                territoryRenderer.material = almostTerritoryMaterial;
            }
            else if (interactionCount == 1)
            {
                territoryRenderer.material = myTerritoryMaterial;
            }
            else if (interactionCount >= 2)
            {
                territoryRenderer.material = myTerritoryMaterial;
                // Perform additional actions if needed when the territory becomes green.
            }
            interactionCount++;
        }
        else if (player && enemyTerritories.Length == 1)
        {
            if (interactionCount1 == 0)
            {
                territoryRenderer.material = almostTerritoryMaterial;
            }
            else if (interactionCount1 == 1)
            {
                territoryRenderer.material = myTerritoryMaterial;
            }
            else if (interactionCount1 >= 2)
            {
                territoryRenderer.material = myTerritoryMaterial;
                // Perform additional actions if needed when the territory becomes green.
            }
            interactionCount1++;
        }
        else if (player && enemyTerritories.Length == 2)
        {
            if (interactionCount2 == 0)
            {
                territoryRenderer.material = almostTerritoryMaterial;
            }
            else if (interactionCount2 == 1)
            {
                territoryRenderer.material = myTerritoryMaterial;
            }
            else if (interactionCount2 >= 2)
            {
                territoryRenderer.material = myTerritoryMaterial;
                // Perform additional actions if needed when the territory becomes green.
            }
            interactionCount2++;
        }
        else if (player && enemyTerritories.Length == 3)
        {
            if (interactionCount3 == 0)
            {
                territoryRenderer.material = almostTerritoryMaterial;
            }
            else if (interactionCount3 == 1)
            {
                territoryRenderer.material = myTerritoryMaterial;
            }
            else if (interactionCount3 >= 2)
            {
                territoryRenderer.material = myTerritoryMaterial;
                // Perform additional actions if needed when the territory becomes green.
            }
            interactionCount3++;
        }

        
    }
}
