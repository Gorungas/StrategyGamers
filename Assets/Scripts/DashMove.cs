using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{
    Rigidbody2D rb;
    private string button;
    PlayerMovement player;
    public float coolDown=5;
    public float dashSpeed=10, dashTime=1;
    public Transform reticle;
    private bool canDash=true;
    public CoolDownBarScript coolDownBar;
    // Start is called before the first frame update
    void Start()
    {
        int playerNum = GetComponent<PlayerNumberManager>().playerNum;
        rb = GetComponent<Rigidbody2D>();
        button = "Jump" + playerNum;
        player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canDash && player.canMove && Input.GetButtonDown(button))
        {
            StartCoroutine(Dash());
        }
    }
    IEnumerator Dash()
    {
        canDash = false;
        player.canMove = false;
        float distance = Vector2.Distance(transform.position, reticle.position);
        Vector2 dashDirection = new Vector2((transform.position.x - reticle.position.x) / distance, (transform.position.y - reticle.position.y) / distance) * -1;
        rb.velocity = dashDirection * dashSpeed;
        Debug.Log(rb.velocity);
        coolDownBar.StartCoolDown(coolDown+dashTime);
        yield return new WaitForSeconds(dashTime);
        player.canMove = true;
        yield return new WaitForSeconds(coolDown);
        canDash = true;
    }
}
