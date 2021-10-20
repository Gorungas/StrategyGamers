using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleScript : MonoBehaviour
{
    public int playerNum;
    public Transform reticle;
    public Transform king;
    private HealthManager healthMan;

    private void Start()
    {
        healthMan = GetComponent<HealthManager>();
    }
    void Update()
    {
        if (!healthMan.isDead)
            reticle.position = king.position + new Vector3(3 * Input.GetAxis("Horizontal" + playerNum), 3 * Input.GetAxis("Vertical" + playerNum), 0);
        else if (healthMan.isDead)
        {
            reticle.gameObject.SetActive(false);
        }
    }
}
