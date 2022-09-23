using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Abstract : MonoBehaviour
{
    [SerializeField] protected int Health;
    [SerializeField] protected string Name ;
    [SerializeField] protected int Damage;

    protected virtual void Spawn()
    {
        print("i am " + Name + " i have " + Health + " hp and i do " + Damage + " damage");
    }

}
