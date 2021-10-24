using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggDash : MonoBehaviour
{
    Rigidbody2D rb;
    private string button;
    public int dmg;
    PlayerMovement player;
    public float coolDown = 5;
    public float dashSpeed = 10, dashTime = 1;
    public Transform reticle;
    private bool canDash = true,dashing=false;
    public CoolDownBarScript coolDownBar;
    public GameObject dashEffect;
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
        dashing = true;
        float distance = Vector2.Distance(transform.position, reticle.position);
        Vector2 dashDirection;
        if (distance != 0)
        {
            dashDirection = new Vector2((transform.position.x - reticle.position.x) / distance, (transform.position.y - reticle.position.y) / distance) * -1;
        }
        else { dashDirection = Vector2.down; }
        dashEffect.SetActive(true);
        float angle = Mathf.Atan2(dashDirection.y, dashDirection.x) * Mathf.Rad2Deg;
        if (transform.localScale.x > 0)
        {
            dashEffect.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            dashEffect.transform.localScale = Vector3.one;
        }
        dashEffect.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rb.velocity = dashDirection * dashSpeed*player.speed;
        //Debug.Log(rb.velocity);
        coolDownBar.StartCoolDown(coolDown + dashTime);
        yield return new WaitForSeconds(dashTime);
        player.canMove = true;
        dashing = false;
        dashEffect.SetActive(false);
        yield return new WaitForSeconds(coolDown);
        canDash = true;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (dashing)
        {
            if(collision.gameObject.CompareTag("King")|| collision.gameObject.CompareTag("Soldier"))
            {
                collision.gameObject.GetComponent<HealthManager>().TakeDamage(dmg);
            }
        }
    }
}
