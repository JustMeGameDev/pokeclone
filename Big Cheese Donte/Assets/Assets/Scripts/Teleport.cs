using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class Teleport : MonoBehaviour
{
    [Header("Varibles")]
    public Transform Destination;       // Gameobject where they will be teleported to
    public string[] tags;
    public Volume m_Volume;
    private bool detransition;
    private bool transition;
    public CapsuleCollider collider;
    public GameObject @object;


    // If the tag of the colliding object is allowed to teleport
    // Use this for initialization
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
                @object.GetComponent<Movement>().enabled = true;
                detransition = false;
                m_Volume.weight = 0.00001f;
            }
        }

        if (transition)
        {
            @object.GetComponent<Movement>().enabled = false;
            m_Volume.weight += (Time.deltaTime * .5f);
            if (m_Volume.weight >= .99f)
            {
            if (System.Array.IndexOf(tags, @object.tag) != -1)
                {
                    // Update other objects position and rotation
                    @object.transform.position = Destination.transform.position;
                    @object.transform.rotation = Destination.transform.rotation;
                    transition = false;
                    detransition = true;
                }
            }
        }
        
    }
        public void OnTriggerEnter(Collider other)
        {
            @object = other.gameObject;
            transition = true;
        }
        // If the tag of the colliding object is allowed to teleport
    }