using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkShop : MonoBehaviour
{
    public static WorkShop instance;
    public Transform FengRenJiPos;//�Ʋ���λ��
    public GameObject left;
    public GameObject rightClose;
    public GameObject rightFar;

    private void Awake()
    {
        instance = this;
    }
    private void OnMouseDown()
    {
        Debug.Log("������һ�");
        Debug.Log(player.instance.choosedObj);
        if (player.instance.choosedObj != null)//ѡ�������
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
            if (npc!=null)//�п��е�Npc
            {
                //�����Ǹ���Ŀ�ĵ�
                npc.Move(pos1, () => 
                {
                    Debug.Log("�ƶ�������λ��");
                    OrderManager.instance.objects[mark].inShelves -= 1;
                    OrderManager.instance.RefreshBoardSprite(mark);
                    npc.gameObject.transform.Find("material").GetComponent<SpriteRenderer>().sprite = OrderManager.instance.objects[mark].sprite;
                    npc.Move(FengRenJiPos.position, () =>
                    {

                        npc.gameObject.transform.Find("material").GetComponent<SpriteRenderer>().sprite = null;
                        OrderManager.instance.AddIntoWorkShop(mark);
                        //��ȥԭλ��
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
