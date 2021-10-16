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

    void Start()
    {
    }

    void Update()
    {
        if (arrowDelay > 0)
        {
            arrowDelay -= Time.deltaTime;
            print(arrowDelay);
        }
        if (Input.GetButton("Fire1"))
        {
            foreach(GameObject soldier in manager.soldiers)
            {
                if (arrowDelay <= 0)
                {
                    soldier.transform.LookAt(reticle.transform.position);
                    arrow = Instantiate(arrow, soldier.transform.position, Quaternion.identity);
                    
                    arrowDelay = initialArrowDelay;
                }
                arrow.gameObject.GetComponent<Rigidbody2D>().velocity = transform.forward * bulletSpeed;
            }
            }
        
    }
}
