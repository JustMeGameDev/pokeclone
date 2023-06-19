using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public Enemy enemy;
    public Enemy Team;

    private bool playerTurn = true;
    private bool isBattleOver = false;
    private int playerHealth = 100;
    private int enemyHealth;

    private void Start()
    {
        enemyHealth = enemy.MaxHP;
    }

    private void Update()
    {
        if (isBattleOver)
            return;

        if (playerTurn)
        {
            // Player's turn logic
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AttackEnemy();
            }
        }
        else
        {
            // Enemy's turn logic
            AttackPlayer();
        }
    }

    private void AttackEnemy()
    {
        int damage = Random.Range(5, 10); // Replace with your own calculation

        enemyHealth -= damage;
        Debug.Log("Player attacked enemy for " + damage + " damage.");

        if (enemyHealth <= 0)
        {
            Debug.Log("Enemy defeated!");
            isBattleOver = true;
        }
        else
        {
            playerTurn = false;
        }
    }

    private void AttackPlayer()
    {
        int damage = enemy.Damage - Random.Range(0, 5); // Replace with your own calculation

        int actualDamage = Mathf.Max(0, damage - enemy.Defense);

        playerHealth -= actualDamage;
        Debug.Log("Enemy attacked player for " + actualDamage + " damage.");

        if (playerHealth <= 0)
        {
            Debug.Log("Player defeated!");
            isBattleOver = true;
        }
        else
        {
            playerTurn = true;
        }
    }
}
