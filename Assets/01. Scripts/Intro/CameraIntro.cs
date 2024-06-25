using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIntro : MonoBehaviour
{
    float time;

    void Update()
    {
        time += Time.deltaTime;

        if (this.transform.position.y > 0)
        { 
            this.transform.position = new Vector3(0, this.transform.position.y - (Time.deltaTime), -10);
            //Debug.Log(time);
        }
    }
}
