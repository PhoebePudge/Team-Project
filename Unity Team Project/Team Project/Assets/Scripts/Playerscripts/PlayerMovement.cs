using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int affix;
    private Rigidbody rb;
    //movement variables------------------
    private float speed = 3;
    private float moveInput = 0;
    public Vector3 Velocity = new Vector3(0, 0, 0);
    public bool isMoveingRight = false;
    //jump force
    const float jumpForceMin = 4f;
    const float jumpForceMax = 7f;
    private float jumpForce;

    //jumping
    private bool isGrounded;
    private LayerMask whatIsGround;
    private bool isGroundedPrevious = false;
    private bool wallJumping = false;


    // Start is called before the first frame update
    void Start()
    {
        whatIsGround = LayerMask.GetMask("Ground");
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        moveInput = roundInput(Input.GetAxis("P" + affix + "JoyconX"));
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        jump();
        FindMoveDirection();
    }
    private void DeactivePlayer()
    {
        Debug.LogError("Player " + affix + " should be deactivated");
        //gm.SetActive(false);
        //inventory[inventoryIndex].gm.SetActive(false);
    }
    private void FindMoveDirection()
    {
        if (moveInput < 0)
        {
            isMoveingRight = false;
        }
        else if (moveInput > 0)
        {
            isMoveingRight = true;
        }
    }
    private void shakeCamera()
    {
        Camera.main.GetComponent<Animator>().SetTrigger("Shake");
    }
    private float roundInput(float floatToRound)
    {
        if (floatToRound > -0.5 && floatToRound < 0.5)
        {
            return 0;
        }
        return (float)System.Math.Round(floatToRound, 2);
    }
    private void jump()
    {
        isGrounded = Physics2D.OverlapCircle(gameObject.transform.position - new Vector3(0, 0.3f, 0), 0.35f, whatIsGround);
        if (isGroundedPrevious == false && isGrounded == true)
        {
            shakeCamera();
            //health -= Vector3.Distance(rb.velocity, Velocity) * 10;
        }
        if (isGrounded == true && Input.GetButtonDown("P" + affix + "Enter"))
        {
            jumpForce = jumpForceMin;
        }
        if (isGrounded == true && Input.GetButton("P" + affix + "Enter"))
        {
            if (jumpForce < jumpForceMax)
            {
                jumpForce += 0.3f;
            }
        }
        if (isGrounded == true && Input.GetButtonUp("P" + affix + "Enter") || jumpForce > jumpForceMax)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpForce = jumpForceMin;
        }
        checkForWallJump();
        isGroundedPrevious = isGrounded;
    }
    private void checkForWallJump()
    {
        if (true)
        {
            UnityEngine.RaycastHit hit;
            //Debug.Log("is this working???");
            if (UnityEngine.Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("hit");
            }
        }
    }
}
