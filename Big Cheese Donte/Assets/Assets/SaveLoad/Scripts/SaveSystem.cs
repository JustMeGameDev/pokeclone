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

    

    public static void Save(string saveString) {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            // Create Save Folder
            Directory.CreateDirectory(SAVE_FOLDER);

        }
        // saveNumber is unique
        File.WriteAllText(SAVE_FOLDER + "README"+ "." + SAVE_EXTENSION, EncodeTo64(saveString));
        
    }



    public static string Load() {
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        // Get all save files
        FileInfo[] saveFiles = directoryInfo.GetFiles("*." + SAVE_EXTENSION);
        // Cycle through all save files and identify the most recent one
        FileInfo mostRecentFile = null;
        foreach (FileInfo fileInfo in saveFiles) {
            if (mostRecentFile == null) {
                mostRecentFile = fileInfo;
            } else {
                if (fileInfo.LastWriteTime > mostRecentFile.LastWriteTime) {
                    mostRecentFile = fileInfo;
                }
            }
        }

        // If theres a save file, load it, if not return null
        if (mostRecentFile != null) {
            string saveString = File.ReadAllText(mostRecentFile.FullName);
           
            
            return DecodeFrom64(saveString);
        } else {
            return null;
        }
    }

    static public string EncodeTo64(string toEncode)

    {

        byte[] toEncodeAsBytes

              = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);

        string returnValue

              = System.Convert.ToBase64String(toEncodeAsBytes);

        return returnValue;

    }
    static public string DecodeFrom64(string encodedData)

    {

        byte[] encodedDataAsBytes

            = System.Convert.FromBase64String(encodedData);

        string returnValue =

           System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);

        return returnValue;

    }
}
