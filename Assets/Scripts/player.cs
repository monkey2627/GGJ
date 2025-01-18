using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{
    public static player instance;
    public float money;//���ں��е�Ǯ
    public List<GameObject> sprites;//����ӵ�е�С����
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
                // �����������ཻ������������¼�
                GameObject clickedObject = hit.collider.gameObject;
                if (Input.GetKeyDown(KeyCode.W))
                {
                    //����
                    money += OrderManager.instance.objects[int.Parse(clickedObject.name)].sellprice;
                    moneyText.text = ((int)money).ToString();

                }else if (Input.GetKeyDown(KeyCode.D)){
                    //����
                    if(money < OrderManager.instance.objects[int.Parse(clickedObject.name)].buyprice)
                    {
                        //��ʾ��Ҳ���
                    }
                    //����
                    money -= OrderManager.instance.objects[int.Parse(clickedObject.name)].buyprice;
                    moneyText.text = ((int)money).ToString();

                }
                if (Input.GetMouseButtonDown(0))
                {
                    //�����������Ѿ�������ɵĶ���,����ɶ���
                    if(clickedObject.name == "order")
                    {
                        choosedObj = null;
                        if(OrderManager.instance.objDic[clickedObject].complete == 1)
                            OrderManager.instance.FinishOrder(clickedObject);
                    }else if (clickedObject.layer == 14)//�����object,��layer��
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
    
    //����
    public void Buy(string name)
    {
        
    }
    //������
    public void Sold(string name)
    {


    }
}
