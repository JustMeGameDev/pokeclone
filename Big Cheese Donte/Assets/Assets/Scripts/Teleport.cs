using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class Teleport : MonoBehaviour
{
    [Header("Varibles")]
    public Transform Destination;       // Gameobject where they will be teleported to
    public string TagList = "|Player|Ai|"; // List of all tags that can teleport
    public Volume m_Volume;
    private bool detransition;
    private bool transition;
    public CapsuleCollider collider;
    public GameObject @object;

    public void OnTriggerEnter(Collider other)
    {
        if(other == collider)
        {  
            transition = true;
            @object = GameObject.FindGameObjectWithTag("Player");
        }
        // If the tag of the colliding object is allowed to teleport
    }

    void FixedUpdate()
    {
        if (detransition)
        {
            m_Volume.weight -= (Time.deltaTime * .8f);
            if (m_Volume.weight <= .000001f)
            {
                detransition = false;
                transition = false;
                m_Volume.weight = 0.00001f;
                @object.GetComponent<Movement>().enabled = true;

            }
        }

        if (transition)
        {
            @object.GetComponent<Movement>().enabled = false;
            m_Volume.weight += (Time.deltaTime * .5f);
            if (m_Volume.weight >= .99f)
            {
                
                @object.transform.position = new Vector3(Destination.transform.position.x, @object.transform.position.y, Destination.transform.position.z);
                
                @object.transform.rotation = Destination.transform.rotation;
                transition = false;
                detransition = true;
            }
        }
    }
}