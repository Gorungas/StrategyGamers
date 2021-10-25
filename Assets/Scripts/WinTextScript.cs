using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinTextScript : MonoBehaviour
{
    public Text text;
    private void Awake()
    {
        text.text = "Player " + (PublicVars.livingCharacters.IndexOf(1) + 1) + " Wins!"; 
    }

    public void Restart()
    {
        SceneManager.LoadScene("StartScreen");

    }

   

}
