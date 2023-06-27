using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
        [Header("varibles")]
        public Volume m_Volume;
        public bool transition;
        public bool detransition;
        public Canvas battleCanvas;
        public Movement movement;
        public LookCam look;

        private void Awake()
        {
            m_Volume = GameObject.FindGameObjectWithTag("volume").GetComponent<Volume>();
            battleCanvas = GameObject.FindGameObjectWithTag("BattleCanvas").GetComponent<Canvas>();
            movement = this.GetComponent<Movement>();
            look = this.GetComponent<LookCam>();
            battleCanvas.enabled = false;
        }
        public void Update()
        {

            if (transition)
            {
                if (battleCanvas.isActiveAndEnabled)
                {
                    movement.enabled = true;
                    look.enabled = true;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    m_Volume.weight += (Time.deltaTime * .5f);
                    if (m_Volume.weight >= .99f)
                    {

                        battleCanvas.enabled = false;
                        transition = false; 
                        m_Volume.weight = 0;

                    }
                }
                else
                {
                    movement.enabled = false;
                    look.enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    m_Volume.weight += (Time.deltaTime * .5f);
                    if (m_Volume.weight >= .99f)
                    {

                        battleCanvas.enabled = true;
                        transition = false;
                        m_Volume.weight = 0;

                    }
                }
            }
          
        }
}

