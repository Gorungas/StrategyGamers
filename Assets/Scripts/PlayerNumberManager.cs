using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNumberManager : MonoBehaviour
{
    public int playerNum;
    public int charIndex;
    // Start is called before the first frame update
    void Awake()
    {
        if (PublicVars.characters[charIndex]!=-1)
        {
            playerNum = PublicVars.characters[charIndex];
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
