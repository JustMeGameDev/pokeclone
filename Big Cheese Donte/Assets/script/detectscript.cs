using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectscript : MonoBehaviour
{
    public GameObject Lasthit;
    public Vector3 collision = Vector3.zero;
    public LayerMask layer;
    public float GroteDrawgizmo = 0.2f;
    public int MaxLenght = 100;


    private void Update()
    {
        var ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, MaxLenght))
        {
            Lasthit = hit.transform.gameObject;
            collision = hit.point;
            Debug.Log(hit.transform.gameObject);
        }

      

    }

   


}
