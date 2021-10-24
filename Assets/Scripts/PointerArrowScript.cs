using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerArrowScript : MonoBehaviour
{
    public Transform target;
    public Transform king;
    public float hideDistance;
    private void Update()
    {

        var dir = target.position - king.position;

        if (dir.magnitude < hideDistance)
        {
            setChildrenActive(false);
        }
        else
        {
            setChildrenActive(true);

            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    void setChildrenActive (bool val)
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(val);
        }
    }

}
