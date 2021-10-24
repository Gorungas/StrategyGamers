using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public int sum;
    void Update()
    {
        sum = PublicVars.livingCharacters.Sum();

        if (sum == 1)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
