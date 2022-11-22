using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float grounddrag;

    [Header("groundcheck")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalI;
    float verticalI;

    Vector3 moveDir;

    Rigidbody RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        //RB.freezeRotation = true;
    }
    private void Update()
    {
        PInput();

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        if (grounded)
            RB.drag = grounddrag;
        else
            RB.drag = 0;
    }
    private void FixedUpdate()
    {
        Moveplayer();
    }
    private void PInput()
    {
        horizontalI = Input.GetAxisRaw("Horizontal");
        verticalI = Input.GetAxisRaw("Vertical"); 
    }
    private void Moveplayer()
    {
        moveDir = orientation.forward * verticalI + orientation.right * horizontalI;

        RB.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force);
    }

}

