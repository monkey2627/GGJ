using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class click : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 1)
            OnSingleClick();
        else if (clickCount == 2)
            OnDoubleClick();
        else if (clickCount > 2)
            OnMultiClick();
    }

    void OnSingleClick()
    {
        Debug.Log("Single Clicked");
    }

    void OnDoubleClick()
    {
        Debug.Log("Double Clicked");
    }

    void OnMultiClick()
    {
        Debug.Log("MultiClick Clicked");
    }
    float time = 0;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.realtimeSinceStartup - time < 0.2f)
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    // 射线与物体相交，处理鼠标点击事件
                    GameObject clickedObject = hit.collider.gameObject;
                    if (clickedObject.name == "WorkShop")
                    {
                        OrderManager.instance.ClearWorkShop();
                        Debug.Log("clearWorkShop");
                    }

}                }
            else
                time = Time.realtimeSinceStartup;
        }
    }
}

