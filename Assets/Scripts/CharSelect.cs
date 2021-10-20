using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class CharSelect : MonoBehaviour
{
    public int playerNum;
    private bool canMove  = true;
    private int index;
    public  Transform[] pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal")  +  playerNum > 0  && canMove)
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
        else  if  (Input.GetAxisRaw("Horizontal" + playerNum)  <  0  &&  canMove)
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
        else if(Input.GetAxisRaw("Horizontal") + playerNum ==  0 && PublicVars.characters[playerNum-1] == -1)
        {
            canMove = true;
        }

        if (Input.GetButtonDown("Jump" + playerNum))
        {
            if (PublicVars.characters[index] == playerNum)
            {
                PublicVars.characters[index] = -1;
                pos[index].gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
            else
            {
                PublicVars.characters[index] = playerNum;
                //pos[index].
            }
        }
    }
}
