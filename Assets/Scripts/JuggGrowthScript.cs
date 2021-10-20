using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggGrowthScript : MonoBehaviour
{
    public int level;
    public float scaleGrowth;
    public float speedGrowth;
    private PlayerMovement playerMovement;
    private MeleeAttack melee;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        melee = GetComponent<MeleeAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelUp()
    {
        level+=1;
        playerMovement.scale += scaleGrowth;
        transform.localScale += new Vector3(0, scaleGrowth,0);
        melee.attVal = 3+level/3;
        playerMovement.speed+=speedGrowth;
    }
}
