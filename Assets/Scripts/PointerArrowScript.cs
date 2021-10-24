using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerArrowScript : MonoBehaviour
{
    public Transform target;
    public Transform king;
    private void Update()
    {

        var dir = target.position - king.position;

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
