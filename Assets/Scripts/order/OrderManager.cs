using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class OrderManager : MonoBehaviour
{
    //
    public static OrderManager instance;
    //
    public Sprite[] combineSprites;
    //
    public GameObject panel;
    //�����е�ͼ�񣬺�element��Ӧ
    public Sprite[] allObjectsSprite = new Sprite[100];
    //ÿ��������һ��ʵ������map
    Dictionary<Order, GameObject> orderDic;
    public Dictionary<GameObject, Order> objDic;
    public int MAX_ = 3;
    //�����ڻ��еĶ���,��С����Ϊ���ҵ���
    List<Order> allOrders;//
    // ��¼ÿһ����Ʒ
    public Object[] objects = new Object[110];
    //�����
    private static readonly System.Random ra = new System.Random(unchecked((int)DateTime.Now.Ticks));
    //�Ѷ�
    public int[] simple = new int[5];
    public int[] middle = new int[5];
    public int[] hard = new int[5];
    //
    Vector3 startPos = new Vector3(-23.3f, 14.6f, -6.9f);
    Vector3 gap = new Vector3(4.5f, 0, 0);
    //
    public bool gameStart;
    public GameObject loom;
    public GameObject workShop;
    private void Awake()
    {

        instance = this;
        orderDic  = new Dictionary<Order, GameObject>();
        objDic = new Dictionary<GameObject, Order>();
        objects = new Object[110];
        allOrders = new List<Order>();
        looms = new List<Object>();
        gameStart = false;
        workShops = new List<Object>();
        GetCombineTabel();
        initHardLevel();
    }
    private void Start()
    {
        animator = grandma.GetComponent<Animator>();
    }
    public List<Object> looms;
    public GameObject[] loomIcon;
    //�Ӷ�u����
    
    /*float width = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
float height = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;*/
    //����֯������panel
    public void AddIntoLoom(int number)//������Ƕ�Ӧ���,ֻ����������߲Ż��������
    {
        //��ͼƬ�滻�ɶ�Ӧsprite
        loomIcon[looms.Count].GetComponent<Image>().sprite = objects[number].sprite;
        loomIcon[looms.Count].GetComponent<Image>().color  =  new Color(loomIcon[looms.Count].GetComponent<Image>().color.r, loomIcon[looms.Count].GetComponent<Image>().color .g, loomIcon[looms.Count].GetComponent<Image>().color.b,255);
        looms.Add(objects[number]);
        //���������Ʒ
        AkSoundEngine.PostEvent("Player_Drop", gameObject);
        if (looms.Count == 3)//�������ˣ���ʼ֯��,���Ӳ����Լ����ٲ���
        {
            //֯��������
            AkSoundEngine.PostEvent("Ambient_LoomWork_Play", gameObject);
            int[] a = new int[6];
            for (int i = 0; i < 5; i++)
                a[i] = 0;
            for (int i = 0; i < 3; i++)
                a[(int)looms[i].name] += 1;
            if (a[1] == 3)
            {
                //silk 5
                isSewingNumber = 5;
                isSewing = true;
                for (int i = 0; i < 3; i++)
                    loomIcon[i].GetComponent<Image>().color = new Color(loomIcon[i].GetComponent<Image>().color.r, loomIcon[i].GetComponent<Image>().color.g, loomIcon[i].GetComponent<Image>().color.b, 0);
                for (int i = 0; i < 3; i++)
                {
                 
                    objects[(int)looms[i].name].number -= 1; } looms.Clear();
            }
            else if (a[2] == 3)
            {
                isSewingNumber = 6;
                isSewing = true;
                for (int i = 0; i < 3; i++)
                    loomIcon[i].GetComponent<Image>().color = new Color(loomIcon[i].GetComponent<Image>().color.r, loomIcon[i].GetComponent<Image>().color.g, loomIcon[i].GetComponent<Image>().color.b, 0);
                for (int i = 0; i < 3; i++)
                    objects[(int)looms[i].name].number -= 1;
                looms.Clear();
            }
            else if (a[3] == 3)
            {
                //���� 7
                isSewingNumber = 7;
                isSewing = true;
                for (int i = 0; i < 3; i++)
                    loomIcon[i].GetComponent<Image>().color = new Color(loomIcon[i].GetComponent<Image>().color.r, loomIcon[i].GetComponent<Image>().color.g, loomIcon[i].GetComponent<Image>().color.b, 0);
                for (int i = 0; i < 3; i++)
                    objects[(int)looms[i].name].number -= 1;looms.Clear();
            }
            else if(a[4] == 2 && a[2] ==1)
            {
                //���� 8
                isSewingNumber = 8;
                isSewing = true;
                for (int i = 0; i < 3; i++)
                    loomIcon[i].GetComponent<Image>().color = new Color(loomIcon[i].GetComponent<Image>().color.r, loomIcon[i].GetComponent<Image>().color.g, loomIcon[i].GetComponent<Image>().color.b, 0);
                for (int i = 0; i < 3; i++)
                    objects[(int)looms[i].name].number -= 1;
                looms.Clear();
            }
            //֯����ֹͣ����
            AkSoundEngine.PostEvent("Ambient_LoomWork_Stop", gameObject);
            //֯�����������
            AkSoundEngine.PostEvent("Object_Loom_Finish", gameObject);
            RefreashMaterialPanel();
        }
    }

    public List<Object> workShops;
    public GameObject[] workShopIcon;
    public void AddIntoWorkShop(int number)
    {
        Debug.Log(workShops.Count);
        Debug.Log(number);
        workShopIcon[workShops.Count].GetComponent<Image>().sprite = objects[number].sprite;
        workShopIcon[workShops.Count].GetComponent<Image>().color = new Color(workShopIcon[workShops.Count].GetComponent<Image>().color.r, workShopIcon[workShops.Count].GetComponent<Image>().color.g, workShopIcon[workShops.Count].GetComponent<Image>().color.b, 255);
        workShops.Add(objects[number]);
        //���������Ʒ
        AkSoundEngine.PostEvent("Player_Drop", gameObject);

        if (workShops.Count == 3)//�������ˣ���ʼ�춫��
        {
            //���һ�ֹͣ��ת
            AkSoundEngine.PostEvent("Ambient_MachineWork_Stop", gameObject);

            //��������������ʹ�÷��һ���
            AkSoundEngine.PostEvent("Ambient_GrandmaWork_Play", gameObject);
            Debug.Log("GetThree");
            int[] a = new int[30];
            for (int i = 0; i < 5; i++)
                a[i] = 0;
            for (int i = 0; i < 3; i++)
                a[(int)workShops[i].name] += 1;
            if (a[2] == 1 && a[6] == 2)
            {
                //silk 5
                isMakingNumber = 11;
                isMaking = true;
                for (int i = 0; i < 3; i++)
                    workShopIcon[i].GetComponent<Image>().color = new Color(workShopIcon[i].GetComponent<Image>().color.r, workShopIcon[i].GetComponent<Image>().color.g, workShopIcon[i].GetComponent<Image>().color.b, 0);
                for (int i = 0; i < 3; i++)
                    objects[(int)workShops[i].name].number -= 1;
                workShops.Clear();
            }
            else if (a[8] == 1 && a[6] == 1 && a[2] == 1)
            {
                Debug.Log("yy");
                isMakingNumber = 12;
                isMaking = true;
                for (int i = 0; i < 3; i++)
                    workShopIcon[i].GetComponent<Image>().color = new Color(workShopIcon[i].GetComponent<Image>().color.r, workShopIcon[i].GetComponent<Image>().color.g, workShopIcon[i].GetComponent<Image>().color.b, 0);
                for (int i = 0; i < 3; i++)
                    objects[(int)workShops[i].name].number -= 1;
                workShops.Clear();
            }
           
          else if (a[6] == 1 && a[7] == 1 && a[2] == 1)
            {
                //���� 7
                isMakingNumber = 13;
                isMaking = true;
                for (int i = 0; i < 3; i++)
                    workShopIcon[i].GetComponent<Image>().color = new Color(workShopIcon[i].GetComponent<Image>().color.r, workShopIcon[i].GetComponent<Image>().color.g, workShopIcon[i].GetComponent<Image>().color.b, 0);
                for (int i = 0; i < 3; i++)
                    objects[(int)workShops[i].name].number -= 1;
                workShops.Clear();
            } 
            else if (a[0] == 2 && a[6] == 1)
            {
                //���� 8
                isMakingNumber = 14;
                isMaking = true;
                for (int i = 0; i < 3; i++)
                    workShopIcon[i].GetComponent<Image>().color = new Color(workShopIcon[i].GetComponent<Image>().color.r, workShopIcon[i].GetComponent<Image>().color.g, workShopIcon[i].GetComponent<Image>().color.b, 0);
                for (int i = 0; i < 3; i++)
                    objects[(int)workShops[i].name].number -= 1;
                workShops.Clear();
            }
            else if (a[14] == 1 && a[7] == 1 && a[2] == 1)
            {
                //���� 8
                isMakingNumber = 15;
                isMaking = true;
                for (int i = 0; i < 3; i++)
                    workShopIcon[i].GetComponent<Image>().color = new Color(workShopIcon[i].GetComponent<Image>().color.r, workShopIcon[i].GetComponent<Image>().color.g, workShopIcon[i].GetComponent<Image>().color.b, 0);
                for (int i = 0; i < 3; i++)
                    objects[(int)workShops[i].name].number -= 1;
                workShops.Clear();
            }
            else if (a[14] == 1 && a[8] == 1 && a[9] ==1)
            {
                //���� 8
                isMakingNumber = 16;
                isMaking = true;
                for (int i = 0; i < 3; i++)
                    workShopIcon[i].GetComponent<Image>().color = new Color(workShopIcon[i].GetComponent<Image>().color.r, workShopIcon[i].GetComponent<Image>().color.g, workShopIcon[i].GetComponent<Image>().color.b, 0);
                for (int i = 0; i < 3; i++)
                    objects[(int)workShops[i].name].number -= 1;
                workShops.Clear();
            }
            else if (a[5] == 1 && a[0] == 1 && a[9] == 1)
            {
                //���� 8
                isMakingNumber = 17;
                isMaking = true;
                for (int i = 0; i < 3; i++)
                    workShopIcon[i].GetComponent<Image>().color = new Color(workShopIcon[i].GetComponent<Image>().color.r, workShopIcon[i].GetComponent<Image>().color.g, workShopIcon[i].GetComponent<Image>().color.b, 0);
                for (int i = 0; i < 3; i++)
                    objects[(int)workShops[i].name].number -= 1;
                workShops.Clear();
            }
            else if (a[10] == 2 && a[1] == 1)
            {
                //���� 8
                isMakingNumber = 18;
                isMaking = true;
                for (int i = 0; i < 3; i++)
                    workShopIcon[i].GetComponent<Image>().color = new Color(workShopIcon[i].GetComponent<Image>().color.r, workShopIcon[i].GetComponent<Image>().color.g, workShopIcon[i].GetComponent<Image>().color.b, 0);
                for (int i = 0; i < 3; i++)
                    objects[(int)workShops[i].name].number -= 1;
                workShops.Clear();
            }
            else if (a[9] == 1 && a[5] == 1 && a[18] == 1)
            {
                //���� 8
               // objects[19].number += 1;
                isMakingNumber = 19;
                
                for (int i = 0; i < 3; i++)
                    workShopIcon[i].GetComponent<Image>().color = new Color(workShopIcon[i].GetComponent<Image>().color.r, workShopIcon[i].GetComponent<Image>().color.g, workShopIcon[i].GetComponent<Image>().color.b, 0);
                for (int i = 0; i < 3; i++)
                    objects[(int)workShops[i].name].number -= 1;
                workShops.Clear();
            } else
            {
                isMaking = false;
                return;
            }/**/
            //������������
            AkSoundEngine.PostEvent("Ambient_GrandmaWork_Stop", gameObject);

            //��������(���һ���ת��
            AkSoundEngine.PostEvent("Ambient_MachineWork_Play", gameObject);
            RefreashMaterialPanel();
            
        }

    }
    public int isMakingNumber = 0;
    public bool isMaking = false;
    public TMP_Text[] numbers = new TMP_Text[19];
    //ˢ������ϲ��ϸ���
    public void RefreashMaterialPanel()
    {
        for(int i = 5; i < 19; i++)
        {
            numbers[i].text = ((int)objects[i].number).ToString();
            /**/
        }
    }
    public GameObject[] showForCloset;
    public void RefreshBoardSprite(int i)
    {
        // ��ͬ����ı䲻ͬ��ͼ
         if((int)objects[i].inShelves >= 3)
        {
            showForCloset[i-5].SetActive(true);
            showForCloset[i-5].transform.GetChild(0).gameObject.SetActive(true);
            showForCloset[i-5].transform.GetChild(1).gameObject.SetActive(true);
          
            
        }
        else if((int)objects[i].inShelves == 2)
                {  
            showForCloset[i-5].SetActive(true);
            showForCloset[i-5].transform.GetChild(0).gameObject.SetActive(true);
            showForCloset[i-5].transform.GetChild(1).gameObject.SetActive(false);
          
        }
        else if((int)objects[i].inShelves == 1)
                {
            Debug.Log("lalla");
            showForCloset[i-5].SetActive(true);
            showForCloset[i-5].transform.GetChild(0).gameObject.SetActive(false);
            showForCloset[i-5].transform.GetChild(1).gameObject.SetActive(false);
            
        }
        else if((int)objects[i].inShelves == 0)
                {
                showForCloset[i-5].SetActive(false);
                    
                }

        CheckProcess();
    }

    //�ŵ������Ϻ���õ�
    public void PortObject2Guizi(int i)//������Ǳ��
    {
        objects[i].inShelves += 1;
        //����ͼ
        RefreshBoardSprite(i);
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
    float makingTime = 0;
    bool isSewing = false;
    float sewingTime = 0;
    int isSewingNumber = 0;
    public GameObject grandma;
    private Animator animator;
    private void Update()
    {
      

        if (gameStart)
        {
            gameTime += Time.deltaTime;
            singleTime += Time.deltaTime;
            Create();  
            //���¶�����ʣ��ʱ��
            UpdateRemainTime();
        }
        if (isMaking)
        {
            animator.SetBool("isworking", true);
            makingTime += Time.deltaTime;
            if(makingTime > 4f)
            {
                Debug.Log("�������");
                //�������
                AkSoundEngine.PostEvent("Object_Order_Finish", gameObject);
                animator.SetBool("isworking", false);
                isMaking = false;
                makingTime = 0;
                objects[isMakingNumber].number += 1;
                objects[isMakingNumber].inWorkShop += 1;
                RefreshWorkShopSprite(isMakingNumber);
                RefreashMaterialPanel();
            }
        }
        if (isSewing)
        {
            sewingTime += Time.deltaTime;
            animator.SetBool("isworking", true);
            if (sewingTime > 2f)
            {
                Debug.Log("֯�����:"+isSewingNumber);
                animator.SetBool("isworking",false);
                isSewing = false;
                sewingTime = 0;
                objects[isSewingNumber].number += 1;
                objects[isSewingNumber].inLoom += 1;
                RefreashMaterialPanel();
                RefreashLoomPanel();
                
            }
        }

    }
    public void RefreashLoomPanel()
    {
        for(int i = 5; i <= 8; i++)
        {
            if(objects[i].inLoom == 0)
            {
                Loom.Instance.forShow[i-5].SetActive(false);
            }
            else
            {
                Loom.Instance.forShow[i - 5].SetActive(true);
            }
        }
    }
    public void ClearWorkShop()
    {
        for (int i = 0; i < 3; i++)
            workShopIcon[i].GetComponent<Image>().color = new Color(workShopIcon[i].GetComponent<Image>().color.r, workShopIcon[i].GetComponent<Image>().color.g, workShopIcon[i].GetComponent<Image>().color.b, 0);
        workShops.Clear();
    }
    public void ClearLoom()
    {
        for (int i = 0; i < 3; i++)
            loomIcon[i].GetComponent<Image>().color = new Color(loomIcon[i].GetComponent<Image>().color.r, loomIcon[i].GetComponent<Image>().color.g, loomIcon[i].GetComponent<Image>().color.b, 0);
        looms.Clear();
    }
    public void RefreshWorkShopSprite(int number)
    {
        for (int i = 9; i <= 19; i++)
        {
            if (objects[i].inWorkShop == 0)
            {
               WorkShop.instance.forShow[i - 9].SetActive(false);
            }
            else
            {
                WorkShop.instance.forShow[i - 9].SetActive(true);
            }
        }
    }
    public void FinishOrder(GameObject order)
    {
        Order o = objDic[order];
        
        //�����Ǯ�ı�
        player.instance.FinishOrder(o);
        //
        foreach (var obj in o.objects)
        {
            //��Ʒ������
            objects[(int)obj.name].number -= 1;
            objects[(int)obj.name].inShelves -= 1;
            //ˢ������͹���չʾ
            RefreshBoardSprite((int)obj.name);
        }

        //ˢ�²������
        RefreashMaterialPanel();
        objDic.Remove(order);
        orderDic.Remove(o);
        Destroy(order);
    }
    void Create()
    {
        if (singleTime > 14)
        {            
            singleTime = 0;
            if(allOrders.Count >= 4)
            {
                //����������
                return;
            }
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
            CreateNewOrder(objs, money, 60);


        }
    }
    void CheckProcess()//��鲢����ÿ�������Ľ���,ÿ�β������¶����ŵ��ã���Ȼ̫�鷳��
    {
        for(int j = 0;j < allOrders.Count;j++)
  
        { 
            int fit = 0;//����
            int[] a = new int[100];
            for(int i = 0; i < 3; i++)
            {
                a[(int)allOrders[j].objects[i].name] = objects[(int)allOrders[j].objects[i].name].inShelves;
            }
            //�õ�������Ʒ����Ӧ�ĸ���
            for (int i = 0; i < 3; i++)
            {
                if (a[(int)allOrders[j].objects[i].name] > 0)
                {
                    fit += 1;
                    a[(int)allOrders[j].objects[i].name]--;
                }
                
            }
            allOrders[j].complete = fit*1.0f / 3;
            allOrders[j].compleSlider.value = fit * 1.0f / 3;
            if(fit == 3)
            {
                //����������Ա����,�ı�UI
                orderDic[allOrders[j]].transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(orderDic[allOrders[j]].transform.GetChild(0).GetChild(0).GetComponent<Image>().color.r, orderDic[allOrders[j]].transform.GetChild(0).GetChild(0).GetComponent<Image>().color.g, orderDic[allOrders[j]].transform.GetChild(0).GetChild(0).GetComponent<Image>().color.b, 255);
            }
            else
            {
                orderDic[allOrders[j]].transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(orderDic[allOrders[j]].transform.GetChild(0).GetChild(0).GetComponent<Image>().color.r, orderDic[allOrders[j]].transform.GetChild(0).GetChild(0).GetComponent<Image>().color.g, orderDic[allOrders[j]].transform.GetChild(0).GetChild(0).GetComponent<Image>().color.b, 0);
            }
        }
    }
    public GameObject[] bubbles;
    void UpdateRemainTime()
    {
        for(int i = 0; i < allOrders.Count; i++)
        {
            allOrders[i].remainTime -= Time.deltaTime;
            allOrders[i].slider.value = allOrders[i].remainTime / allOrders[i].allTime;
            if(allOrders[i].remainTime < 0)
            {
                //���Կ�����һ����ʧ��Ч������
                AkSoundEngine.PostEvent("Object_Order_Miss", gameObject);
                Destroy(orderDic[allOrders[i]]);
                bubbles[0].GetComponent<bubble>().Generate(30);
                //��allOrders�Ƴ�
                allOrders.RemoveAt(i);
            }
        }
    }

    //�����µĶ���
    public void CreateNewOrder(Object[] objects,float money,float time)
    {
        //����Ԥ����
        GameObject gameObject = Resources.Load("order") as GameObject;
        //ʵ����Ԥ����
        AkSoundEngine.PostEvent("Object_Order_Appear", gameObject);
        gameObject =  GameObject.Instantiate(gameObject);
        gameObject.transform.parent = GameObject.Find("OrderManager").transform;
        //�����¶���
        Order order = new Order() { objects = objects,allTime=time,remainTime=time,money=money,complete=0};
       
        order.slider = gameObject.transform.GetChild(0).GetChild(1).GetComponent<Slider>();
        order.compleSlider = gameObject.transform.GetChild(0).GetChild(5).GetComponent<Slider>();
                                  
        //����
        orderDic.Add(order, gameObject);
        objDic.Add(gameObject, order);
        //��ʼ��
        order.slider.value = 1;
        order.compleSlider.value = 0;
        gameObject.transform.position = startPos;
        //��ʾͼ��
        gameObject.transform.gameObject.transform.GetChild(0).Find("0").GetComponent<Image>().sprite = objects[0].sprite;
        gameObject.transform.gameObject.transform.GetChild(0).Find("1").GetComponent<Image>().sprite = objects[1].sprite;
        gameObject.transform.gameObject.transform.GetChild(0).Find("2").GetComponent<Image>().sprite = objects[2].sprite;
        //����allOrders
        allOrders.Add(order);
        //��������
        foreach (Order o in allOrders)
        {
            AkSoundEngine.PostEvent("Object_Order_Move", gameObject);
            orderDic[o].transform.DOMoveX(orderDic[o].transform.position.x+gap.x, 2f, false);
        }
    }
    //��ʼ��objects
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
        //��
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
