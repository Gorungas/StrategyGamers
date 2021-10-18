using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int playerNum;
    public FireScript arrows1;
    public FireScript arrows2;
    public FireScript arrows3;

    public float healDelay;
    
    private bool HealedRecently;
    private bool HealingNow;

    public void Start()
    {
        playerNum = GetComponent<PlayerNumberManager>().playerNum;
    }

    private void Update()
    {
        if (currentHealth < maxHealth && HealingNow == false)
        {
            StartCoroutine(Heal());
            HealingNow = true;
        }
    }

    public void TakeDamage(int dmg)
    {
        if (currentHealth != 0)
            currentHealth -= dmg;

        else if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public IEnumerator Heal()
    {
        while (currentHealth < maxHealth)
        {
            if (HealedRecently == false && currentHealth < maxHealth)
            {
                currentHealth++;
                HealedRecently = true;
            }

            yield return new WaitForSeconds(healDelay);
            HealedRecently = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrow") && playerNum != 1)
        {
            TakeDamage(arrows1.dmg);
            Destroy(other.gameObject);

        }
        else if (other.CompareTag("Arrow2") && playerNum != 2)
        {
            TakeDamage(arrows2.dmg);
            Destroy(other.gameObject);


        }
        else if (other.CompareTag("Arrow3") && playerNum != 3)
        {
            TakeDamage(arrows3.dmg);
            Destroy(other.gameObject);


        }
    }
}
