using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Npc : MonoBehaviour
{
    public int npcId;
    public bool hasTime=true;//是否有时间做事情
    public Vector3 oriPos;

    public Vector3 firstPos;
    public Vector3 secondPos;

    public bool goingToFirstPos = false;
    public bool goingTosecondPos = false;
    public bool goingToOri = false;
    public int mode;//现在是哪种情况
    public int mark;
    private void Awake()
    {
     
    }
    private void Update()
    {
        if (goingToFirstPos)
        {
            if ((gameObject.transform.position - firstPos).magnitude < 0.01)
            {
                goingToFirstPos = false; 
                goingTosecondPos = true;

                if (mode == 0)
                { //先到货架到再到织布机，只可能背线
                    AkSoundEngine.PostEvent("Player_Grab", gameObject);

                }
                else if(mode == 1)
                {//先货架再到workshop
                   OrderManager.instance.objects[mark].inShelves -= 1;
                   OrderManager.instance.RefreshBoardSprite(mark);
                   AkSoundEngine.PostEvent("Player_Grab", gameObject);
                }
                else if(mode == 2)
                {
                    //先织布机再货架
                    OrderManager.instance.objects[mark].inLoom -= 1;
                    Debug.Log("inLoom: " + OrderManager.instance.objects[mark].inLoom);
                    OrderManager.instance.RefreashLoomPanel();
                    AkSoundEngine.PostEvent("Player_Grab", gameObject);
                }
                else if (mode == 3)
                {
                    //先workshop后货架
                    OrderManager.instance.objects[mark].inWorkShop -= 1;
                    OrderManager.instance.RefreshWorkShopSprite(mark);
                    AkSoundEngine.PostEvent("Player_Grab", gameObject);
                }
                gameObject.transform.Find("material").GetComponent<SpriteRenderer>().sprite = OrderManager.instance.objects[mark].sprite;
                gameObject.transform.DOMove(secondPos, 1f, false);
     
            }
        }
        else if (goingTosecondPos)
        {
            if ((gameObject.transform.position - secondPos).magnitude < 0.01)
            {
                if (mode == 0)
                { //先到货架到再到织布机，只可能背线
                    OrderManager.instance.AddIntoLoom(mark);
                }
                else if (mode == 1)
                {//先货架再到workshop
                    OrderManager.instance.AddIntoWorkShop(mark);
                        }
                else if (mode == 2)
                {
                    //先织布机再货架
                    OrderManager.instance.PortObject2Guizi(mark);
                }
                else if (mode == 3)
                {
                    //先workshop后货架
                    OrderManager.instance.PortObject2Guizi(mark);
                }
                gameObject.transform.Find("material").GetComponent<SpriteRenderer>().sprite = null;
                gameObject.transform.DOMove(oriPos, 1f, false);
                goingTosecondPos = false;
                goingToOri = true;
            }
        }
        else if (goingToOri)
        {
            if ((gameObject.transform.position - oriPos).magnitude < 0.01)
            {
                //结束移动
                AkSoundEngine.PostEvent("Player_Stop", gameObject);
                hasTime = true;
                goingToOri = false;
            }
        }

    }
    private void Start()
    {
        oriPos = transform.position;
    }

    public void SetPos(Vector3 f,Vector3 s,int m,int mm)
    {
        //开始移动
        AkSoundEngine.PostEvent("Player_Move", gameObject);
        firstPos = f;
        secondPos = s;
        gameObject.transform.DOMove(f, 1f, false);
        goingToFirstPos = true;
        goingTosecondPos = false;
        goingToOri = false;
        hasTime = false;
        mode = m;
        mark = mm;

    }
   
}
