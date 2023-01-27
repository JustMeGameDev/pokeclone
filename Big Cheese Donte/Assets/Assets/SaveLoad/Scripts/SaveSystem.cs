using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Buffers.Text;
using System.Security.Cryptography.X509Certificates;
public static class SaveSystem {

    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    private const string SAVE_EXTENSION = "json";
    private static SaveUtil saveUtil = GameObject.FindGameObjectWithTag("DataHandler").GetComponent<SaveUtil>();
    
    

    public static void Save(string saveString) {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            // Create Save Folder
            Directory.CreateDirectory(SAVE_FOLDER);

        }
        // saveNumber is unique
        File.WriteAllText(SAVE_FOLDER + "README"+ "." + SAVE_EXTENSION, saveString);
        
    }
    public static void SaveTeam(string saveString)
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            // Create Save Folder
            Directory.CreateDirectory(SAVE_FOLDER);

        }
        // saveNumber is unique
       // File.WriteAllText(SAVE_FOLDER + "Enemy" + "." + SAVE_EXTENSION, saveUtil.encrypt(saveString));
        File.WriteAllText(SAVE_FOLDER + "Enemy" + "." + SAVE_EXTENSION, saveString);

    }



    public static string Load()
    {
        if (Directory.Exists(SAVE_FOLDER) && File.Exists(SAVE_FOLDER + "README" + "." + SAVE_EXTENSION))
        {

            string saveString = File.ReadAllText(SAVE_FOLDER + "README" + "." + SAVE_EXTENSION);
            return saveString;

        }
        // Get save file
        return default;


    }
    public static string LoadTeam()
    {
        if (Directory.Exists(SAVE_FOLDER) && File.Exists(SAVE_FOLDER + "Enemy" + "." + SAVE_EXTENSION))
        {

            string saveString = File.ReadAllText(SAVE_FOLDER + "Enemy" + "." + SAVE_EXTENSION);
            return saveString;
            //return saveUtil.decrypt(saveString);

        }
        // Get save file
        return default;


    }



}
