using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggGrowthScript : MonoBehaviour
{
    public int level;
    public float scaleGrowth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelUp()
    {
        level+=1;
        transform.localScale+=scaleGrowth;

    }
}
