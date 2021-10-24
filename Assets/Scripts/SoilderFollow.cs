using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilderFollow : MonoBehaviour
{
    public Transform followPos;
    public float speed;
    public bool isFollowing;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            float distance = Vector2.Distance(transform.position,followPos.position);
            float lerpVal = speed * Time.deltaTime / distance;
            Vector2 move = followPos.position - transform.position;
            if (distance < 0.05)
            {
                _animator.SetBool("Idle", true);
            }
            else
            {
                _animator.SetBool("Idle", false);
                _animator.SetFloat("Hor",move.x);
                _animator.SetFloat("Vert", move.y);
            }
            transform.position = Vector2.Lerp(transform.position,followPos.position,lerpVal);
        }
    }
}
