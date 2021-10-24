using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilderFollow : MonoBehaviour
{
    public Transform followPos;
    public float speed;
    public bool isFollowing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            float distance = Vector2.Distance(transform.position,followPos.position);
            float lerpVal = speed * Time.deltaTime / distance;
            transform.position = Vector2.Lerp(transform.position,followPos.position,lerpVal);
        }
    }
}
