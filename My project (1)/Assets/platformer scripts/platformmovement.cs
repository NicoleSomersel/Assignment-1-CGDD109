using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class platformmovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float moveDir = 0;
    private bool isGround = false;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask Groundlayer;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.A))
        {
            moveDir = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDir = 1f;
        }
        //Nested conditionals
        if((!Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)))
        {
            moveDir = 0;
        }
        rb.linearVelocity = new Vector2(moveDir * moveSpeed, rb.linearVelocity.y);

        if(Input.GetKeyDown(KeyCode.Space)&& isGround)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        }
    }
    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, Groundlayer);
    }
}
