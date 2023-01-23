using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SaveHandler : MonoBehaviour 
{

    public Vector3 playerPos;
    public Gamdata gamedata = new Gamdata();
    public GameObject Player;
    public shopmaster Shopmaster;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Shopmaster = GameObject.FindGameObjectWithTag("ShopManager").GetComponent<shopmaster>();
    }
    //public SaveObject saveObject;
    private void FixedUpdate() 
    {
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L)) 
        {
            Load();
        }
        //auto-save function

        //SaveTimer = SaveTimer - 0.02f;

        //if (SaveTimer <= 0)
        //{
        //    print("AutoSave");
        //    SaveTimer = 300f;

        //    Save();
        //}
    
    }
    
    private void Save() {
        // Save
        gamedata.playerposition = Player.transform.position;
        gamedata.money = Shopmaster.Money;
        string json = JsonUtility.ToJson(gamedata);
        SaveSystem.Save(json);

        print("Saved!");
    }

    private void Load() 
    {
        // Load
        string saveString = SaveSystem.Load();
        if (saveString != null) {
            print("Loaded: " + saveString);
            gamedata = JsonUtility.FromJson<Gamdata>(saveString);

            Player.transform.position = gamedata.playerposition;
            Shopmaster.Money = gamedata.money;
        } else {
            print("No save");
        }
    }

    [System.Serializable]
    public class Gamdata
    {
        public Vector3 playerposition;
        public int money;
        public Dictionary<Inventorydata, inventoryitem> itemData;
    }
}