using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    Rigidbody2D rb;
    private bool facingRight = true;

    public  bool isGroudnded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int extraJumps;
    public int extraJumpAmount;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpAmount;
    }

    void FixedUpdate()
    {
        isGroudnded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGroudnded == true)
        {
            extraJumps = extraJumpAmount;
        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGroudnded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        //Dash
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (moveInput > 0)
            {
                rb.velocity = new Vector2(0, 0);
                rb.AddForce(Vector2.right * 200000);
            }
            if (moveInput < 0)
            {
                rb.velocity = new Vector2(0, 0);
                rb.AddForce(Vector2.left * 200000);
            }
        }
    }
}
