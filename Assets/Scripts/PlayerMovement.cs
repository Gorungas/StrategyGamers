using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove=true;
    private bool stopMove;
    private string hor;
    private string vert;
    private string stop;
    public float speed;

    private Rigidbody2D rb;
    private Animator _animator;
    private Animator _soldierAnimator;
    public float scale = 1;

    HealthManager healthMan;

    public enum FaceDirection {Up,Down,Right };
    public FaceDirection face=FaceDirection.Down;

    void Start()
    {
        int playerNum = GetComponent<PlayerNumberManager>().playerNum;
        scale = transform.localScale.x;
        rb = GetComponent<Rigidbody2D>();
        hor = "Horizontal" + playerNum;
        vert = "Vertical" + playerNum;
        stop = "Stop" + playerNum;
        _animator = GetComponent<Animator>();
        _soldierAnimator = GetComponent<Animator>();
        healthMan = GetComponent<HealthManager>();
    }


    void Update()
    {
        if (canMove)
        {
            if (Input.GetButton(stop))
            {
                stopMove = true;
            }
            else
            {
                stopMove = false;
            }
        }
        Vector2 move = Vector2.zero;
        if ((!stopMove)&&canMove && !healthMan.isDead)
        {
            move = new Vector2(Input.GetAxis(hor), Input.GetAxis(vert)) * speed;
        }
        //move = new Vector2(Input.GetAxis(hor), Input.GetAxis(vert))  * speed;
        _animator.SetFloat("Hor",Mathf.Abs(move.x));
        _animator.SetFloat("Ver", move.y);
        _soldierAnimator.SetFloat("Hor", Mathf.Abs(move.x));
        _soldierAnimator.SetFloat("Ver", move.y);
        if (move.x < -0.1f)
        {
            transform.localScale = new Vector2(-scale, transform.localScale.y);
        }
        else if(move.x>0.1f)
        {
            transform.localScale = new Vector2(scale, transform.localScale.y);
        }
        if (move.x != 0)
        {
            face = FaceDirection.Right;
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
