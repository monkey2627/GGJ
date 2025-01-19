using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleEvent : MonoBehaviour
{
    public void ClickBubble()//µã»÷ÆøÅÝ
    {
        AkSoundEngine.PostEvent("Object_Bubble_Tap", gameObject);
        AkSoundEngine.PostEvent("Object_Bubble_Burst", gameObject);
    }
}
