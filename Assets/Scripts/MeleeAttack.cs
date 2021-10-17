using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public int playerNum;
    private string button;
    private PlayerMovement movement;
    //public SpriteRenderer sr;
    //public Sprite attackSprite;
    //Sprite idleSprite;

    public float duration;
    public bool canAtt = true;
    public Vector2 attackSize;
    public LayerMask attckObj;
    public int attVal;
    public Vector2 attForce;
    //AudioSource audioSource;
    //public AudioClip attClip;
    //public AudioClip hitClip;
    public float coolDown;
    public GameObject[] attEffects;
    //public Sprite coolSprite;
    // Start is called before the first frame update
    void Start()
    {
        //idleSprite = sr.sprite;
        //audioSource = GetComponent<AudioSource>();
        button = "Attack" + playerNum;
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canAtt & Input.GetButtonDown(button))
        {
            canAtt = false;
            //audioSource.PlayOneShot(attClip);
            
            StartCoroutine(Attack());
            //Debug.Log("start");
        }
    }
    IEnumerator Attack()
    {
        //sr.sprite = attackSprite;

        //for(float i=0; i < duration; i+=Time.deltaTime)
        //{
        //    yield return null;
        //}
        PlayerMovement.FaceDirection face = movement.face;
        int direction = ((int)face);
        if (attEffects[direction] != null)
        {
            attEffects[direction].SetActive(true);
        }
        DetectAttack(direction);
        yield return new WaitForSeconds(duration);
        if (attEffects[direction] != null)
        {
            attEffects[direction].SetActive(false);
        }
        //Debug.Log("end");
        //if (coolSprite != null)
        //{
        //    sr.sprite = coolSprite;
        //}
        //else { sr.sprite = idleSprite; }
        yield return new WaitForSeconds(coolDown);
        //sr.sprite = idleSprite;
        canAtt = true;
    }
    public void DetectAttack(int direction)
    {
        float angle = 0;
        if (direction == 2) { angle = 90; }
        Collider2D[] enemys = Physics2D.OverlapBoxAll(attEffects[direction].transform.position, attackSize, angle, attckObj);
        //Debug.Log(enemys);
        foreach (Collider2D enemy in enemys)
        {
            float xPos = enemy.transform.position.x - transform.position.x;
            xPos = Mathf.Sign(xPos);
            Vector2 force = new Vector2(attForce.x * xPos, attForce.y);
            enemy.GetComponent<HealthManager>().TakeDamage(attVal);
            //audioSource.PlayOneShot(hitClip);
        }
    }
}
