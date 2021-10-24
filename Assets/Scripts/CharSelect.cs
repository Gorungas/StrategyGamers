using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class CharSelect : MonoBehaviour
{
    public int playerNum;
    public Transform[] pos;
    private int index = 0;
    private bool canMove = true;

    void Start()
    {
        index = playerNum - 1;
        transform.position = pos[index].position;
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal" + playerNum) > 0 && canMove)
        {
            do
            {
                index++;
                index %= pos.Length;
            }
            while (PublicVars.characters.Contains(index));

            transform.position = pos[index].position;
            canMove = false;
        }
        else if (Input.GetAxisRaw("Horizontal" + playerNum) < 0 && canMove)
        {
            do
            {
                index--;
                index = (index + pos.Length) % pos.Length;
            }
            while (PublicVars.characters.Contains(index));

            transform.position = pos[index].position;
            canMove = false;
        }
        else if (Input.GetAxisRaw("Horizontal" + playerNum) == 0 && PublicVars.characters[playerNum - 1] == -1)
        {
            canMove = true;
        }

        if (Input.GetButtonDown("Attack" + playerNum))
        {
            if (PublicVars.characters[index] == playerNum)
            {
                PublicVars.characters[index] = -1;
                pos[index].gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
            else
            {
                PublicVars.characters[index] = playerNum;
                pos[index].gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
                canMove = false;

                print("player" + PublicVars.characters[index] + " is " + index);
                if (!PublicVars.characters.Contains(-1))
                {
                    SceneManager.LoadScene("SampleScene");
                }

            }
        }
    }
}
