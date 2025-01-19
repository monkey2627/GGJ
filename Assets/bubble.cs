using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bubble : MonoBehaviour
{
    // Start is called before the first frame update
    public float x;
    public float y;
    public bool gameStart = false;
    
    //随机数
    private static readonly System.Random ra = new System.Random(unchecked((int)DateTime.Now.Ticks));
    void Start()
    {
        
    }
    float getAlpha()
    {
        return ra.Next(0,255);
    }
    float getSize()
    {
        return (float)ra.NextDouble();
    }
    Vector2 getPos()
    {
        return new Vector2((float)ra.NextDouble()*x,(float)ra.NextDouble()*y);
    }
    float generateTime = 0;
    float max_ = 1;
    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            generateTime += Time.deltaTime;
            if (generateTime > max_)
            {

                GameManager.instance.bubbleNumber += 1;
                GameObject image = Resources.Load("prefabs/b" + ra.Next(1, 3).ToString()) as GameObject;
                image = Instantiate(image);
                image.transform.SetParent(gameObject.transform);
                generateTime = 0;
                max_ = (float)ra.NextDouble() * 5;
                float size = getSize();
                image.transform.localScale = new Vector3(size, size, size);
                image.GetComponent<Image>().color = new Color(image.GetComponent<Image>().color.r, image.GetComponent<Image>().color.g, image.GetComponent<Image>().color.b, getAlpha());
                Vector2 pos = getPos();
                image.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(pos.x, pos.y, 0);
                // image.GetComponent<RectTransform>().position = new Vector3(image.GetComponent<RectTransform>().position.x, image.GetComponent<RectTransform>().position.y,0);
            }
        }
    }
    public void Generate(int num)
    {
        for(int i = 0; i < num; i++)
        {
            GameManager.instance.bubbleNumber += 1;
            GameObject image = Resources.Load("prefabs/b" + ra.Next(1, 3).ToString()) as GameObject;
            //气泡生成
            AkSoundEngine.PostEvent("Object_Bubble_Generate", gameObject);
            image = Instantiate(image);
            image.transform.parent = gameObject.transform;
            generateTime = 0;
            max_ = (float)ra.NextDouble() * 5;
            float size = getSize();
            image.transform.localScale = new Vector3(size, size, size);
            image.GetComponent<Image>().color = new Color(image.GetComponent<Image>().color.r, image.GetComponent<Image>().color.g, image.GetComponent<Image>().color.b, getAlpha());
            Vector2 pos = getPos();
            image.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(pos.x, pos.y, 0);
            // image.GetComponent<RectTransform>().position = new Vector3(image.GetComponent<RectTransform>().position.x, image.GetComponent<RectTransform>().position.y,0);
        }
    }
 
}
