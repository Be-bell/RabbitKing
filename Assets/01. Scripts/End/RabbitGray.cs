using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitGray : MonoBehaviour
{
    private float z = 0f;
    // Update is called once per frame
    void Update()
    {
        z += Time.deltaTime;
        this.transform.rotation = Quaternion.Euler(0, 0, z*100);

        if(z > 2f)
        {
            this.gameObject.SetActive(false);
        }
    }
}
