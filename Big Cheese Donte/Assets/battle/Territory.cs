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
    public Collider playerCol;
    public int id;

    private void Start()
    {
        playerCol = player.GetComponent<CapsuleCollider>();
    }
    // Update is called once per frame
    public void Update()
    {
        UpdateMinimap();
        InteractWithEnemyTerritory(id); 
    }

    private void OnTriggerStay(Collider other)
    {
        id = other.GetComponent<Zoneid>().ID_Zone;
    }

    private void OnTriggerEnter(Collider other)
    {
        id = other.GetComponent<Zoneid>().ID_Zone;
    }

    private void OnTriggerExit(Collider other)
    {
        id = 5;
    }
    public void InteractWithEnemyTerritory(int territoryIndex)
    {
        MeshRenderer territoryRenderer = enemyTerritories[territoryIndex].GetComponent<MeshRenderer>();

        // als de player in een territory zit en de player win 
        // dan moet de territory waar de player in zit van kleur veranderen
        switch (territoryIndex)
        {

            case 0:
            switch (interactionCount)
            {
                case 0:
                    territoryRenderer.material = enemyTerritoryMaterial;
                    break;
                case 1:
                    territoryRenderer.material = almostTerritoryMaterial;
                    break;
                case 2:
                    territoryRenderer.material = myTerritoryMaterial;
                    break;
                default:
                    interactionCount = 0;
                    break;
            }
                break;


            case 1:
            switch (interactionCount1)
            {
                case 0:
                    territoryRenderer.material = enemyTerritoryMaterial;
                    break;
                case 1:
                    territoryRenderer.material = almostTerritoryMaterial;
                    break;
                case 2:
                    territoryRenderer.material = myTerritoryMaterial;
                    break;
                default:
                    interactionCount1 = 0;
                    break;
            }
                break;
            case 2:
            switch (interactionCount2)
            {
                case 0:
                    territoryRenderer.material = enemyTerritoryMaterial;
                    break;
                case 1:
                    territoryRenderer.material = almostTerritoryMaterial;
                    break;
                case 2:
                    territoryRenderer.material = myTerritoryMaterial;
                    break;
                default:
                    interactionCount2 = 0;
                    break;
            }
                break;


            case 3:
            switch (interactionCount3)
            {
                case 0:
                    territoryRenderer.material = enemyTerritoryMaterial;
                    break;
                case 1:
                    territoryRenderer.material = almostTerritoryMaterial;
                    break;
                case 2:
                    territoryRenderer.material = myTerritoryMaterial;
                    break;
                default:
                    interactionCount3 = 0;
                    break;
            }
                break;
        }
    }

    private void UpdateMinimap()
    {
        // Iterate through all enemy territories
        for (int i = 0; i < enemyTerritories.Length; i++)
        {
            Renderer territoryRenderer = enemyTerritories[i].GetComponent<Renderer>();

            // Set the enemy territory material for territories that have not been interacted with
            if (i >= interactionCount)
            {
                territoryRenderer.material = enemyTerritoryMaterial;
            }
        }
    } 
    public void THEendGame()
    {
        if (interactionCount == 2 && interactionCount1 == 2 && interactionCount2 == 2 && interactionCount3 == 2)
        {
            //eind screen
        }
    }
}

