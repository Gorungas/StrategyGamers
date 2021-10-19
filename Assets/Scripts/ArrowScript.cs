using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public Color[] colors;
    public int playerNum;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
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
        GetComponent<SpriteRenderer>().color = colors[playerNum-1];

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugg")||collision.CompareTag("Soldier")|| collision.CompareTag("King"))
        {
            if (collision.GetComponent<PlayerNumberManager>().playerNum != playerNum)
            {
                collision.GetComponent<HealthManager>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
