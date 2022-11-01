using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    public Rigidbody rb;
    public bool jump;
    public bool colide;
    public Collider collider;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor" && jump)
        {
            colide = true;
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            jump = false;

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        jump = true;
        colide = true;
        rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y - 10 * Time.deltaTime, rb.transform.position.z);
    }

}