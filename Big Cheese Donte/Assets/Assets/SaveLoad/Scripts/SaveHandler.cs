using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHandler : MonoBehaviour {

   
    public GameData gameData;

    public void Awake() {
        gameData = GameObject.FindGameObjectWithTag("DataHandler").GetComponent<GameData>();
        
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.K)) {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L)) {
            Load();
        }
    }

    private void Save() {
        // Save


        SaveObject saveObject = new SaveObject {
            Testt = "rewrite",
            test = 420,
        }; 
        string json = JsonUtility.ToJson(saveObject);
        SaveSystem.Save(json);

        print("Saved!");
    }

    private void Load() {
        // Load
        string saveString = SaveSystem.Load();
        if (saveString != null) {
            print("Loaded: " + saveString);

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

           
        } else {
            print("No save");
        }
    }


    public class SaveObject {
        public int test;
        public string Testt;
    }
}