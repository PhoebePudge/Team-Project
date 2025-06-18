using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //movement variables------------------
    private float speed = 3;
    private float moveInput = 0;
    public Vector3 Velocity = new Vector3(0, 0, 0);
    public bool isMoveingRight = false;
    //jump force
    const float jumpForceMin = 4f;
    const float jumpForceMax = 7f;
    private float jumpForce = 10000;

    //jumping
    private bool isGrounded;
    private LayerMask whatIsGround;
    private bool isGroundedPrevious = false;
    private bool wallJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<Rigidbody2D>();
        gameObject.AddComponent<BoxCollider2D>();
    }
    enum Action
    {
        Idle,
        Jumping,
        Running,
        WallJump
    }
    private Action currentAction = Action.Idle;
    private Action previousAction = Action.Idle;
    // Update is called once per frame
    void Update()
    {
        //defult to idle
        currentAction = Action.Idle;

        //detect is running
        if (getXAxis() != 0)
        {
            currentAction = Action.Running;
        }

        //detect is jumping
        if (getEnter())
        {
            currentAction = Action.Jumping;

            //detect if it was a wall jump

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity) || Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.yellow);
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
                //Debug.Log("Did Hit");
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 1000, Color.white);
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1000, Color.white);
                //Debug.Log("Did not Hit");
            }
        }

        //check for change in action
        if (currentAction != previousAction)
        {
            Debug.Log(gameObject.name + " is now " + currentAction.ToString());
        }
        switch (currentAction)
        {
            case Action.Idle:
                break;
            case Action.Jumping:
                isGrounded = Physics2D.OverlapCircle(gameObject.transform.position - new Vector3(0, 0.3f, 0), 0.35f, whatIsGround);
                if (isGroundedPrevious == false && isGrounded == true)
                {
                    //gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0f));
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
                }
                isGroundedPrevious = isGrounded;
                break;
            case Action.WallJump:
                break;
            case Action.Running:
                moveInput = Input.GetAxis("P" + Returnindex() + "JoyconX");
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveInput * speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
                break;
        }

        previousAction = currentAction;
    }
    IEnumerable Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0f));
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));

        yield return new WaitForSeconds(2f);
    }
    #region input
    private string Returnindex()
    {
        var cArray = gameObject.name.ToCharArray();
        int pos = int.Parse(cArray[cArray.Length - 1].ToString());
        pos++;
        return pos.ToString();
    } 
    private float getXAxis()
    {
        return Input.GetAxis("P" + Returnindex() + "JoyconX");
    }
    private bool getEnter()
    {
        return Input.GetButton("P" + Returnindex() + "Enter");
    }
    private bool getReturn()
    {
        return Input.GetButton("P" + Returnindex() + "Return");
    }
    private float getTriggerLeft()
    {
        return Input.GetAxis("P" + Returnindex() + "TriggerLeft");
    }
    private float getTriggerRight()
    {
        return Input.GetAxis("P" + Returnindex() + "TriggerRight");
    }
    #endregion
}
