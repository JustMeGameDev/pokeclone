using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class EnemyHealthbar : MonoBehaviour
{

    EnemyStats es;

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

    private void Awake()
    {
        es = GetComponent<EnemyStats>();
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
