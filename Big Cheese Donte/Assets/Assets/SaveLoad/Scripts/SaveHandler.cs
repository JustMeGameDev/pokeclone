using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHandler : MonoBehaviour {

    [SerializeField] private GameObject unitGameObject;
    private GameData gameData;

    private void Awake() {
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


    private class SaveObject {
        public int goldAmount;
        public Vector3 playerPosition;
    }
}