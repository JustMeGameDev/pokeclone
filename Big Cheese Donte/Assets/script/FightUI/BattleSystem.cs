using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum BattleState {WON, LOST, PLAYERTURN, ENEMYTURN, START }
public class BattleSystem : MonoBehaviour
{

    FightUI FUI;
    moves move;



    public BattleState state;

    public GameObject playerprefab;
    public GameObject[] enemyprefab;
    //public  playerGo;

    public Transform playerstation;
    public Transform enemystation;

    public Unit playerunit;
    public Unit enemyunit;
    public TextMeshProUGUI dialogueText;


    public BattleHud playerHUD;
    public BattleHud enemyHUD;

    int punchUsesLeft = 20;
    int StabUsesLeft = 10;
    int ShootUsesLeft = 6;
    int TortureUsesLeft = 2;

  


    private void Start()
    {
        
        FUI = GetComponent<FightUI>();
        move = GetComponent<moves>();
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }



    public IEnumerator SetupBattle()
    {




        GameObject playerGo = Instantiate(playerprefab, playerstation);
        playerunit = playerGo.GetComponent<Unit>();
        GameObject enemyGo = Instantiate(enemyprefab[Random.Range(0, enemyprefab.Length)], enemystation);
        enemyunit = enemyGo.GetComponent<Unit>();


        dialogueText.text = "a wild " + enemyunit.unitName + " aproches";

        playerHUD.SetHUD(playerunit);
        enemyHUD.SetHUD(enemyunit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();



    }



    public void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "you won the battle! ";
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "you where defeated ";
        }
    }

    public IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyunit.unitName + " attacks";

        yield return new WaitForSeconds(2f);


        bool isDead = playerunit.TakeDamage(enemyunit.damage);

        playerHUD.SetHP(playerunit.currentHP);

        yield return new WaitForSeconds(1f);


        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

    }

    void PlayerTurn()
    {
        dialogueText.text = "choose an action ";
    }

    IEnumerator PlayerHeal()
    {

        FUI = GetComponent<FightUI>();

        FUI.GoBackItems();


        playerunit.Heal(5);

        playerHUD.SetHP(playerunit.currentHP);
        dialogueText.text = "you feel renewed energy";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }



    ///////////////////////////////////////////////////////////////////////////AttacksV///////////////////////////////////////////
    public void punch()
    {

        if (state != BattleState.PLAYERTURN)
            return;
        if (punchUsesLeft <= 0)
        {
            dialogueText.text = "thou cant punch anymore";
            FUI.GoBackFight();
            state = BattleState.PLAYERTURN;
        }
        else if (punchUsesLeft >= 0)
        {
            StartCoroutine(move.Punch());
        }
    }
    public void stab()
    {

        if (state != BattleState.PLAYERTURN)
            return;

        if (StabUsesLeft <= 0)
        {
            dialogueText.text = "thou cant stab anymore";
            FUI.GoBackFight();
            state = BattleState.PLAYERTURN;
        }
        else if (StabUsesLeft >= 0)
        {
            StartCoroutine(move.stab());
            StabUsesLeft -= 1;
        }
    }

    public void shoot()
    {

        if (state != BattleState.PLAYERTURN)
            return;
        int shootchangeProcent = Random.Range(0, 100);
        Debug.Log(shootchangeProcent);


        if (ShootUsesLeft <= 0)
        {
            dialogueText.text = "you are out of bullets";
            FUI.GoBackFight();
            state = BattleState.PLAYERTURN;
        }
        else if (ShootUsesLeft >= 0)
        {
            if (shootchangeProcent <= 70)
            {
                Debug.Log("you shot someone :O");
                StartCoroutine(move.shoot());
                ShootUsesLeft -= 1;
                FUI.GoBackFight();

            }
            else
            {
                dialogueText.text = "you missed your shot! ";
                FUI.GoBackFight();
                ShootUsesLeft -= 1;
                state = BattleState.ENEMYTURN;
                
            }
        }
    }
    public void Torture()
        {
        if (state != BattleState.PLAYERTURN)
            return;

        if (TortureUsesLeft <= 0)
        {
            dialogueText.text = "thou cant torture anyone anymore";
            FUI.GoBackFight();
            state = BattleState.PLAYERTURN;
        }
        else if (TortureUsesLeft >= 0)
        {
            StartCoroutine(move.tortuere());
            StabUsesLeft -= 1;
        }
    }




    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }

   
    

}
