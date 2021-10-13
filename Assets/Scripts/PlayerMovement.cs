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


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hor = "Horizontal" + playerNum;
        vert = "Vertical" + playerNum;
    }


    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis(hor), Input.GetAxis(vert))  * speed;
    }
}
