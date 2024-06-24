using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Camera : MonoBehaviour
{

    public GameObject player;

    private void Update()
    {
        if(player.transform.position.y < 5f)
        {
            this.transform.position = new Vector3(0, 0f, -10);
        }

        else if(player.transform.position.y > 5f && player.transform.position.y < 15f)
        {
            this.transform.position = new Vector3(0, 10f, -10);
        }


        else if(player.transform.position.y > 15f)
        {
            this.transform.position = new Vector3(0, 20f, -10);
        }
    }
}
