using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{
    public static player instance;
    public float money;//现在含有的钱
    public List<GameObject> sprites;//现在拥有的小精灵
    public TMP_Text moneyText;
    public TMP_Text spriteNumberText;
    public GameObject choosedObj;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        money = 0;
        sprites = new List<GameObject>();
        moneyText.text = "0";
        spriteNumberText.text = "0";
    }

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
                if (Input.GetMouseButtonDown(0))
                {
                    //如果点击的是已经可以完成的订单,就完成订单
                    if(clickedObject.name == "order")
                    {
                        choosedObj = null;
                        if(OrderManager.instance.objDic[clickedObject].complete == 1)
                            OrderManager.instance.FinishOrder(clickedObject);
                    }else if (clickedObject.layer == 14)//点击了object,用layer来
                    {
                        choosedObj = clickedObject;
                        Debug.Log(clickedObject.name);
                    }   
                    else
                    {
                        choosedObj = null;
                    }
            
                }
        
        
        }
        



    }
    
    public void FinishOrder(Order order)
    {
        money += order.money;
        moneyText.text = ((int)money).ToString();
    }
    
    //买东西
    public void Buy(string name)
    {
        
    }
    //卖东西
    public void Sold(string name)
    {


    }
}
