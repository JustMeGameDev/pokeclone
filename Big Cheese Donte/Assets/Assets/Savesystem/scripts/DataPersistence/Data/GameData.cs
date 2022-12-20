using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameData
{
    public long lastUpdated;
    public int Grunts;
    public int money;
    //public Vector3 playerPosition;
    //public GameObject Player = GameObject.FindGameObjectWithTag("Player");
    


    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData()
    {
        this.Grunts = 0;
        //playerPosition = Player.transform.position;
        this.money = 0;

    }
}