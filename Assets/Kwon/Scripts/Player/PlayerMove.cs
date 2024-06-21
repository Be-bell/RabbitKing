using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 jumpVector;
    public Vector2 readVelocity;

    public float jumpPower = 10;
    public float moveSpeed = 3;


    public float moveX;
    public float xSpeed = 5;

    public bool isGround;
    public bool isCharging;

    public bool isDown;

    public float jumpWeights;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isCharging)
        {
            jumpWeights += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (isGround)
        {
            if (isCharging)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

            else
            {
                rb.velocity = new Vector2(moveX, rb.velocity.y);
            }
        }

        readVelocity = rb.velocity;
    }

    public void GetX(float getX)
    {
        moveX = getX * moveSpeed;
        isDown = false;
    }

    public void Jump()
    {
        jumpVector = Vector2.right * moveX * xSpeed + Vector2.up * jumpPower * (jumpWeights > 1f ? 1f : jumpWeights);
        rb.AddForce(jumpVector, ForceMode2D.Impulse);
        isCharging = false;
    }
}
