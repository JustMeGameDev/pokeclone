using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum BattleState {WON, LOST, PLAYERTURN, ENEMYTURN, START }
public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    public GameObject playerprefab;
    public GameObject enemyprefab;

    public Transform playerstation;
    public Transform enemystation;

    Unit playerunit;
    Unit enemyunit;

    public TextMeshProUGUI dialogueText;


    public BattleHud playerHUD;
    public BattleHud enemyHUD;

    private void Start()
    {
        state = BattleState.START;
      StartCoroutine(SetupBattle());
    }



    IEnumerator SetupBattle()
    {
      GameObject playerGo =  Instantiate(playerprefab, playerstation);
       playerunit = playerGo.GetComponent<Unit>();
      GameObject enemyGo  =  Instantiate(enemyprefab, enemystation);
       enemyunit = enemyGo.GetComponent<Unit>();


        dialogueText.text = "a wild " + enemyunit.unitName + " aproches";

        playerHUD.SetHUD(playerunit);
        enemyHUD.SetHUD(enemyunit);
        
        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();

        

    }

    IEnumerator PlayerAttack()
    {
       bool isDead = enemyunit.TakeDamage(playerunit.damage);

        enemyHUD.SetHP(enemyunit.currentHP);
        dialogueText.text = "the attack is succesfull";

      yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
           EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

    }

    void EndBattle()
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

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyunit.unitName + " attacks";

        yield return new WaitForSeconds(2f);

        bool isDead = playerunit.TakeDamage(enemyunit.damage);

        playerHUD.SetHP(playerunit.currentHP);

        yield return new WaitForSeconds(1f);


        if(isDead)
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
        playerunit.Heal(5);

        playerHUD.SetHP(playerunit.currentHP);
        dialogueText.text = "you feel renewed energy";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());

            
        

    }
    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());




    }

}
