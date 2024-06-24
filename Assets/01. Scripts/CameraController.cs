using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    private void Update()
    {
        // 현재 위치를 저장
        Vector3 currentPosition = this.transform.position;

        // Stage Forest
        if (Player.transform.position.y < 5)
        {
            // Stage Forest 1
            this.transform.position = new Vector3(0, 0, -10);
        }
        else if (Player.transform.position.y >= 5 && Player.transform.position.y < 15)
        {
            // Stage Forest 2
            this.transform.position = new Vector3(0, 10, -10);
        }
        else if (Player.transform.position.y >= 15 && Player.transform.position.y < 25)
        {
            // Stage Forest 3
            this.transform.position = new Vector3(0, 20, -10);
        }
        else if (Player.transform.position.y >= 25 && Player.transform.position.y < 35)
        {
            // Stage Sky 1
            this.transform.position = new Vector3(0, 30, -10);
        }
        else if (Player.transform.position.y >= 35 && Player.transform.position.y < 45)
        {
            // Stage Sky 2
            this.transform.position = new Vector3(0, 40, -10);
        }
        else if (Player.transform.position.y >= 45 && Player.transform.position.y < 55)
        {
            // Stage Sky 3
            this.transform.position = new Vector3(0, 50, -10);
        }
        else if (Player.transform.position.y >= 55 && Player.transform.position.y < 65)
        {
            // Stage Sky End
            this.transform.position = new Vector3(0, 60, -10);
        }
    }
}
