using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingController : MonoBehaviour
{
    public static LightingController instance;
    public  Light pointLIght;
    public  Light spotLight;
    private float maxRange = 86.5f;
    private float maxIntensity = 0.76f;
    private float gap = 0.1f;
    private float timer = 0;
    private bool start;
    private void Awake()
    {
        instance = this;
    
    }
    // Start is called before the first frame update
    void Start() {

    }

    public IEnumerator GameStart (){
        while(pointLIght.intensity < 1f)
        {
            pointLIght.intensity +=1 * Time.deltaTime * 0.2f; 
            yield return 0;
        }
        pointLIght.intensity = 1f;
        
        }    
    public void StartLighting()
    {
        StartCoroutine(GameStart());
    }
    // Update is called once per frame

}
