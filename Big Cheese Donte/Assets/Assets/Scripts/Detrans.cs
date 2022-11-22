using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
public class Detrans : MonoBehaviour
{
    private bool detransition;
    public Volume m_Volume;
    private void Awake()
    {
        m_Volume = GameObject.FindGameObjectWithTag("volume").GetComponent<Volume>();
        detransition = true;
        m_Volume.weight = 1f;
    }
    void FixedUpdate()
    {
        if (detransition)
        {
            m_Volume.weight -= (Time.deltaTime * .8f);
            if (m_Volume.weight <= .000001f)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                detransition = false;
                m_Volume.weight = 0.00001f;
            }
        }
    }
}
