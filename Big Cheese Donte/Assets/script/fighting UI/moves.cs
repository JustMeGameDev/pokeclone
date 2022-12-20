using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moves : MonoBehaviour
{
    BattleSystem bs;

    recruitment RT;

    bool isDead;

    private void Awake()
    {
        bs = GetComponent<BattleSystem>();
        RT = GetComponent<recruitment>();
    }

    public void IsDeadCheck()
    {
        if (isDead)
        {
            bs.state = BattleState.WON;
            bs.EndBattle();
        }
        else
        {
            bs.state = BattleState.ENEMYTURN;
            StartCoroutine(bs.EnemyTurn());
        }
    }


   public IEnumerator Punch()
   {
        FightUI FUI;
        FUI = GetComponent<FightUI>();

        FUI.GoBackFight();
        FUI.GoBackItems();
        FUI.GoBackRecruit();
        //                                                    V kan je plus of min doen ivm welke move het is
        isDead = bs.enemyunit.TakeDamage(bs.playerunit.damage);

        bs.enemyHUD.SetHP(bs.enemyunit.currentHP);
        bs.dialogueText.text = "the attack is succesfull";

        yield return new WaitForSeconds(2f);

        IsDeadCheck();


      
   }
    public IEnumerator Bleed()
    {
        FightUI FUI;
        FUI = GetComponent<FightUI>();

        FUI.GoBackFight();
        FUI.GoBackItems();
        FUI.GoBackRecruit();
        //                                                    V kan je plus of min doen ivm welke move het is
        bool isDead = bs.enemyunit.TakeDamage(bs.playerunit.damage * 1);
        print("Outch");
      
        bs.enemyHUD.SetHP(bs.enemyunit.currentHP);
        bs.dialogueText.text = "the Bleed is succesfull";

        yield return new WaitForSeconds(2f);

        IsDeadCheck();

    }


    public IEnumerator stab()
    {
        FightUI FUI;
        FUI = GetComponent<FightUI>();

        FUI.GoBackFight();
        FUI.GoBackItems();
        FUI.GoBackRecruit();
        //                                                    V kan je plus of min doen ivm welke move het is
        bool isDead = bs.enemyunit.TakeDamage(bs.playerunit.damage * 1);

        bs.BleedCount += 3;
        bs.enemyHUD.SetHP(bs.enemyunit.currentHP);
        bs.dialogueText.text = "the attack is succesfull";

        yield return new WaitForSeconds(2f);

        IsDeadCheck();

    }
    public IEnumerator shoot()
    {
        FightUI FUI;
        FUI = GetComponent<FightUI>();

        FUI.GoBackFight();
        FUI.GoBackItems();
        FUI.GoBackRecruit();
        //                                                    V kan je plus of min doen ivm welke move het is
        bool isDead = bs.enemyunit.TakeDamage(bs.playerunit.damage * 2);

        bs.enemyHUD.SetHP(bs.enemyunit.currentHP);
        bs.dialogueText.text = "the attack is succesfull";

        yield return new WaitForSeconds(2f);

        IsDeadCheck();

    }
    public IEnumerator tortuere()
    {
        FightUI FUI;
        FUI = GetComponent<FightUI>();

        FUI.GoBackFight();
        FUI.GoBackItems();
        FUI.GoBackRecruit();
        //                                                    V kan je plus of min doen ivm welke move het is
        bool isDead = bs.enemyunit.TakeDamage(bs.playerunit.damage * 10/7);

        bs.enemyHUD.SetHP(bs.enemyunit.currentHP);
        bs.dialogueText.text = "the attack is succesfull";

        yield return new WaitForSeconds(2f);

        IsDeadCheck();

    }

    public void PunchRT()
    {
        bool isDead = bs.enemyunit.TakeDamage(bs.playerunit.damage * 100);
    }


}

