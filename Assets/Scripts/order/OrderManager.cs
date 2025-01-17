using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Order
{
    public int mark;//存订单位置
    //订单所需的物品
    public Object[] objects = new Object[3];
    //订单完成可以得到的钱
    public float money;
    //总时间
    public float allTime;
    //订单留给我们的时间
    public float remainTime;
    //完成度
    public float complete;
    //为订单创建一个进度条
    public Slider slider;
}
public class OrderManager : MonoBehaviour
{
    //每个订单和一个实体物体map
    Dictionary<Order, GameObject> orderDic;
    static int MAX_ = 3;
    // 订单的管理类,是存现在还有的订单
    Vector3[] pos = new Vector3[3];//位置
    Order[] orders = new Order[3];//订单，最多能出现n个订单
    bool[] mark = new bool[3];//第n个位置此时是否有订单
    int orderNum;
    // 记录每一种物品
    public Object[] objects = new Object[110];
    //随机数
    private static readonly System.Random ra = new System.Random(unchecked((int)DateTime.Now.Ticks));
    private void Start()
    {
        orderNum = 0;
        for(int i = 0; i < MAX_; i++)
        {
            mark[i] = false;
        }
    }
    private void Update()
    {
        //更新订单的剩余时间
        UpdateRemainTime();
    }
    void CheckProcess()//检查并更新每个订单的进度
    {
        for(int j = 0;j < 3;j++)
        if(mark[j])
        { 
            int fit = 0;//进度
            int[] a = new int[100];
            for(int i = 0; i < 3; i++)
            {
                a[(int)orders[j].objects[i].name] = objects[(int)orders[j].objects[i].name].number;
            }
            //得到三个物品所对应的个数
            for (int i = 0; i < 3; i++)
            {
                if (a[(int)orders[j].objects[i].name] > 0)
                {
                    fit += 1;
                    a[(int)orders[j].objects[i].name]--;
                }
                
            }
                orders[j].complete = fit*1.0f / 3;
        }
    }
    void UpdateRemainTime()
    {
        for(int i = 0; i < MAX_; i++)
        if(mark[i])
        {
                orders[i].remainTime -= Time.deltaTime;
                orders[i].slider.value = orders[i].remainTime / orders[i].allTime;
                if(orders[i].remainTime < 0)
                {
                    mark[i] = false;
                    //可以考虑做一个消失的效果？？
                    Destroy(orderDic[orders[i]]);
                    orderNum--;
                }
        }
    }

    //生成新的订单
    public void CreateNewOrder(Object[] objects,float money,float time)
    {
        //加载预制体
        GameObject gameObject = Resources.Load("order") as GameObject;
        gameObject.transform.parent = GameObject.Find("OrderManager").transform;
        //创建新订单
        Order order = new Order() { objects = objects,allTime=time,remainTime=time,money=money,complete=0,slider = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>() };
        //关联
        orderDic[order] = gameObject;
        //随机选择一个还空着的位置
        int k = ra.Next(0, MAX_ - 1);
        while (mark[k])
        {
            k = ra.Next(0, MAX_ - 1);
        }
        //初始化
       
        order.slider.value = 1;
        mark[k] = true;
        gameObject.transform.position = pos[k];
        orderNum +=1; 
        orders[k] = order;
    }
    
}
