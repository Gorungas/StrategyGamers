using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleScript : MonoBehaviour
{

    public Transform reticle;
    public Transform king;

    void Update()
    {
        reticle.position = king.position + new Vector3(2 * Input.GetAxis("Horizontal1"), 2 * Input.GetAxis("Vertical1"), 0);
    }
}
