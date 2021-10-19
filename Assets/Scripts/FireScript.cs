using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    private int playerNum;
    private string button;

    public GameObject arrow;
    public GameObject reticle;
    public float bulletSpeed;
    //public SoilderManager manager;
    public List<GameObject> soldiers;

    private bool canFire = true;
    //public float initialArrowDelay;

    public float arrowLifetime;

    public float coolDown;

    public int dmg;
    void Start()
    {
        playerNum = GetComponent<PlayerNumberManager>().playerNum;
        button = "Fire" + playerNum;
        soldiers = GetComponent<SoilderManager>().soldiers;
    }

    void Update()
    {
        if (canFire&&Input.GetButton(button))
        {
            StartCoroutine(Shoot());

        }     
    }
    IEnumerator Shoot()
    {
        canFire = false;
        //dmg = manager.soldiers.Count;
        foreach (GameObject soldier in soldiers) {
            float distance = Vector2.Distance(soldier.transform.position, reticle.transform.position);
            Vector2 shotDir = new Vector2((soldier.transform.position.x - reticle.transform.position.x)/distance, (soldier.transform.position.y - reticle.transform.position.y)/distance) * -1;
            float angle = Mathf.Atan2(shotDir.y*distance, shotDir.x*distance) * Mathf.Rad2Deg;
            //Debug.Log(shotDir);
            //Debug.Log(angle);
            if (shotDir != new Vector2(0.0f, 0.0f))
            {
                GameObject newArrow = Instantiate(arrow, soldier.transform.position, Quaternion.Euler(0,0,angle+90));
                //newArrow.transform.LookAt(reticle.transform);
                newArrow.gameObject.GetComponent<Rigidbody2D>().velocity = shotDir * bulletSpeed;
                newArrow.GetComponent<ArrowScript>().SetArrow(dmg,playerNum, arrowLifetime);
            }
        }
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