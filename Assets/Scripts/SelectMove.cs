using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class SelectMove : MonoBehaviour
{
    public int playerNum;
    public Transform[] pos;
    private int index = 0;
    private bool canMove = true,selected=false;

    void Start()
    {
        index = playerNum - 1;
        transform.position = pos[index].position;
        PublicVars.characters = new int[4] { -1, -1, -1, -1 };
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal" + playerNum) > 0 && canMove&&!selected)
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
        else if (Input.GetAxisRaw("Horizontal" + playerNum) < 0 && canMove && !selected)
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
        else if (Input.GetAxisRaw("Horizontal" + playerNum) == 0 && !selected)
        {
            canMove = true;
        }

        if (Input.GetButtonDown("Jump" + playerNum)|| Input.GetButtonDown("Attack" + playerNum))
        {
            if (PublicVars.characters[index] == playerNum)
            {
                PublicVars.characters[index] = -1;
                pos[index].gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                selected = false;
            }
            else
            {
                PublicVars.characters[index] = playerNum;
                pos[index].gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
                selected = true;

                print("player" + PublicVars.characters[index] + " is " + index);
                if (!PublicVars.characters.Contains(-1))
                {
                    SceneManager.LoadScene(2);
                }

            }
        }
        
    }
    public void changeScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
