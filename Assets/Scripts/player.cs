using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{
    public float money;//现在含有的钱
    public List<GameObject> sprites;//现在拥有的小精灵
    public TMP_Text moneyText;
    public TMP_Text spriteNumberText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
                // 射线与物体相交，处理鼠标点击事件
                GameObject clickedObject = hit.collider.gameObject;
                if (Input.GetKeyDown(KeyCode.W))
                {
                    //出售


                }else if (Input.GetKeyDown(KeyCode.D)){
                    //购买

                }

                if (Input.GetMouseButtonDown(0))
                {
            
                }
        
        
        }
        



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
