using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class SaveUtil : MonoBehaviour
{
    private static string key;
    private static char[] keyParts =  "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
    private void Awake()
    {
        if (PlayerPrefs.GetString("KEY") == null)
        {
            keymake();
        }
    }
    public string encrypt(string input)
    {
        keymake();
        print("encrypted");
        return (EncryptString(input));        
    }
    public string decrypt(string input)
    {
        print("decrypted");
        return(DecryptString(input));
    }
    public static string EncryptString(string plainText)
    {
        byte[] iv = new byte[16];
        byte[] array;

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(PlayerPrefs.GetString("KEY"));
            aes.IV = iv;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                    {
                        streamWriter.Write(plainText);
                    }

                    array = memoryStream.ToArray();
                }
            }
        }

        return System.Convert.ToBase64String(array);
    }
    public string keymake()
    {
        PlayerPrefs.DeleteKey("KEY");
        key = "";
        for (int i = 0; i < 16; i++)
        {
            key += keyParts[Random.Range(0, keyParts.Length)];
        }
        PlayerPrefs.SetString("KEY", key);
        print("Key generted " + key);
        return key;
    }
    public static string DecryptString(string cipherText)
    {
        byte[] iv = new byte[16];
        byte[] buffer = System.Convert.FromBase64String(cipherText);

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(PlayerPrefs.GetString("KEY"));
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream(buffer))
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }
    }
}
