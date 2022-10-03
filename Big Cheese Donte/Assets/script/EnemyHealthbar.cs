using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class EnemyHealthbar : MonoBehaviour
{

    EnemyStats es;
    SpawnEnemy ses;
    GameObject currentEnemy;

    //EnemyHealth
    [Header("healthbar")]
    public GameObject EnemyHealthBar;
    public Slider EnemySlider;
    public TextMeshProUGUI EnemyHealthText;


    public void Damage(int amount)
    {
        // Enemy Damage
        es.EnemyHealth -= Random.Range(es.minDmg, es.maxDmg);

        es.EnemyHealth -= amount;

    }

    public void Init()
    {
        //GetComponent Spawn Enemy script
        ses = GetComponent<SpawnEnemy>();
        //Haal uit enemyscript de list gemaamd Enemies en haal daaruit entry 0 (De eerste vijand uit de list)
        Debug.Log(ses.ChooseEnemy);
        currentEnemy = ses.Enemies[ses.ChooseEnemy];

        //GetComponent Enemystats uit de huidige vijand en noem die ES
        es = currentEnemy.GetComponent<EnemyStats>();
    }
    public void Start()
    {

        


        es.EnemyHealth = es.EnemyMaxHealth;
        EnemySlider.value = CalculateEnemyHealth();



    }


    public void Update()
    {

        
        EnemyHealthText.text = es.EnemyHealth.ToString() + " / " + es.EnemyMaxHealth.ToString();

    }



    float CalculateEnemyHealth()
    {
        return es.EnemyHealth / es.EnemyMaxHealth;
    }
}
