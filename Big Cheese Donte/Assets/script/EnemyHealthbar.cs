using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    FightUI Fui;
    EnemyStats es;
    SpawnEnemy ses;
    GameObject currentEnemy;

    //EnemyHealth
    [Header("healthbar")]
    public GameObject EnemyHealthBar;
    public Slider EnemySlider;
    public TextMeshProUGUI EnemyHealthText;
    public TextMeshProUGUI EnemyName;
    


    private void Awake()
    {
        Fui = GetComponent<FightUI>();
        
    }
    public void SetName()
    {
        EnemyName.text = Fui.randomName;

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




        es.Health = es.MaxHealth;
        EnemySlider.value = CalculateEnemyHealth();



    }


    public void Update()
    {

        
        EnemyHealthText.text = es.Health.ToString() + " / " + es.MaxHealth.ToString();

    }



    float CalculateEnemyHealth()
    {
        return es.Health / es.MaxHealth;
    }
}
