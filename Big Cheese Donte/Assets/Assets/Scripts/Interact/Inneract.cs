using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inneract : MonoBehaviour
{
    public LayerMask InteractableMask;
    Inneractable inneractable;
    public Image InteractImage;

    public Sprite devaultIcon;
    public Vector2 DevaultIconSize;

    public Sprite devaultInteracticon;
    public Vector2 DevaultInteractIconSize;

    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3,InteractableMask ))
        {
           if(hit.collider.GetComponent<Inneractable>() != false)
            {
                if(inneractable == null || inneractable.ID != hit.collider.GetComponent<Inneractable>().ID)
                {
                    inneractable = hit.collider.GetComponent<Inneractable>();
                    
                }

                //Change keycode to use other key for interact
                if (inneractable.interactIcon != null)
                {
                    InteractImage.sprite = inneractable.interactIcon;
                    if(inneractable.Iconsize == Vector2.zero)
                    {
                        InteractImage.rectTransform.sizeDelta = DevaultInteractIconSize;
                    }
                    else
                    {
                        InteractImage.rectTransform.sizeDelta = inneractable.Iconsize;
                      
                    }
                }
                else
                {
                    InteractImage.sprite = devaultInteracticon;
                    InteractImage.rectTransform.sizeDelta = DevaultInteractIconSize;
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                   inneractable.onInteract.Invoke();
                }
            }
        }
        else
        {
            if (InteractImage.sprite != devaultIcon)
            {
                InteractImage.sprite = devaultIcon;
                InteractImage.rectTransform.sizeDelta = DevaultIconSize;
            }
        }    
    }
}
