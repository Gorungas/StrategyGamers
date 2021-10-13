using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderScript : MonoBehaviour
{
    //attack
    //health
    public GameObject arrow;
    public GameObject reticle;
    //animation


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            this.transform.LookAt(reticle.transform.position);
            arrow = Instantiate(arrow, this.transform.forward, Quaternion.identity);
            arrow.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 10));
        }
    }
}
