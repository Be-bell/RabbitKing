using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnd : MonoBehaviour
{
    public GameObject[] images;
    public GameObject[] rabbits;
    public GameObject textMeshProUGUI;

    private Vector2 target = new Vector2(0, 3.75f);
    private Vector2 velo = new Vector2(0, 0f);

    void Update()
    {
        this.transform.position = Vector2.SmoothDamp(this.transform.position, target, ref velo, 1.5f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ImageOnOff());
    }

    IEnumerator ImageOnOff()
    {
        for(int i = 0; i < images.Length; i++)
        {
            float timer = 0f;
            while (timer < 1f)
            {
                images[i].gameObject.SetActive(true);
                timer += Time.deltaTime;
                yield return null;
            }

            images[i].gameObject.SetActive(false);
        }

        rabbits[0].gameObject.SetActive(false);
        rabbits[1].gameObject.SetActive(true);
        rabbits[2].gameObject.SetActive(true);
        textMeshProUGUI.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
