using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rb;

    public int jumpPower = 5;
    public int moveSpeed = 2;
    public int xSpeed = 5;


    public bool isCharging = false;
    public bool isGround = false;
    public bool isJumping = false;

    private Vector2 value;
    private Vector2 tmp;

    public float timer = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    private void Update()
    {
        if (isCharging)
        {
            timer += Time.deltaTime;
        }
    }


    private void FixedUpdate()
    {
        if (!isCharging && isGround && !isJumping)
        {
            rb.velocity = new Vector2(value.x * moveSpeed, rb.velocity.y);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        value = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (isGround)
        {
            isCharging = true;
            rb.velocity = new Vector2(0, rb.velocity.y);

            if (context.action.phase == InputActionPhase.Canceled || context.action.phase == InputActionPhase.Performed)
            {
                Jump();
            }
        }
    }


    public void Jump()
    {
        tmp = Vector2.right * value.x * xSpeed + Vector2.up * jumpPower * (timer > 1f ? 1f : timer);
        rb.AddForce(tmp, ForceMode2D.Impulse);

        isJumping = true;
        isCharging = false;

        Debug.Log(rb.velocity); // È®ÀÎ¿ë 
        timer = 0f;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
