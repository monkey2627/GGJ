using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.EventSystems;

public class player : MonoBehaviour
{
    public static player instance;
    public float money;//现在含有的钱
    public List<GameObject> sprites;//现在拥有的小精灵
    public TMP_Text moneyText;
    public TMP_Text spriteNumberText;
    public GameObject choosedObj;
    // Start is called before the first frame update
    public Transform workShop;//制布机位置
    public Transform loom;//制布机位置
    public GameObject left;
    public GameObject rightFar;

    Npc npc;
    int mark;
    void Start()
    {
        instance = this;
        money =0;
        sprites = new List<GameObject>();
        moneyText.text = "0";
        spriteNumberText.text = "0";
    }
    public int mode = 0;
    public bool clickThingsInWorkShop = false;
    public GameObject objInWorkShop = null;
    public bool clickThingsInLoom = false;
    public GameObject objInLoom = null;
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)){
                // 射线与物体相交，处理鼠标点击事件
                GameObject clickedObject = hit.collider.gameObject;
                if (Input.GetKeyDown(KeyCode.W))
                {
                    //出售
                    money += OrderManager.instance.objects[int.Parse(clickedObject.name)].sellprice;
                    moneyText.text = ((int)money).ToString();
                    

                }else if (Input.GetKeyDown(KeyCode.D)){
                    //购买
                    if(money < OrderManager.instance.objects[int.Parse(clickedObject.name)].buyprice)
                    {
                        //显示金币不足
                    }
                    //出售
                    money -= OrderManager.instance.objects[int.Parse(clickedObject.name)].buyprice;
                    moneyText.text = ((int)money).ToString();

                }
                if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
                {
               //Debug.Log(clickedObject.name);
                    //如果点击的是已经可以完成的订单,就完成订单
                    if(clickedObject.name == "order")
                    {
                        choosedObj = null;
                    Debug.Log(1);
                    clickThingsInWorkShop = false;
                    clickThingsInLoom = false;
                        if (OrderManager.instance.objDic[clickedObject].complete == 1)
                            OrderManager.instance.FinishOrder(clickedObject);
                    }
                    else if (clickedObject.layer == 14)//点击了object,用layer来
                    {
                        if(clickThingsInWorkShop && objInWorkShop != null && !(clickedObject.transform.parent != null && clickedObject.transform.parent.name == "WorkShop"))//上一次点的工作站上的物品
                        {
                            StartPortFromWorkShop();}
                        else if(clickThingsInLoom && objInLoom != null && !(clickedObject.transform.parent != null && clickedObject.transform.parent.name == "Loom"))
                        {
                            StartPortFromLoom();
                        }

                        choosedObj = clickedObject;
                        //如果点击的物品在workShop或者Loom上
                        if(clickedObject.transform.parent !=null && clickedObject.transform.parent.name == "WorkShop")
                        {
                            Debug.Log("fromWorkShop");
                            clickThingsInWorkShop = true;
                            objInWorkShop = clickedObject;
                            Debug.Log(clickThingsInWorkShop);
                    } else if(clickedObject.transform.parent != null && clickedObject.transform.parent.name == "Loom")
                        {
                            Debug.Log("fromLoom");
                            clickThingsInLoom = true;
                            objInLoom= clickedObject;
                    }else
                    {
                        clickThingsInWorkShop = false;
                        Debug.Log(2);
                        clickThingsInLoom = false;
                    }
                    }
                else if (clickedObject.transform.parent.name== "rightclosetfar")
                {
                    Debug.Log("rightclosetfar");
                    if (clickThingsInLoom)
                    {
                        StartPortFromLoom();
                    }else if (clickThingsInWorkShop)
                    {
                        StartPortFromWorkShop();
                    }
                    clickThingsInLoom = false;
                    clickThingsInWorkShop = false;
                    Debug.Log(3);
                }
                else if (clickedObject.transform.parent.name == "rightclosetclose" || clickedObject.name == "rightclosetclos")
                {
                    if (clickThingsInLoom)
                    {
                        StartPortFromLoom();
                    }
                    else if (clickThingsInWorkShop)
                    {
                        StartPortFromWorkShop();
                    }
                    clickThingsInLoom = false;
                    clickThingsInWorkShop = false;
                    Debug.Log(4);
                }
                else if (clickedObject.transform.parent.name == "leftCloset" || clickedObject.name=="leftCloset")
                {
                    Debug.Log("leftCloset");
                    Debug.Log(clickThingsInWorkShop);
                    if (clickThingsInLoom)
                    {
                        StartPortFromLoom();
                    }
                    else if (clickThingsInWorkShop)
                    {
                        Debug.Log("StartPortFromWorkShop");
                        StartPortFromWorkShop();
                    }
                    clickThingsInLoom = false;
                    clickThingsInWorkShop = false;
                    Debug.Log(5);
                }
                else if (clickedObject.layer == 16)
                {
                    
                        Buy(int.Parse(clickedObject.name));
                    
                }else{
                        choosedObj = null;
                        clickThingsInWorkShop = false;
                    Debug.Log(6);
                    clickThingsInLoom = false;
                } 
            
                }else if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject())
                {
                    Debug.Log(clickedObject.name);
                    //如果点击的是已经可以完成的订单,就完成订单
                    if (clickedObject.layer == 9)
                    {
                        choosedObj = null;
                        Debug.Log(1);
                        clickThingsInWorkShop = false;
                        clickThingsInLoom = false;
                        if (OrderManager.instance.objDic[clickedObject].complete == 1)
                            OrderManager.instance.FinishOrder(clickedObject);
                        else
                        {
                        clickedObject.GetComponent<showGuide>().Show();
                        }
                    }else if (clickedObject.layer == 16)
                {
                    Debug.Log("buy");

                    Buy(int.Parse(clickedObject.name));

                }

            }
            else if (Input.GetMouseButtonDown(1) )
            {
                if (clickedObject.layer == 16)
                {
                    
                        Sold(int.Parse(clickedObject.name));
                    
                }
            }
        
        
        }
        



    }
    
    public void StartPortFromWorkShop()
    {
        mark = int.Parse(objInWorkShop.name);
        npc = NpcManager.Instance.FindHaveTimeNpc();
        if (npc != null)//有空闲的Npc
        {
            npc.SetPos(workShop.position, left.transform.position, 3, mark);
        }
    }
    public void StartPortFromLoom()
    {
        mark = int.Parse(objInLoom.name);
        npc = NpcManager.Instance.FindHaveTimeNpc();
        if (npc != null)//有空闲的Npc
        {
            npc.SetPos(loom.position, rightFar.transform.position, 2, mark);
        }
    }
    public void FinishOrder(Order order)
    {
        money += order.money;
        moneyText.text = ((int)money).ToString();
    }
    
    //买东西
    public void Buy(int number)
    {
        if(money > OrderManager.instance.objects[number].buyprice)
        {
            money -= OrderManager.instance.objects[number].buyprice;
            moneyText.text = ((int)money).ToString();
            OrderManager.instance.objects[number].number += 1;
            OrderManager.instance.RefreashMaterialPanel();
        }
        

    }
    //卖东西
    public void Sold(int number)
    {
        if (OrderManager.instance.objects[number].number > 0) { 
            money += OrderManager.instance.objects[number].sellprice;
        moneyText.text = ((int)money).ToString();
        OrderManager.instance.objects[number].number -= 1;
        OrderManager.instance.RefreashMaterialPanel(); }

    }
}
