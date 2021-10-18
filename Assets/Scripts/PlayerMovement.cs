using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private string hor;
    private string vert;

    public float speed;

    private Rigidbody2D rb;
    private Animator _animator;


    public enum FaceDirection {Up,Down,Right };
    public FaceDirection face=FaceDirection.Down;
    void Start()
    {
        int playerNum = GetComponent<PlayerNumberManager>().playerNum;
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
        face = FaceDirection.Right;
        if (move.y > 0)
        {
            face = FaceDirection.Up;
        }
        else if(move.y < 0)
        {
            face = FaceDirection.Down;
        }
        rb.velocity = move;
    }
}
