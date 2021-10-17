using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            TakeDamage(1);
        }
    }
}
