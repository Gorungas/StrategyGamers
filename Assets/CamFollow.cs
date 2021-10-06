using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform playerPos;


    private void LateUpdate()
    {
        Vector2 pos = transform.position;
        pos.x = playerPos.position.x;
        pos.y = playerPos.position.y;
        transform.position = pos;
    }
}
