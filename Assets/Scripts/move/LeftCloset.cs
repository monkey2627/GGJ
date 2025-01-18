using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCloset : MonoBehaviour
{
    public static LeftCloset Instance;
    public Transform FengRenJiPos;//缝纫机位置
    public Transform materialPos;//材料位置
    public Transform productPos;//成品位置
    public Transform leftCloestPos;//左侧架子位置
    private void Awake()
    {
        Instance = this;
    }
    //点击左侧柜子，调用这个方法
    private void OnMouseDown()
    {
        Debug.Log("点击左侧架子");
        Debug.Log(player.instance.choosedObj);
        if (player.instance.choosedObj != null)//选择材料了
        {
            int mark = int.Parse(player.instance.choosedObj.name);
            Npc npc= NpcManager.Instance.FindHaveTimeNpc();
            if (npc!=null)//有空闲的Npc
            {
                npc.Move(productPos.position, () =>
                {
                    Debug.Log("从成品位置移动到左边架子");

                    
                    npc.gameObject.transform.Find("material").GetComponent<SpriteRenderer>().sprite = OrderManager.instance.objects[mark].sprite;
                    
                    npc.Move(leftCloestPos.position, () =>
                    {
                        OrderManager.instance.objects[mark].inShelves += 1;
                        OrderManager.instance.RefreshBoardSprite(mark);
                        npc.gameObject.transform.Find("material").GetComponent<SpriteRenderer>().sprite = null;
                        OrderManager.instance.PortObject2Guizi(mark);
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
