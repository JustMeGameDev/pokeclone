using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManger : MonoBehaviour
{
    public TeamArray enemyContainer;
    public void CaptureEnemy(Enemy enemy)
    {
        if (enemyContainer != null)
        {
            // Create a new array with increased size to hold the captured enemy
            Enemy[] newEnemies = new Enemy[enemyContainer.Array.Length + 1];

            // Copy existing enemies to the new array
            for (int i = 0; i < enemyContainer.Array.Length; i++)
            {
                newEnemies[i] = enemyContainer.Array[i];
            }

            // Add the captured enemy to the new array
            newEnemies[newEnemies.Length - 1] = enemy;

            // Replace the old array with the new array
            enemyContainer.Array = newEnemies;
        }
    }
}
