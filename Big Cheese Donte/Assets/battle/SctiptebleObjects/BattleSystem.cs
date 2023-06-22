using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    public Enemy enemy;
    public Enemy Team;

    private bool playerTurn = true;
    private bool isBattleOver = false;
    private int playerHealth = 100;

    private int enemyHealth;
    private int teamHealth;

    public Image Enemysprite;
    public Image teamSprite;

    public TMP_Text EnemyNametext;
    public TMP_Text teamNametext;

    public Slider EnemyHP;
    public Slider teamHP;



    private void Start()
    {
        Enemysprite.sprite = enemy.image; 
        teamSprite.sprite = Team.image;
       
        EnemyNametext.text = enemy.Name;
        teamNametext.text = Team.Name;

        enemyHealth = enemy.MaxHP;
        teamHealth = Team.MaxHP;

        EnemyHP.value = enemy.HP;
        teamHP.value = Team.HP;

        EnemyHP.maxValue = enemy.MaxHP;
    }


    private void FixedUpdate()
    {
        EnemyHP.value = enemy.HP;
        teamHP.value = Team.HP;
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

    public void AttackEnemy()
    {
        int damage = Team.Damage + Random.Range(5, 10); // Replace with your own calculation

        enemyHealth -= damage;
        Debug.Log("Player attacked enemy for " + damage + " damage.");
        print(enemyHealth);
        enemy.HP = enemyHealth;

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
