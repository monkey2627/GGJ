using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{
    public float money;//���ں��е�Ǯ
    public List<GameObject> sprites;//����ӵ�е�С����
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
                // �����������ཻ������������¼�
                GameObject clickedObject = hit.collider.gameObject;
                if (Input.GetKeyDown(KeyCode.W))
                {
                    //����


                }else if (Input.GetKeyDown(KeyCode.D)){
                    //����

                }

                if (Input.GetMouseButtonDown(0))
                {
            
                }
        
        
        }
        



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
