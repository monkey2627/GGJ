using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingController : MonoBehaviour
{
    private Light light;
    private float maxRange = 86.5f;
    private float maxIntensity = 0.76f;
    private float gap = 0.1f;
    private float timer = 0;
    private bool start;
    // Start is called before the first frame update
    void Start(){
        light = gameObject.GetComponent<Light>();
        light.intensity = 0.2f;
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            timer += Time.deltaTime;
                    if(timer > gap)
                    {
                        if ( light.range < maxRange)
                        {
                            light.range += 10f;
                        }
                        if( light.intensity < maxIntensity)
                        {
                            light.intensity += 0.01f;
                        }
                        timer = 0;

                    }
        }
        

    }
    public void StartLight()
    {
        start = true;
    }
}
