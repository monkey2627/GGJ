using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanelLightingController : MonoBehaviour
{
    public static StartPanelLightingController instance;
    public  Light PointLight;
    public Light gameStartBackLight;
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
        while(PointLight.intensity > 0f)
        {
            PointLight.intensity -=1 * Time.deltaTime * 0.2f; 
            yield return 0;
        }
        PointLight.intensity = 0;

    }
    public IEnumerator solveGameStartBackLight()
    {
        while (gameStartBackLight.intensity > 0f)
        {
            gameStartBackLight.intensity -= 1 * Time.deltaTime * 0.2f / 2.0f * 2.77f;
            yield return 0;
        }
        gameStartBackLight.intensity = 0;

    }
    public void StartLighting()
    {
        StartCoroutine(GameStart());
        //¿ªÊ¼ÉÁ
        flicking.instance.gameStart = true;
    }
    // Update is called once per frame

}
