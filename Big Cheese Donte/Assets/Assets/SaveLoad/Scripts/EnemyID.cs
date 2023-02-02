using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EnemyID : MonoBehaviour
{
    public string input;
    public string output;
    public Unit unit;
    public SaveHandler save;
    public fightwithTeamma fightwith;
    public string[] cruters;
    public List<string> creaturs = new List<string>();
    //varibles voor loading
    public int Level;
    public int Damage;
    public int MaxHP;
    public string Naam;
    public int CurHP;
    public int Sprite;
    public Image image;

   

    // Start is called before the first frame update
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "world")
        {
            save = GetComponent<SaveHandler>();
        }
        else if (SceneManager.GetActiveScene().name == "Fight")
        {

            unit = GameObject.FindGameObjectWithTag("Enemy").GetComponentInChildren<Unit>();
            save = GetComponent<SaveHandler>();
            fightwith = GameObject.FindGameObjectWithTag("fightWith").GetComponent<fightwithTeamma>();
            image = GameObject.FindGameObjectWithTag("ActiveMember_Enemy").GetComponent<Image>();
        }
    }

    // Update is called once per frame
    public void StringConstructor()
    {
        output = "";
        int level = unit.unitLevelEnemy;
        int damage = unit.damage;
        int maxHP = unit.maxHP;
        int curHP = unit.currentHP;
        string naam = unit.unitName.Substring(0,2);  
        int sprite = 0;
        Sprite sprite1 = image.sprite; 

        switch(sprite1.name)
        {
            case "enemy":
                sprite = 0;
                break;
            case "enemy_2":
                sprite = 1;
                break;
            case "enemy_3":
                sprite = 2;
                break;
            case "enemy_4":
                sprite = 3;
                break;
            case "enemy_5":
                sprite = 4;
                break;
        }


        output = $"{naam}{level.ToString()}{damage.ToString()}{maxHP.ToString()}{sprite.ToString()}{curHP.ToString()}";
        creaturs = cruters.ToList();
        cruters.DefaultIfEmpty();
        if(creaturs.Count < 4)
        {
            creaturs.Add(output);
        }
        cruters = creaturs.ToArray();
        save.Save();

    }

    public void StringReader()
    {
        cruters = save.gamedata.enemies;

        Level = int.Parse(cruters[fightwith.chosenTeam].Substring(2,2));
        Damage = int.Parse(cruters[fightwith.chosenTeam].Substring(4, 2));
        MaxHP = int.Parse(cruters[fightwith.chosenTeam].Substring(6, 3));
        Naam = cruters[fightwith.chosenTeam].Substring(0, 2);
        CurHP = int.Parse(cruters[fightwith.chosenTeam].Substring(10));
        Sprite = int.Parse(cruters[fightwith.chosenTeam].Substring(9, 1));

        print($"{Level} | {Damage} | {MaxHP} | {Naam} | {CurHP} | {Sprite}");


    }
}
