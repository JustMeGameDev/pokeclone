using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public class Unit : MonoBehaviour
{
    FightUI fui;
    EnemyID enemyID;

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
    public bool NEW = true;
    public Sprite[] sprites;
    public Sprite Currentsprite;

    public string[] names ={
            "Niels",
            "Jesper",
            "Arjen",
            "Raygen",
            "Kornee",
            "Thijs",
            "Finn",
            "Driss",
            "Adi",
            "Rene",
            "Ids",
            "Jarno",
            "Fatman",
            "Franciesco",
            "Marcello"
        };

    private void Awake()
    {
        enemyID = GameObject.FindGameObjectWithTag("DataHandler").GetComponent<EnemyID>();

        if (NEW)
        {
            if (CompareTag("ActiveMember_Enemy"))
            {
                unitLevelEnemy = Random.Range(LvlRangeMin, LvlRangeMax);
                unitLevel = unitLevelEnemy;
                unitName = names[Random.Range(0, 15)];
                for (int i = 0; i < unitLevelEnemy; i++)
                {
                    damage++;
                    maxHP++;
                    currentHP++;
                }
            }
            else if (CompareTag("ActiveMember_Player"))
            {
                for (int i = 0; i < unitLevel; i++)
                {
                    damage++;
                    maxHP++;
                    currentHP++;
                }

            }
        }
        else
        {
            enemyID.StringReader();
            string search = enemyID.name;
            foreach (string s in names)
            {
                if (s.Length >= 2 && s.Substring(0, 2).Equals(search, System.StringComparison.OrdinalIgnoreCase))
                {
                    unitName = s;
                    print($"{s} | {unitName}");
                }

            }
            unitLevel = enemyID.Level;
            damage = enemyID.Damage;
            currentHP = enemyID.CurHP;
            maxHP = enemyID.MaxHP;
            Image image = GetComponent<Image>();
            Currentsprite = sprites[enemyID.Sprite];
            image.sprite = Currentsprite;
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
