using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showGuide : MonoBehaviour
{
    GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.Find("orderIntroPanel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Show()
    {
        panel = OrderManager.instance.panel;
        
        Order o = OrderManager.instance.objDic[gameObject];
        for(int i = 0; i < 3; i++)
        {
            Debug.Log((int)o.objects[i].name);
            Debug.Log(panel.transform.GetChild(i + 1).name);
            panel.transform.GetChild(i+1).gameObject.GetComponent<Image>().sprite = OrderManager.instance.combineSprites[(int)o.objects[i].name-11];
        }
        
        panel.SetActive(true);


        
    }
}
