using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loom : MonoBehaviour
{
    public static loom Instance;
    public Transform zhibujiPos;//制布机位置
    public GameObject rightClose;
    public GameObject rightFar;
    private void Awake()
    {
        Instance = this;
    }
    private void OnMouseDown()
    {
        Debug.Log("点击织布机");
        Debug.Log(player.instance.choosedObj);
        if (player.instance.choosedObj != null)//选择材料了
        {
            //WorldMaterial wm = worldMaterial
            //根据名字判断选择的哪个
            int mark = int.Parse(player.instance.choosedObj.name);
            Npc npc= NpcManager.Instance.FindHaveTimeNpc();
            if (npc!=null)//有空闲的Npc
            {
                Vector3 pos1;
                if (mark >= 5)
                {
                    pos1 = rightFar.transform.position;
                }
                else
                {
                    pos1 = rightClose.transform.position;
                }
                //起点
                npc.Move(pos1, () => 
                {
                    //wm.OnSelected();//隐藏架子材料
                    OrderManager.instance.objects[mark].inShelves -= 1;
                    OrderManager.instance.RefreshBoardSprite(mark);
                    // npc.worldMaterials[mark].SetActive(true);//npc上的材料显示出来
                    npc.gameObject.transform.Find("material").GetComponent<SpriteRenderer>().sprite = OrderManager.instance.objects[mark].sprite;
                    npc.Move(zhibujiPos.position, () =>
                    {
                        //放下
                        npc.gameObject.transform.Find("material").GetComponent<SpriteRenderer>().sprite = null;
                        OrderManager.instance.AddIntoLoom(mark);
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
