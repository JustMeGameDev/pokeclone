using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyStats : MonoBehaviour
{
    public string unitname;
    public int unitlevel;

    public int damage;

    
    public int MaxHealth;
    public int Health;




    public bool TakeDamage(int dmg)
    {
        Health -= damage;

        if (Health <= 0)
            return true;
        else
            return false;

        
    }











}
