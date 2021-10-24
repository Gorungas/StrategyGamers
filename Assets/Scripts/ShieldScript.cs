using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public GameObject shield;
    private string button;
    public float duration,coolDown;
    private bool canShield = true;
    public CoolDownBarScript coolDownBar;
    // Start is called before the first frame update
    void Start()
    {
        button = "Jump" + GetComponent<PlayerNumberManager>().playerNum;
    }

    // Update is called once per frame
    void Update()
    {
        shield.transform.position = transform.position;
        if (canShield && Input.GetButton(button))
        {
            StartCoroutine(Shield());
        }
    }
    IEnumerator Shield()
    {
        canShield = false;
        shield.SetActive(true);
        yield return new WaitForSeconds(duration);
        coolDownBar.StartCoolDown(coolDown);
        shield.SetActive(false);
        yield return new WaitForSeconds(coolDown);
        canShield = true;
    }
}
