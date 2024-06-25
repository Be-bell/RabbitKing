using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerEnd : MonoBehaviour
{
    public GameObject[] images;
    public GameObject[] rabbits;
    public GameObject textMeshProUGUI;
    public GameObject Ending;

    private Vector2 target = new Vector2(0, 3.75f);
    private Vector2 velo = new Vector2(0, 0f);

    void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, target, ref velo, 1.5f);
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
        Ending.SetActive(true);
        gameObject.SetActive(false);

    }

    
}
