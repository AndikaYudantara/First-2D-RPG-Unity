using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Player player;
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 0, -10);
    }
}
