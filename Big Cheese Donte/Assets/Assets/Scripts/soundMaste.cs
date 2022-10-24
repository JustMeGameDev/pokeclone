using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class soundMaste : MonoBehaviour
{
    public AudioListener audioListener;
    public AudioSource source;
    public AudioClip clipA;
    public AudioClip clipB;
    public AudioClip clipC;
    public AudioClip clipD;
    public AudioClip clipE;
   

    private void Awake()
    {
        string A = SceneManager.GetActiveScene().name;
        if (A == "Menu" )
        {
            source.clip = clipA;
            source.loop = true;
        }
    }


}
