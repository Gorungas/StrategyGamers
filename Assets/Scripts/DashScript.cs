using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    private int playerNum;
    private string button;
    Rigidbody2D rb;
    public float cooldDown;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        button = "Dash" + playerNum;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(button))
        {
            
        }
    }
    IEnumerator Dash()
    {
        yield return null;
    }
}
