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
        reticle.position = king.position + new Vector3(3 * Input.GetAxis("Horizontal" + playerNum), 3 * Input.GetAxis("Vertical" + playerNum), 0);
    }
}
