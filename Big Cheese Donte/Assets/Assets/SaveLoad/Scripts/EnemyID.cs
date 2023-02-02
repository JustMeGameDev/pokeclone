using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class EnemyID : MonoBehaviour
{
    public string input;
    public string output;
    public Unit unit;
    public string[] cruters;
    public List<string> creaturs = new List<string>();


    // Start is called before the first frame update
    void Update()
    {
        unit = GameObject.FindGameObjectWithTag("Enemy").GetComponentInChildren<Unit>();
    }

    // Update is called once per frame
    public void StringConstructor()
    {
        int level = unit.unitLevelEnemy;
        int damage = unit.damage;
        int maxHP = unit.maxHP;
        int curHP = unit.currentHP;
        string naam = "";//unit.unitName.Substring(1, 2); ;
        int id = 0;  
        int sprite = 0;



        output = $"{naam}{level.ToString()}{damage.ToString()}{maxHP.ToString()}{curHP.ToString()}{id.ToString()}{sprite.ToString()}";
        creaturs = cruters.ToList();
        cruters.DefaultIfEmpty();
        if(creaturs.Count < 4)
        {
            creaturs.Add(output);
        }
        cruters = creaturs.ToArray();


    }

    public void StringReader()
    {

    }
}
