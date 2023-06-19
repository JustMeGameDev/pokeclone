using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName ="New Enemy",menuName ="Enemy")]
public class Enemy : ScriptableObject
{
    public string Name;
    public int HP;
    public int MaxHP;
    public int XP;
    public int MaxXP;
    public int Level;
    public int Defense;
    public int Damage;
    public string Type;
    public Image image;


    
}
