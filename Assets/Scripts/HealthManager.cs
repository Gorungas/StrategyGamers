using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public FireScript arrows1;
    public FireScript arrows2;
    public FireScript arrows3;

    public void TakeDamage(int dmg)
    {
        if (currentHealth != 0)
            currentHealth -= dmg;

        else if (currentHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Heal(int hp)
    {
        if (currentHealth != maxHealth)
            currentHealth += hp;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrow"))
        {
            TakeDamage(arrows1.dmg);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Arrow2"))
        {
            TakeDamage(arrows2.dmg);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Arrow3"))
        {
            TakeDamage(arrows3.dmg);
            Destroy(other.gameObject);
        }
    }
}
