using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{

    public GameObject gm;
    private Rigidbody2D rb;
    public void moveIdle()
    {
        rb.velocity = new Vector2(1, rb.velocity.y);
    }
}
