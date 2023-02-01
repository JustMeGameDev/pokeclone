using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyID : MonoBehaviour
{
    public string input;
    public string output;
    public static Unit unit;
    public recruitment recruit;
    public SaveHandler save;
    public string[] cruters = new string[4];


    // Start is called before the first frame update
    void Start()
    {
        recruit = GameObject.FindGameObjectWithTag("Enemy").GetComponent<recruitment>();
        unit = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Unit>();
    }

    // Update is called once per frame
    public void StringConstructor()
    {
        int level = unit.unitLevelEnemy;
        int damage = unit.damage;
        int maxHP = unit.maxHP;
        int curHP = unit.currentHP;
        string naam = unit.unitName.Substring(0, 2); ;
        int id = cruters.Length;
        


        output = $"{naam}{level.ToString()}{damage.ToString()}{maxHP.ToString()}{curHP.ToString()}{id.ToString()}{sprite.ToString()}";
        cruters[id] = output;
    }

    public void StringReader()
    {

    }
}
