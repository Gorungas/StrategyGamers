using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleScript : MonoBehaviour
{
    public int playerNum;
    public Transform reticle;
    public Transform king;
    private void Start()
    {
    }
    void Update()
    {
        reticle.position = king.position + new Vector3(2 * Input.GetAxis("Horizontal" + playerNum), 2 * Input.GetAxis("Vertical" + playerNum), 0);
    }
}