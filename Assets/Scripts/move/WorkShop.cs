using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkShop : MonoBehaviour
{
    public static WorkShop instance;
    public Transform FengRenJiPos;//制布机位置
    public GameObject left;
    public GameObject rightClose;
    public GameObject rightFar;

    private void Awake()
    {
        instance = this;
    }
    private void OnMouseDown()
    {
        Debug.Log("点击缝纫机");
        Debug.Log(player.instance.choosedObj);
        if (player.instance.choosedObj != null)//选择材料了
        {
            Vector3 pos1;
            int mark = int.Parse(player.instance.choosedObj.name);
            if(mark >= 9)
            {
                pos1 = left.transform.position;
            }else if(mark >= 5)
            {
                pos1 = rightFar.transform.position;
            }
            else
            {
                pos1 = rightClose.transform.position;
            }
            Npc npc = NpcManager.Instance.FindHaveTimeNpc();
            if (npc!=null)//有空闲的Npc
            {
                //后面那个是目的地
                npc.Move(pos1, () => 
                {
                    Debug.Log("移动到材料位置");
                    OrderManager.instance.objects[mark].inShelves -= 1;
                    OrderManager.instance.RefreshBoardSprite(mark);
                    npc.gameObject.transform.Find("material").GetComponent<SpriteRenderer>().sprite = OrderManager.instance.objects[mark].sprite;
                    npc.Move(FengRenJiPos.position, () =>
                    {

                        npc.gameObject.transform.Find("material").GetComponent<SpriteRenderer>().sprite = null;
                        OrderManager.instance.AddIntoWorkShop(mark);
                        //回去原位置
                        npc.MoveToStart(() =>
                        {
                            npc.hasTime = true;
                        });
                    });
                });
            }
        }
    }
}
