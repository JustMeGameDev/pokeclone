using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    [SerializeField] private float jump = 18f;
    public float grounddrag;

    [Header("groundcheck")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    public bool grounded2;

    public Transform orientation;

    float horizontalI;
    float verticalI;

    public StickyPlatform sticky;
    public bool inMenu;
    Vector3 moveDir;

   public Rigidbody RB;

    //Animation
    public Animator animator;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        //RB.freezeRotation = true;
        sticky = GetComponent<StickyPlatform>();
        animator = GetComponent<Animator>();
        

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        var temphight = playerHeight * .5f + .2f;
        Vector3 der = transform.TransformDirection(Vector3.down) * temphight;
        Gizmos.DrawRay(transform.position, der);
    }
    private void Update()
    {
        PInput();

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        Gizmos.color = Color.yellow;
       


        if (grounded)
        {
            RB.drag = grounddrag;

        }
        else
        {
            
            RB.drag = 0;
        }
        if (Input.GetButtonDown("Jump") && sticky.colide)
        {
            RB.constraints = RigidbodyConstraints.None;
            RB.velocity = new Vector3(RB.velocity.x, jump, RB.velocity.z);
            sticky.jump = true;
            sticky.colide = false;
        }

       


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

