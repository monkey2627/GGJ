using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class OrderManager : MonoBehaviour
{
    //
    public static OrderManager instance;

    //存所有的图像，和element对应
    public Sprite[] allObjectsSprite = new Sprite[100];
    //每个订单和一个实体物体map
    Dictionary<Order, GameObject> orderDic;
    public int MAX_ = 3;
    //存现在还有的订单,从小到大为从右到左
    List<Order> allOrders;//
    // 记录每一种物品
    public Object[] objects = new Object[110];
    //随机数
    private static readonly System.Random ra = new System.Random(unchecked((int)DateTime.Now.Ticks));
    //难度
    public int[] simple = new int[5];
    public int[] middle = new int[5];
    public int[] hard = new int[5];
    //
    Vector3 startPos = new Vector3(-20.67f, 12.0795f, -10.3707f);
    Vector3 gap = new Vector3(3.3f, 0, 0);
    //
    public bool gameStart;
    private void Awake()
    {

        instance = this;
        orderDic  = new Dictionary<Order, GameObject>();
        objects = new Object[110];
        allOrders = new List<Order>();
        gameStart = false;
        GetCombineTabel();
        initHardLevel();
    }
    void initHardLevel()
    {
        simple[0] = 11;
        simple[1] = 12;
        simple[2] = 13;
        middle[0] = 14;
        middle[1] = 15;
        middle[2] = 16;
        hard[0] = 17;
        hard[1] = 18;
        hard[2] = 19;
    }
    float gameTime = 0;
    float singleTime = 0;
    private void Update()
    {
      

        if (gameStart)
        {
            gameTime += Time.deltaTime;
            singleTime += Time.deltaTime;
            Create();  
            //更新订单的剩余时间
            UpdateRemainTime();
        }

    }
    void Create()
    {
        if (singleTime > 14)
        {            
            singleTime = 0;
            Object[] objs = new Object[3];
            float money = 0;
            if (gameTime <= 80)
            {
                //1:0:0
                objs[0] = objects[simple[ra.Next(0, 3)]];
               
                objs[1] = objects[simple[ra.Next(0, 3)]];
                objs[2] = objects[simple[ra.Next(0, 3)]]; 
            }
            else if (gameTime >= 80 && gameTime <= 160)
            {
                //18:12
                int[] t = new int[30];
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        t[i * 3 + j] = simple[j];
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        t[18 + i * 3 + j] = middle[j];
                    }
                }
                objs[0] = objects[t[ra.Next(0, 30)]];
                objs[1] = objects[t[ra.Next(0, 30)]];
                objs[2] = objects[t[ra.Next(0, 30)]];
            }
            else if (gameTime >= 160 && gameTime <= 240)
            {//12:15:3
                int[] t = new int[30];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        t[i * 3 + j] = simple[j];
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        t[12 + i * 3 + j] = simple[j];
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        t[27 + i * 3 + j] = middle[j];
                    }
                }
                objs[0] = objects[t[ra.Next(0, 30)]];
                objs[1] = objects[t[ra.Next(0, 30)]];
                objs[2] = objects[t[ra.Next(0, 30)]];
            }
            else if (gameTime >= 240 && gameTime <= 320)
            {
                //9:15:6
                int[] t = new int[30];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        t[i * 3 + j] = simple[j];
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        t[9 + i * 3 + j] = simple[j];
                    }
                }
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        t[24 + i * 3 + j] = middle[j];
                    }
                }
                objs[0] = objects[t[ra.Next(0, 30)]];
                objs[1] = objects[t[ra.Next(0, 30)]];
                objs[2] = objects[t[ra.Next(0, 30)]];
            }
            else if (gameTime >= 320 && gameTime <= 400)
            {
                //6:9:15
                int[] t = new int[30];
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        t[i * 3 + j] = simple[j];
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        t[6 + i * 3 + j] = simple[j];
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        t[15 + i * 3 + j] = middle[j];
                    }
                }
                objs[0] = objects[t[ra.Next(0, 30)]];
                objs[1] = objects[t[ra.Next(0, 30)]];
                objs[2] = objects[t[ra.Next(0, 30)]];
            }
            else if (gameTime >= 400 && gameTime <= 480)
            {
                //3:6:21
                int[] t = new int[30];
                for (int i = 0; i < 1; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        t[i * 3 + j] = simple[j];
                    }
                }
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        t[3 + i * 3 + j] = simple[j];
                    }
                }
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        t[9 + i * 3 + j] = middle[j];
                    }
                }
                objs[0] = objects[t[ra.Next(0, 30)]];
                objs[1] = objects[t[ra.Next(0, 30)]];
                objs[2] = objects[t[ra.Next(0, 30)]];
            }
            for(int i = 0; i < 3; i++)
            {
                money += objs[i].buyprice;
            }
            money = money * 1.2f;
            CreateNewOrder(objs, money, 40);


        }
    }
    void CheckProcess()//检查并更新每个订单的进度
    {
        for(int j = 0;j < allOrders.Count;j++)
  
        { 
            int fit = 0;//进度
            int[] a = new int[100];
            for(int i = 0; i < 3; i++)
            {
                a[(int)allOrders[j].objects[i].name] = objects[(int)allOrders[j].objects[i].name].number;
            }
            //得到三个物品所对应的个数
            for (int i = 0; i < 3; i++)
            {
                if (a[(int)allOrders[j].objects[i].name] > 0)
                {
                    fit += 1;
                    a[(int)allOrders[j].objects[i].name]--;
                }
                
            }
            allOrders[j].complete = fit*1.0f / 3;
        }
    }
    void UpdateRemainTime()
    {
        for(int i = 0; i < allOrders.Count; i++)
        {
            allOrders[i].remainTime -= Time.deltaTime;
            allOrders[i].slider.value = allOrders[i].remainTime / allOrders[i].allTime;
            if(allOrders[i].remainTime < 0)
            {
                    //可以考虑做一个消失的效果？？
                Destroy(orderDic[allOrders[i]]);
                //从allOrders移除
                allOrders.RemoveAt(i);
            }
        }
    }

    //生成新的订单
    public void CreateNewOrder(Object[] objects,float money,float time)
    {
        //加载预制体
        GameObject gameObject = Resources.Load("order") as GameObject;
        //实例化预制体
        gameObject =  GameObject.Instantiate(gameObject);
        gameObject.transform.parent = GameObject.Find("OrderManager").transform;
        //创建新订单
        Order order = new Order() { objects = objects,allTime=time,remainTime=time,money=money,complete=0,slider = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>() };
        //关联
        orderDic.Add(order, gameObject);
        
        //初始化
        order.slider.value = 1;
        gameObject.transform.position = startPos;
        //显示图标
        gameObject.transform.gameObject.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = objects[0].sprite;
        gameObject.transform.gameObject.transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = objects[1].sprite;
        gameObject.transform.gameObject.transform.GetChild(0).GetChild(3).GetComponent<Image>().sprite = objects[2].sprite;
        //加入allOrders
        allOrders.Add(order);
        //集体右移
        foreach (Order o in allOrders)
        {
            Debug.Log("move");
            orderDic[o].transform.DOMoveX(orderDic[o].transform.position.x+gap.x, 2f, false);
        }
    }

    //初始化objects
    public void GetCombineTabel()
    {
        for(int i = 0; i < 30; i++)
        {
            objects[i] = new Object();
        }
        objects[0].name = Element.GoldThread;
        objects[0].sprite = allObjectsSprite[0];

        objects[(int)Element.SilkThread].name = Element.SilkThread;
        objects[(int)Element.SilkThread].sprite = allObjectsSprite[1];

        objects[(int)Element.CottonThread].name = Element.CottonThread;
        objects[(int)Element.CottonThread].sprite = allObjectsSprite[2];

        objects[(int)Element.LinenThread].name = Element.LinenThread;
        objects[(int)Element.LinenThread].sprite = allObjectsSprite[3];

        objects[(int)Element.PolyesterThread].name = Element.PolyesterThread;
        objects[(int)Element.PolyesterThread].sprite = allObjectsSprite[4];
        //布
        objects[(int)Element.Silk].ingredients[0] = new Ingredient() { obj = objects[(int)Element.SilkThread], num = 3 };
        objects[(int)Element.Silk].name = Element.Silk;
        objects[(int)Element.Silk].sprite = allObjectsSprite[5];

        objects[(int)Element.CottonCloth].name = Element.CottonCloth;
        objects[(int)Element.CottonCloth].ingredients[0] = new Ingredient() { obj = objects[(int)Element.CottonThread], num = 3 };
        objects[(int)Element.CottonCloth].sprite = allObjectsSprite[6];

        objects[(int)Element.Linen].name = Element.Linen;
        objects[(int)Element.Linen].ingredients[0] = new Ingredient() { obj = objects[(int)Element.LinenThread], num = 3 };
        objects[(int)Element.Linen].sprite = allObjectsSprite[7];

        objects[(int)Element.PolyesterCloth].name = Element.PolyesterCloth;
        objects[(int)Element.PolyesterCloth].ingredients[0] = new Ingredient() { obj = objects[(int)Element.PolyesterThread], num = 2 };
        objects[(int)Element.PolyesterCloth].ingredients[1] = new Ingredient() { obj = objects[(int)Element.CottonThread], num = 1 };
        objects[(int)Element.PolyesterCloth].sprite = allObjectsSprite[8];


        //
        objects[(int)Element.PreseamedPlates].name = Element.PreseamedPlates;
        objects[(int)Element.PreseamedPlates].sprite = allObjectsSprite[9];


        objects[(int)Element.CopperWireInlay].name = Element.CopperWireInlay;
        objects[(int)Element.CopperWireInlay].sprite = allObjectsSprite[10];
        //
        objects[(int)Element.HouseholdItems1].ingredients[0] = new Ingredient() { obj = objects[(int)Element.CottonCloth], num = 2 };
        objects[(int)Element.HouseholdItems1].ingredients[1] = new Ingredient() { obj = objects[(int)Element.CottonThread], num = 1 };
        objects[(int)Element.HouseholdItems1].name = Element.HouseholdItems1;
        objects[(int)Element.HouseholdItems1].sprite = allObjectsSprite[11];
        objects[11].buyprice = 40;
        objects[11].sellprice = 20;

        objects[(int)Element.HouseholdItems2].ingredients[0] = new Ingredient() { obj = objects[(int)Element.PolyesterCloth], num = 1 };
        objects[(int)Element.HouseholdItems2].ingredients[1] = new Ingredient() { obj = objects[(int)Element.CottonCloth], num = 1 };
        objects[(int)Element.HouseholdItems2].ingredients[2] = new Ingredient() { obj = objects[(int)Element.CottonThread], num = 1 };
        objects[(int)Element.HouseholdItems2].name = Element.HouseholdItems2;
        objects[(int)Element.HouseholdItems2].sprite = allObjectsSprite[12];
        objects[12].buyprice = 40;
        objects[12].sellprice = 20;

        objects[(int)Element.Smock].ingredients[0] = new Ingredient() { obj = objects[(int)Element.CottonCloth], num = 1 };
        objects[(int)Element.Smock].ingredients[1] = new Ingredient() { obj = objects[(int)Element.CottonThread], num = 1 };
        objects[(int)Element.Smock].ingredients[2] = new Ingredient() { obj = objects[(int)Element.Linen], num = 1 };
        objects[(int)Element.Smock].name = Element.Smock;
        objects[(int)Element.Smock].sprite = allObjectsSprite[13];
        objects[13].buyprice = 40;
        objects[13].sellprice = 20;

        objects[(int)Element.Jewelry].ingredients[0] = new Ingredient() { obj = objects[(int)Element.GoldThread], num = 2 };
        objects[(int)Element.Jewelry].ingredients[1] = new Ingredient() { obj = objects[(int)Element.CottonCloth], num = 1 };
        objects[(int)Element.Jewelry].name = Element.Jewelry;
        objects[(int)Element.Jewelry].sprite = allObjectsSprite[14];
        objects[14].buyprice = 40;
        objects[14].sellprice = 20;

        objects[(int)Element.LinenBag].ingredients[0] = new Ingredient() { obj = objects[(int)Element.Jewelry], num = 1 };
        objects[(int)Element.LinenBag].ingredients[1] = new Ingredient() { obj = objects[(int)Element.CottonThread], num = 1 };
        objects[(int)Element.LinenBag].ingredients[2] = new Ingredient() { obj = objects[(int)Element.Linen], num = 1 };
        objects[(int)Element.LinenBag].name = Element.LinenBag;
        objects[(int)Element.LinenBag].sprite = allObjectsSprite[15];
        objects[15].buyprice = 80;
        objects[15].sellprice = 40;

        objects[(int)Element.Doll].ingredients[0] = new Ingredient() { obj = objects[(int)Element.Jewelry], num = 1 };
        objects[(int)Element.Doll].ingredients[1] = new Ingredient() { obj = objects[(int)Element.PreseamedPlates], num = 1 };
        objects[(int)Element.Doll].ingredients[2] = new Ingredient() { obj = objects[(int)Element.PolyesterCloth], num = 1 };
        objects[(int)Element.Doll].name = Element.Doll;
        objects[(int)Element.Doll].sprite = allObjectsSprite[16];
        objects[16].buyprice = 80;
        objects[16].sellprice = 40;


        objects[(int)Element.cheongsam].ingredients[0] = new Ingredient() { obj = objects[(int)Element.Silk], num = 1 };
        objects[(int)Element.cheongsam].ingredients[1] = new Ingredient() { obj = objects[(int)Element.PreseamedPlates], num = 1 };
        objects[(int)Element.cheongsam].ingredients[2] = new Ingredient() { obj = objects[(int)Element.GoldThread], num = 1 };
        objects[(int)Element.cheongsam].name = Element.cheongsam;
        objects[(int)Element.cheongsam].sprite = allObjectsSprite[17];
        objects[17].buyprice = 160;
        objects[17].sellprice = 80;

        objects[(int)Element.EmbroideredDecorations].ingredients[0] = new Ingredient() { obj = objects[(int)Element.CopperWireInlay], num = 2 };
        objects[(int)Element.EmbroideredDecorations].ingredients[1] = new Ingredient() { obj = objects[(int)Element.SilkThread], num = 1 };
        //  objects[(int)Element.EmbroideredDecorations].ingredients[2] = new Ingredient() { obj = objects[(int)Element.EmbroideredDecorations], num = 1 };
        objects[(int)Element.EmbroideredDecorations].name = Element.EmbroideredDecorations;
        objects[(int)Element.EmbroideredDecorations].sprite = allObjectsSprite[18];
        objects[18].buyprice = 120;
        objects[18].sellprice = 60;

        objects[(int)Element.ChineseWeddingDress].ingredients[0] = new Ingredient() { obj = objects[(int)Element.PreseamedPlates], num = 1 };
        objects[(int)Element.ChineseWeddingDress].ingredients[1] = new Ingredient() { obj = objects[(int)Element.Silk], num = 1 };
        objects[(int)Element.ChineseWeddingDress].ingredients[2] = new Ingredient() { obj = objects[(int)Element.EmbroideredDecorations], num = 1 };
        objects[(int)Element.ChineseWeddingDress].name = Element.ChineseWeddingDress;
        objects[(int)Element.ChineseWeddingDress].sprite = allObjectsSprite[19];
        objects[19].buyprice = 320;
        objects[19].sellprice = 160;

    }
}
