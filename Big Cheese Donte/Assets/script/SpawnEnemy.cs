using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    

    public GameObject[] Enemies;
    public  int ChooseEnemy;
    public int currentEnemy;


    private void Start()
    {
       
        ChooseEnemy = Random.Range(0, Enemies.Length);
        currentEnemy = ChooseEnemy;
        
        Debug.Log(ChooseEnemy);
        
        if (ChooseEnemy >= 0 )
        {
           GameObject enemy = Instantiate(Enemies[ChooseEnemy], transform.position, transform.rotation) as GameObject;
            enemy.transform.SetParent(GameObject.FindGameObjectWithTag("SpawnEnemy").transform, false);
          
        }
        
       
    }



   
}
