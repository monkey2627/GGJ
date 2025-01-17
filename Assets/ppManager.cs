using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ppManager : MonoBehaviour
{
    public static ppManager instance;
    public Light blackStartLight;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public IEnumerator gamestart(float speed)
    {
        while (gameObject.GetComponent<PostProcessVolume>().profile.GetSetting<ColorGrading>().saturation.value < 0 || gameObject.GetComponent<PostProcessVolume>().profile.GetSetting<ColorGrading>().hueShift.value > 0 || gameObject.GetComponent<PostProcessVolume>().profile.GetSetting<ColorGrading>().contrast.value > 0)
        {
            if(gameObject.GetComponent<PostProcessVolume>().profile.GetSetting<ColorGrading>().saturation.value < 0)
            {
                blackStartLight.intensity -= Time.deltaTime;
                gameObject.GetComponent<PostProcessVolume>().profile.GetSetting<ColorGrading>().saturation.value += Time.deltaTime * speed;
                gameObject.GetComponent<PostProcessVolume>().profile.GetSetting<ChromaticAberration>().intensity.value -= Time.deltaTime * speed / 100;
            }
       
            if (gameObject.GetComponent<PostProcessVolume>().profile.GetSetting<ColorGrading>().hueShift.value > 0)
                gameObject.GetComponent<PostProcessVolume>().profile.GetSetting<ColorGrading>().hueShift.value -= Time.deltaTime * speed * 2.5f;
            if(gameObject.GetComponent<PostProcessVolume>().profile.GetSetting<ColorGrading>().contrast.value > 0)
            {
                gameObject.GetComponent<PostProcessVolume>().profile.GetSetting<ColorGrading>().contrast.value -= Time.deltaTime * speed * 2.5f;
            }
            yield return 0;
        }
        gameObject.GetComponent<PostProcessVolume>().profile.GetSetting<ColorGrading>().contrast.value = 0;
        gameObject.GetComponent<PostProcessVolume>().profile.GetSetting<ColorGrading>().saturation.value = 0;
        gameObject.GetComponent<PostProcessVolume>().profile.GetSetting<ColorGrading>().hueShift.value = 0;
        gameObject.GetComponent<PostProcessVolume>().profile.GetSetting<ChromaticAberration>().active = false;
        blackStartLight.intensity = 0;
        //¿ªµÆ

    }
    public void GAMEStart()
    {
        StartCoroutine(gamestart(40f));
     
    }
}
