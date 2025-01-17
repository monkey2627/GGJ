using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startUIPanel;
    public GameObject moneyAndSprite;
    public GameObject materialsPanel;
    public GameObject postpro;
    float allGameTime = 480;
    float alreadyGameTime =0;
    //随机数
    private static readonly System.Random ra = new System.Random(unchecked((int)DateTime.Now.Ticks));
    //音效
    
    // Start is called before the first frame update
    void Start()
    {
      
    }
    public void StartGame()
    {
        //关掉整个start
        startUIPanel.SetActive(false);
        //显示资源面板
        moneyAndSprite.SetActive(true);
        materialsPanel.SetActive(true);
        //场景灯光
        ppManager.instance.GAMEStart();//关后处理
        LightingController.instance.StartLighting();//游戏中场景灯光变亮        
        GameObject.Find("SpotLight").GetComponent<flicking>().gameStart = true;//开始闪烁
       //游戏刚开始即创建一个新订单
        Object[] objs = new Object[3];
        float money = 0;
        objs[0] = OrderManager.instance.objects[OrderManager.instance.simple[ra.Next(0, 2)]];
        objs[1] = OrderManager.instance.objects[OrderManager.instance.simple[ra.Next(0, 2)]];
        objs[2] = OrderManager.instance.objects[OrderManager.instance.simple[ra.Next(0, 2)]];
        for (int i = 0; i < 3; i++)
        {
            money += objs[i].buyprice;
        }
        money = money * 1.2f;
        OrderManager.instance.CreateNewOrder(objs, money, 40);
        OrderManager.instance.gameStart = true;

    }
    public void ExitAllGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else 
        Application.Quit();
#endif
    }
    void Update()
    {

    }
}
