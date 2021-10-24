using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingShotScript : MonoBehaviour
{
    private int playerNum;
    private string button;

    public GameObject arrow;
    public GameObject reticle;
    public float bulletSpeed;

    AudioSource source;
    public AudioClip bowShot;

    //public SoilderManager manager;
    //public List<GameObject> soldiers;

    private bool canFire = true;
    //public float initialArrowDelay;

    public float arrowLifetime;
    public float coolDown;
    public int dmg;

    //public Color arrowColor;

    public CoolDownBarScript coolDownBar;

    private PlayerMovement movement;
    private Rigidbody2D rb;


    void Start()
    {
        playerNum = GetComponent<PlayerNumberManager>().playerNum;
        movement = GetComponent<PlayerMovement>();
        button = "Jump" + playerNum;
        //soldiers = GetComponent<SoilderManager>().soldiers;
        source = FindObjectOfType<AudioSource>();
        //coolDownBar.icon.color = arrowColor;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canFire && Input.GetButton(button))
        {
            StartCoroutine(Shoot());

        }
    }
    IEnumerator Shoot()
    {
        canFire = false;
        //movement.canMove = false;
        //rb.velocity = Vector2.zero;
        source.PlayOneShot(bowShot);
        yield return new WaitForSeconds(0.3f);
        //dmg = manager.soldiers.Count;
        
        float distance = Vector2.Distance(transform.position, reticle.transform.position);
        Vector2 shotDir;
        float angle;
        if (distance != 0)
        {
            shotDir = new Vector2((transform.position.x - reticle.transform.position.x) / distance, (transform.position.y - reticle.transform.position.y) / distance) * -1;
            angle = Mathf.Atan2(shotDir.y * distance, shotDir.x * distance) * Mathf.Rad2Deg;
        }
        else
        {
            shotDir = Vector2.down;
            angle = 180;
        }
        GameObject newArrow = Instantiate(arrow, transform.position, Quaternion.Euler(0, 0, angle + 90));
        //newArrow.transform.LookAt(reticle.transform);
        //newArrow.GetComponent<SpriteRenderer>().color = arrowColor;
        newArrow.gameObject.GetComponent<Rigidbody2D>().velocity = shotDir * bulletSpeed;
        newArrow.GetComponent<ArrowScript>().SetArrow(dmg, playerNum, arrowLifetime);
        //yield return new WaitForSeconds(0.3f);
        //movement.canMove = true;
        coolDownBar.StartCoolDown(coolDown);
        yield return new WaitForSeconds(coolDown);
        canFire = true;
        //Vector2 shotDir = new Vector2(transform.position.x - reticle.transform.position.x, transform.position.y - reticle.transform.position.y) * -1;
        //float angle = Vector2.Angle(transform.forward, reticle.transform.forward);
        //if (shotDir != new Vector2(0.0f, 0.0f) && arrowDelay <= 0 && manager.soldiers.Count != 0)
        //{
        //    GameObject newArrow = Instantiate(arrow, transform.position, Quaternion.Euler(0, 0, angle));
        //    newArrow.gameObject.GetComponent<Rigidbody2D>().velocity = shotDir * bulletSpeed;
        //    arrowDelay = initialArrowDelay;
        //    yield return new WaitForSeconds(arrowLifetime);
        //    Destroy(newArrow);
        //}
    }
}
