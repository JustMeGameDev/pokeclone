using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teretory : MonoBehaviour
{
    public GameObject[] enemyTerritories;

    public Material enemyTerritoryMaterial;
    public Material almostTerritoryMaterial;
    public Material myTerritoryMaterial;

    public int interactionCount = 0;

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
}
