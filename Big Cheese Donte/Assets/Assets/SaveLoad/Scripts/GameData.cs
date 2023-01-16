using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Buffers.Text;

[System.Serializable]

public class GameData : MonoBehaviour
{
    //[SerializeField] public GameObject player;
    //[SerializeField] public Vector3 playerposition;
    //[SerializeField] public int money;
    //[SerializeField] public Dictionary<Inventorydata, inventoryitem> itemData;
    [SerializeField] string testS = "test test test";
    [SerializeField] int testI = 1;
    [SerializeField] bool testB = true;
    [SerializeField] double testD = 1.33;
    [SerializeField] float testF = 55.55f;

    

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
