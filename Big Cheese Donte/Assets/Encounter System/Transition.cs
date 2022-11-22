using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    [Header("varibles")]
    public Volume m_Volume;
    public bool transition;
    public bool detransition;
    public string scene;

    private void Awake()
    {
        m_Volume = GameObject.FindGameObjectWithTag("volume").GetComponent<Volume>();
    }
    void FixedUpdate()
    {
        if (detransition)
        {
            m_Volume.weight -= (Time.deltaTime * .8f);
            if (m_Volume.weight <= .000001f)
            {
                this.gameObject.GetComponent<Movement>().enabled = true;
                this.gameObject.GetComponent<LookCam>().Inmenu = false;
                detransition = false;
                m_Volume.weight = 0.00001f;
            }
        }

        if (transition)
        {
            this.gameObject.GetComponent<Movement>().enabled = false;
            m_Volume.weight += (Time.deltaTime * .5f);
            if (m_Volume.weight >= .99f)
            {
                
                SceneManager.LoadScene(scene);
                transition = false;
                
            }
        }
    }
}
