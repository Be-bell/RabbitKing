using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroPlayer : MonoBehaviour
{
    public Sprite sprite;
    public TextMeshProUGUI skipTxt;
    public TextMeshProUGUI startTxt;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    private float timer = 0f;
    private bool trigger = false;

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

        if(trigger && timer > 2f)
        {
            skipTxt.gameObject.SetActive(false);
            startTxt.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRenderer.sprite = sprite;
        trigger = true;
        timer = 0f;
    }
}
