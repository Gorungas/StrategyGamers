using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int playerNum;

    public float healDelay;
    
    private bool HealedRecently =false;
    private bool HealingNow = false;

    public bool isDead = false;

    private Animator _animator;
    private AudioSource Source;
    public AudioClip deathSound;

    public void Start()
    {
        _animator = GetComponent<Animator>();
        if (!CompareTag("Village"))
        {
            playerNum = GetComponent<PlayerNumberManager>().playerNum;
        }
        
    }

    private void Update()
    {
        if ((!CompareTag("Jugg"))&&currentHealth < maxHealth && HealingNow == false && !isDead)
        {
            StartCoroutine(Heal());
            HealingNow = true;
        }
        else if (isDead)
        {
            currentHealth = 0;
        }
    }

    public void TakeDamage(int dmg)
    {
        if (!isDead)
        {
            currentHealth -= dmg;

            if (currentHealth <= 0)
            {
                isDead = true;
                //Source.PlayOneShot(deathSound);
                _animator.SetBool("IsDead", true);
                if (CompareTag("Village"))
                {
                    Destroy(gameObject);
                }
            }
        }

    }

    public IEnumerator Heal()
    {
            if (HealedRecently == false && currentHealth < maxHealth && !isDead)
            {
                yield return new WaitForSeconds(healDelay);
                

                currentHealth++;
                HealedRecently = true;
            }
        yield return new WaitForSeconds(healDelay);
        HealedRecently = false;
        HealingNow = false;
    }
}
