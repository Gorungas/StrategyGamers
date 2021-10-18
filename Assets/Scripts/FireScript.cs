using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public GameObject arrow;
    public GameObject reticle;
    public float bulletSpeed;
    public SoilderManager manager;

    public float arrowDelay;
    public float initialArrowDelay;

    public float arrowLifetime;
    public float arrowMaxLife;

    public int dmg;

    void Start()
    {
    }

    void Update()
    {
        arrowDelay -= Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            StartCoroutine(Shoot());

        }
        
    }
    IEnumerator Shoot()
    {
        dmg = manager.soldiers.Count;

        Vector2 shotDir = new Vector2(transform.position.x - reticle.transform.position.x, transform.position.y - reticle.transform.position.y) * -1;
        float angle = Vector2.Angle(transform.forward, reticle.transform.forward);
        print(shotDir);
        if (shotDir != new Vector2(0.0f, 0.0f) && arrowDelay <= 0 && manager.soldiers.Count != 0)
        {
            GameObject newArrow = Instantiate(arrow, transform.position, Quaternion.Euler(0, 0, angle));
            newArrow.gameObject.GetComponent<Rigidbody2D>().velocity = shotDir * bulletSpeed;
            arrowDelay = initialArrowDelay;
            yield return new WaitForSeconds(arrowLifetime);
            Destroy(newArrow);
        }
        print(dmg);


        

    }
}