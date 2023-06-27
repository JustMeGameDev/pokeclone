using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    public Enemy enemy;
    public Enemy Team;
    public TeamArray TeamMembers;
    //public TeamArray EnemyMember;

    public EnemyManger enemyManager;
    public Territory ter;

    private bool playerTurn = true;
    private bool isBattleOver = false;


    public int enemyHealth;
    public int teamHealth;

    public Image Enemysprite;
    public Image teamSprite;

    public TMP_Text EnemyNametext;
    public TMP_Text teamNametext;

    public Slider EnemyHP;
    public Slider teamHP;

    public Button RunButton;
    public Button BattleButton;

    public OptionSwitch optionSwitch;

    public bool start = true;

    public TextMeshProUGUI[] TeamButton;

    private void Start()
    {
        Team = TeamMembers.Standing;
        Enemysprite.sprite = enemy.image; 
        teamSprite.sprite = Team.image;
       
        EnemyNametext.text = enemy.Name;
        teamNametext.text = Team.Name;

        enemyHealth = enemy.MaxHP;
        teamHealth = Team.MaxHP;

        EnemyHP.value = enemy.HP;
        teamHP.value = Team.HP;

        EnemyHP.maxValue = enemy.MaxHP;
        teamHP.maxValue = Team.MaxHP;

        RunButton = GameObject.Find("mm Run button").GetComponent<Button>();
        BattleButton = GameObject.Find("mm Battle button").GetComponent<Button>();

        optionSwitch = this.GetComponent<OptionSwitch>();
    }


    private void FixedUpdate()
    {
        EnemyHP.value = enemy.HP;
        teamHP.value = Team.HP;
        Enemysprite.sprite = enemy.image;
        teamSprite.sprite = Team.image;
        EnemyNametext.text = enemy.Name;
        teamNametext.text = Team.Name;

        MyTeam();
        
    }

    private void Update()
    {
        if (isBattleOver)
            return;

        if (playerTurn)
        {
            RunButton.enabled = true;
            BattleButton.enabled = true;
           
        }
        else
        {
            RunButton.enabled = false;
            BattleButton.enabled = false;
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
        optionSwitch.back();

        if (enemyHealth <= 0)
        {
            Debug.Log("Enemy defeated!");
            isBattleOver = true;
        }
        else
        {
            start = false;
            playerTurn = false;
        }
    }

    public void AttackPlayer()
    {
        int damage = enemy.Damage + Random.Range(5, 9); // Replace with your own calculation

        int actualDamage = Mathf.Max(0, damage - enemy.Defense);

        teamHealth -= actualDamage;
        Debug.Log("Enemy attacked player for " + actualDamage + " damage.");
        print(teamHealth);
        Team.HP = teamHealth;


        if (teamHealth <= 0)
        {
            Debug.Log("Player defeated!");
            isBattleOver = true;

        }
        else
        {
            playerTurn = true;
        }
    }
    public void recruit()
    {
        float randomValue = Random.value;

        // Set the chance of enemy joining the team (50%)
        float joinChance = 0.5f;

        if (randomValue <= joinChance)
        {
            enemyManager.CaptureEnemy(enemy);
        }
    }
    public void MyTeam()
    { 
        for (int i = 0; i < TeamMembers.Array.Length; i++)
        {
            string temp = TeamMembers.Array[i].Name.ToString();
            TeamButton[i].text = temp;

        }
       
    }
    public void spawn(int i)
    {
        Enemy temp = Team;
        Team = TeamMembers.Array[i];
        TeamMembers.Array.SetValue(temp, i);
        TeamMembers.Standing = Team;

    }
    public void Territoty()
    {
        //als de battle is over interactionCount++
        if (EnemyHP.value == 0 || enemyManager.enemyContainer != null)
        {
            ter.interactionCount++;
        }
        else if (teamHP.value == 0)
        {
            ter.interactionCount--;
        }
    }


}
