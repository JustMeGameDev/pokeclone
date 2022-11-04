using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    [Header("Varibles")]
    public Volume m_Volume;
    public bool transition;
    public bool detransition;
    public string scene;

    void FixedUpdate()
    {
        if (detransition)
        {
            m_Volume.weight -= (Time.deltaTime * .8f);
            if (m_Volume.weight <= .000001f)
            {
                
                detransition = false;
                m_Volume.weight = 0.00001f;
            }
        }

        if (transition)
        {
            m_Volume.weight += (Time.deltaTime * .5f);
            if (m_Volume.weight >= .99f)
            {
                
                SceneManager.LoadScene(scene);
                transition = false;
                
            }
        }
    }
}
