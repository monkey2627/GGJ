using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicking : MonoBehaviour
{
    public static flicking instance;
    Light candle1;
    Light candle2;
    bool re = false;
    float clock = 0;
    public bool  gameStart = false;
    float candle1max = 4f;
    float candle2max = 1.04f;
    float candle2min = 0.98f;
    float candle1min = 2.8f;

    void Start()
    {
        instance = this;
        gameStart = false;
        candle1 = gameObject.transform.Find("candle").GetComponent<Light>();
        candle2 = gameObject.transform.Find("candle2").GetComponent<Light>();
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
                    float c1 = candle1max - candle1.intensity;
                    float c2 = candle2max - candle2.intensity;
                    candle1.intensity += (c1 < Time.deltaTime * 30?c1: Time.deltaTime * 30);
                    candle2.intensity += (c2 < Time.deltaTime * 30?c2 : Time.deltaTime * 30);
                    re = false;
        }
        else
        {
                    float c1 = -(candle1min - candle1.intensity);
                    float c2 = -(candle2min - candle2.intensity);
                    candle1.intensity -= (c1 < Time.deltaTime * 30 ? c1 : Time.deltaTime * 30);
                    candle2.intensity -= (c2 < Time.deltaTime * 30  ? c2 : Time.deltaTime * 30);
                    re = true;
        }


        }
        
       
        
        }
       
    }
}
