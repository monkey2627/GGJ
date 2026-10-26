using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeLight : MonoBehaviour
{
    public Light blackStartLight;
    public  Slider slider;
    // Start is called before the first frame update
    void Start()
    {
       // blackStartLight = GameObject.Find("blackStartLight").GetComponent<Light>();
        slider.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        blackStartLight.intensity = slider.value * 3.32f;
    }
}
