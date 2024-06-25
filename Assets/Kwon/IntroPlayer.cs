using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroPlayer : MonoBehaviour
{
    public Sprite sprite;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    private float timer = 0f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }


    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > 48f)
        {
           rb.gravityScale = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRenderer.sprite = sprite;
    }
}
