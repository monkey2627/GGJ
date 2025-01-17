using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Order
{
    public int mark;//�涩��λ��
    //�����������Ʒ
    public Object[] objects = new Object[3];
    //������ɿ��Եõ���Ǯ
    public float money;
    //��ʱ��
    public float allTime;
    //�����������ǵ�ʱ��
    public float remainTime;
    //��ɶ�
    public float complete;
    //Ϊ��������һ��������
    public Slider slider;
}
public class OrderManager : MonoBehaviour
{
    //ÿ��������һ��ʵ������map
    Dictionary<Order, GameObject> orderDic;
    static int MAX_ = 3;
    // �����Ĺ�����,�Ǵ����ڻ��еĶ���
    Vector3[] pos = new Vector3[3];//λ��
    Order[] orders = new Order[3];//����������ܳ���n������
    bool[] mark = new bool[3];//��n��λ�ô�ʱ�Ƿ��ж���
    int orderNum;
    // ��¼ÿһ����Ʒ
    public Object[] objects = new Object[110];
    //�����
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
        //���¶�����ʣ��ʱ��
        UpdateRemainTime();
    }
    void CheckProcess()//��鲢����ÿ�������Ľ���
    {
        for(int j = 0;j < 3;j++)
        if(mark[j])
        { 
            int fit = 0;//����
            int[] a = new int[100];
            for(int i = 0; i < 3; i++)
            {
                a[(int)orders[j].objects[i].name] = objects[(int)orders[j].objects[i].name].number;
            }
            //�õ�������Ʒ����Ӧ�ĸ���
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
                    //���Կ�����һ����ʧ��Ч������
                    Destroy(orderDic[orders[i]]);
                    orderNum--;
                }
        }
    }

    //�����µĶ���
    public void CreateNewOrder(Object[] objects,float money,float time)
    {
        //����Ԥ����
        GameObject gameObject = Resources.Load("order") as GameObject;
        gameObject.transform.parent = GameObject.Find("OrderManager").transform;
        //�����¶���
        Order order = new Order() { objects = objects,allTime=time,remainTime=time,money=money,complete=0,slider = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>() };
        //����
        orderDic[order] = gameObject;
        //���ѡ��һ�������ŵ�λ��
        int k = ra.Next(0, MAX_ - 1);
        while (mark[k])
        {
            k = ra.Next(0, MAX_ - 1);
        }
        //��ʼ��
       
        order.slider.value = 1;
        mark[k] = true;
        gameObject.transform.position = pos[k];
        orderNum +=1; 
        orders[k] = order;
    }
    
}
