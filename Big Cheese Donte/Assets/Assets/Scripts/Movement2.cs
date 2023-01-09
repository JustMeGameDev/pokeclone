using UnityEngine;
using System.Collections;

public class Movement2 : MonoBehaviour
{
    private Rigidbody rg;
    public float speed = 10.0F;
    public float jumpspeed = 10.0F;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rg = GetComponent<Rigidbody>();
    }


    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 atas = new Vector3(0, 100, 0);
            rg.AddForce(atas * speed, ForceMode.Impulse);
        }

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;


    }

}