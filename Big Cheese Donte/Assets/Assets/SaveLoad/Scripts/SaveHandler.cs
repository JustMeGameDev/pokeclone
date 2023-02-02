using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class SaveHandler : MonoBehaviour 
{

    public Vector3 playerPos;
    public Gamdata gamedata = new Gamdata();
    public GameObject Player;
    public shopmaster Shopmaster = new shopmaster();
    public static SaveHandler Instance;
    public EnemyID enemyid = new EnemyID();
    public string[] enemy = new string[4];


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DataHandler");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }



           //     Load();
        DontDestroyOnLoad(this.gameObject);
      
    }
    
    //public SaveObject saveObject;
    private void Update() 
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        enemyid = GetComponent<EnemyID>();
        Shopmaster = GameObject.FindGameObjectWithTag("ShopManager").GetComponent<shopmaster>();
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L)) 
        {
            Load();
        }
    
    }

    public void Save() {
        // Save

        gamedata.playerposition = Player.transform.position;
        gamedata.money = Shopmaster.money;
        gamedata.enemies = enemyid.cruters;
    

        string json = JsonUtility.ToJson(gamedata);
        SaveSystem.Save(json);

        print("Saved!");
    }

    public void Load() 
    {
        // Load
        string saveString = SaveSystem.Load();
        if (saveString != null) {
            print("Loaded: " + saveString);
            gamedata = JsonUtility.FromJson<Gamdata>(saveString);
            
                    Player.transform.position = gamedata.playerposition;
                    Shopmaster.money = gamedata.money;
                    enemyid.cruters = gamedata.enemies;
                    
       
            
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
        public string[] enemies; 
    }
}