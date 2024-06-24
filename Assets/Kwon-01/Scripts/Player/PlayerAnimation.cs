using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private PlayerMove playerMove;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void FixedUpdate()
    {
        FilpX();
        Anim_Walk();
        Anim_Charging();
        Anim_Down();
        Anim_Fall();
    }

    public void Anim_Walk()
    {
        if (playerMove.readVelocity.x != 0)
        {
            animator.SetBool("Walk", true);
        }

        else animator.SetBool("Walk", false);
    }

    public void Anim_Charging()
    {
        if (playerMove.isCharging)
        {
            animator.SetBool("Charging", true);
        }

        else animator.SetBool("Charging", false);
    }

    private void Anim_Fall()
    {
        if (playerMove.readVelocity.y < -0.1)
        {
            animator.SetBool("Fall", true);
        }

        else animator.SetBool("Fall", false);
    }

    private void Anim_Down()
    {
        if (playerMove.readVelocity.y < -14f)
        {
            animator.SetBool("Down", true);
            playerMove.isDown = true;
        }

        if (!animator.GetBool("Fall") && animator.GetBool("Down"))
        {
            animator.SetBool("Down", false);
        }
    }

    private void FilpX()
    {
        if (playerMove.readVelocity.x >= 1)
        {
            spriteRenderer.flipX = true;
        }

        else if (playerMove.readVelocity.x <= -1)
        {
            spriteRenderer.flipX = false;
        }
    }
}
