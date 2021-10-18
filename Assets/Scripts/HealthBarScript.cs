using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarScript : MonoBehaviour
{
    Slider bar;
    public HealthManager health;
    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Slider>();
        bar.maxValue = health.maxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bar.value = health.currentHealth;
    }
}
