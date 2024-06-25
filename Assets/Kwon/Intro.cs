using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public Image[] image;
    public TextMeshProUGUI[] text;

    private void Awake()
    {
        for(int i = 0; i < image.Length; i++)
        {
            image[i].color = new Color(image[i].color.r, image[i].color.g, image[i].color.b, 0);
            text[i].color = new Color(text[i].color.r, text[i].color.g, text[i].color.b, 0);
        }
    }


    private void Start()
    { 
        StartCoroutine(FadeInOut(3f, image, text));
    }


   

    private IEnumerator FadeInOut(float time, Image[] image, TextMeshProUGUI[] text)
    {
        float timer = 0f;

        while(timer < 2f)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        

        for (int i = 0; i < image.Length; i++)
        {
            timer = 0f;

            while (image[i].color.a < 1f)
            {
                image[i].color = new Color(image[i].color.r, image[i].color.g, image[i].color.b, image[i].color.a + (Time.deltaTime / time));
                text[i].color = new Color(text[i].color.r, text[i].color.g, text[i].color.b, text[i].color.a + (Time.deltaTime / time));
                yield return null;
            }

            while (timer < 5f)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            timer = 0f;

            while (image[i].color.a > 0f)
            {
                image[i].color = new Color(image[i].color.r, image[i].color.g, image[i].color.b, image[i].color.a - (Time.deltaTime / time));
                text[i].color = new Color(text[i].color.r, text[i].color.g, text[i].color.b, text[i].color.a - (Time.deltaTime / time));
                yield return null;
            }

            while (timer < 1f)
            {
                timer += Time.deltaTime;
                yield return null;
            }
        }
    }

}
