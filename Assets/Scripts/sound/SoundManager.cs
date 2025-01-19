using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    float  u= 0;
    private void Start()
    {
        
        //填事件名字就
        AkSoundEngine.PostEvent("Ambient_HouseMoan_Play", gameObject);
        //AkSoundEngine.PostEvent("Ambient_HouseMoan_Stop", gameObject);
    }
    public void PlaySound(string soundName, float m_SoundVolume)
    {
        //sound = 
      //  sound.Post(gameObject);
      
    }
    private void Update()
    {
        u += Time.deltaTime;
        AkSoundEngine.SetRTPCValue("Whole_Volume", u*10);
        
    }



}
