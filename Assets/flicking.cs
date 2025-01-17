using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicking : MonoBehaviour
{
    Light light;
    bool re = false;
    float clock = 0;
    float intensity = 0.2f;
    public bool  gameStart = false;
    //.改，要限定最大最小值
    // Start is called before the first frame update
    void Start()
    {
        gameStart = false;
        light = gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
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
}
