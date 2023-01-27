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
    public Enemystats enemystats = new Enemystats();
    public GameObject Player;
    public shopmaster Shopmaster;
    public static SaveHandler Instance;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DataHandler");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        switch (SceneManager.GetActiveScene().name)
        {
            case "World":
                Player = GameObject.FindGameObjectWithTag("Player");
                Shopmaster = GameObject.FindGameObjectWithTag("ShopManager").GetComponent<shopmaster>();
                break;

            case "Fight":
                Shopmaster = GameObject.FindGameObjectWithTag("ShopManager").GetComponent<shopmaster>();
                break;
        }
      
    }
    private void OnLevelWasLoaded(int level)
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "World":
                Player = GameObject.FindGameObjectWithTag("Player");
                Shopmaster = GameObject.FindGameObjectWithTag("ShopManager").GetComponent<shopmaster>();
                break;

            case "Fight":
                Shopmaster = GameObject.FindGameObjectWithTag("ShopManager").GetComponent<shopmaster>();
                    break;

        }
                Load();
    }
    //public SaveObject saveObject;
    private void Update() 
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
    
    public void Save() {
        // Save
        switch (SceneManager.GetActiveScene().name)
        {
            case "World":
                gamedata.playerposition = Player.transform.position;
                gamedata.money = Shopmaster.money;
                break;

            case "Fight":
                gamedata.money = Shopmaster.money;
                break;
        }

        string json = JsonUtility.ToJson(gamedata);
        string enemy = JsonUtility.ToJson(enemystats);
        SaveSystem.Save(json);
        SaveSystem.SaveTeam(enemy);

        print("Saved!");
    }

    public void Load() 
    {
        // Load
        string saveString = SaveSystem.Load();
        string Loadteam = SaveSystem.LoadTeam();
        if (saveString != null) {
            print("Loaded: " + saveString + " " + Loadteam);
            gamedata = JsonUtility.FromJson<Gamdata>(saveString);
            enemystats = JsonUtility.FromJson<Enemystats>(Loadteam);
            switch (SceneManager.GetActiveScene().name)
            {
                case "World":
                    Player.transform.position = gamedata.playerposition;
                    Shopmaster.money = gamedata.money;
                    break;

                case "Fight":
                    Shopmaster.money = gamedata.money;
                    break;
            }
            
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

    [System.Serializable]

    public class Enemystats
    {
        /*public List<string> names;
        public List<int> Levels;
        public List<int> damages;
        public List<int> maxHP;
        public List<int> curHP;*/

        public List<GameObject> enemys;
    }
}