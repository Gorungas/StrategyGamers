using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownBarScript : MonoBehaviour
{
    Slider slider;
    public Image icon;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value>0)
        {
            slider.value -= Time.deltaTime;
        }
    }
    public void StartCoolDown(float time)
    {
        slider.maxValue = time;
        slider.value = time;
    }
}
