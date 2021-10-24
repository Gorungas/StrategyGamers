using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    //public Color[] colors;
    public int playerNum;
    public int damage;

    AudioSource Source;
    public AudioClip Hitsound;
    public bool destroyAfterHit=true;
    // Start is called before the first frame update
    void Start()
    {
        Source = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetArrow(int dmg, int playerNum, float lifeTime)
    {
        Destroy(gameObject,lifeTime);
        damage = dmg;
        this.playerNum = playerNum;
        //GetComponent<SpriteRenderer>().color = colors[playerNum-1];

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugg") || collision.CompareTag("Soldier") || collision.CompareTag("King"))
        {
            if (collision.GetComponent<PlayerNumberManager>().playerNum != playerNum && !collision.GetComponent<HealthManager>().isDead)
            {
                collision.GetComponent<HealthManager>().TakeDamage(damage);
                Source.PlayOneShot(Hitsound);
                if (destroyAfterHit)
                {
                    Destroy(gameObject);
                }
            }
        }
        if (collision.CompareTag("Village")|| collision.CompareTag("Shield"))
        {
            Source.PlayOneShot(Hitsound);
            Destroy(gameObject);
        }
    }
    
}
