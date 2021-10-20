using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform playerPos;
    public float t;


    private void LateUpdate()
    {
        Vector3 pos = Vector3.Lerp(transform.position, playerPos.position, t);
        pos.x = playerPos.position.x;
        pos.y = playerPos.position.y;
        pos.z = -10;
        transform.position = pos;
    }
}
