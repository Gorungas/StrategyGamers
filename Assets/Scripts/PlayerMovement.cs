using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerNum;

    private string hor;
    private string vert;

    public float speed;

    private Rigidbody2D rb;
    private Animator _animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hor = "Horizontal" + playerNum;
        vert = "Vertical" + playerNum;
        _animator = GetComponent<Animator>();
    }


    void Update()
    {
        Vector2 move = new Vector2(Input.GetAxis(hor), Input.GetAxis(vert))  * speed;
        _animator.SetFloat("Hor",Mathf.Abs(move.x));
        _animator.SetFloat("Ver", move.y);
        if (move.x < -0.1f)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else if(move.x>0.1f)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        rb.velocity = move;
    }
}
