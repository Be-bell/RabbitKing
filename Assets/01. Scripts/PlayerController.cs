using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer renderer;
    private Animator animator;

    public int jumpPower = 10;
    public int moveSpeed = 2;
    public int xSpeed = 5;


    public bool isCharging = false;
    public bool isGround = false;
    public bool isJumping = false;

    public bool standing = false;
    public float stand = 0f;
    private bool flag = false;

    private Vector2 value;

    public float timer = 0f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isCharging)
        {
            timer += Time.deltaTime;
        }

        if (standing)
        {
            stand += Time.deltaTime;

            if (stand >= 2f)
            {
                animator.SetBool("IsDown", false);
                standing = false;
                stand = 0f;
            }
        }

    }

    private void FixedUpdate()
    {


        if (!isCharging && isGround && !isJumping && !animator.GetBool("IsDown"))
        {
            rb.velocity = new Vector2(value.x * moveSpeed, rb.velocity.y);
            animator.SetBool("IsDown", false);

            if (rb.velocity.x != 0)
            {
                animator.SetBool("IsIdle", false);
                animator.SetBool("IsWalk", true);
            }

            else
            {
                animator.SetBool("IsIdle", true);
                animator.SetBool("IsWalk", false);
            }
        }

        if (rb.velocity.y < 0)
        {
            animator.SetBool("IsFall", true);
        }

        else animator.SetBool("IsFall", false);

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        value = context.ReadValue<Vector2>();
        if (!isCharging && isGround && !isJumping && !standing && context.action.phase == InputActionPhase.Started)
        {
            renderer.flipX = value.x == 1f;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {

        if (isJumping)
        {
            return;
        }

        if (isGround)
        {
            animator.SetBool("IsCharging", true);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsWalk", false);
            isCharging = true;
            rb.velocity = new Vector2(0, rb.velocity.y);

            if (context.action.phase == InputActionPhase.Canceled || context.action.phase == InputActionPhase.Performed)
            {
                animator.SetBool("IsCharging", false);
                Jump();
                animator.SetBool("IsJump", true);
            }
        }
    }


    public void Jump()
    {
        Vector2 test = Vector2.right * value.x * xSpeed + Vector2.up * jumpPower * (timer > 1f ? 1f : timer);

        flag = test.y >= 10f;

        rb.AddForce(test, ForceMode2D.Impulse);


        isJumping = true;
        isCharging = false;

        //Debug.Log(rb.velocity);
        timer = 0f;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            isJumping = false;
            animator.SetBool("IsJump", false);

            if (flag)
            {
                animator.SetBool("IsDown", true);
                standing = true;
            }
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene((int)Scene.END);
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
