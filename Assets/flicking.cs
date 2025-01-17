using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicking : MonoBehaviour
{
    Light light;
    bool re = false;
    float clock = 0;
    float intensity = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;
        if(clock > 0.4)
        {
            clock = 0;
if (re)
        {
         light.intensity += Time.time * intensity;
                light.range += Time.time * intensity;
        re = false;
        }
        else
        {
            light.intensity -= Time.time * intensity;
            light.range -= Time.time * intensity;
            re = true;
        }


        }
        
       
        
    }
}
