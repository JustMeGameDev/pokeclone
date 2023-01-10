using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    FightUI fui;

    [Header("tussen welke level moet de enmy zijn")]
    public int LvlRangeMin;
    public int LvlRangeMax;

    [Header("stats")]
    public string unitName;
    public int unitLevel;
    public int unitLevelEnemy;

    public int damage;

    public int maxHP;
    public int currentHP;

    
    
    private void Awake()
    {


        if (CompareTag("enemy"))
        {
            unitLevelEnemy = Random.Range(LvlRangeMin, LvlRangeMax);
            unitLevel = unitLevelEnemy;
            for (int i = 0; i < unitLevelEnemy; i++)
            {
                damage++;
                maxHP++;
                currentHP++;
            }
        }
        else if (CompareTag("player"))
        {
            for (int i = 0; i < unitLevel; i++)
            {
                damage++;
                maxHP++;
                currentHP++;
            }

        }

        
        
        

        
    }
    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }
   

    public void Heal(int amount)
    {
        currentHP += amount;
        if(currentHP >maxHP)
        {
            currentHP = maxHP;
        }
    }


}
