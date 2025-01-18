using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCloset : MonoBehaviour
{
    public static LeftCloset Instance;
    public Transform FengRenJiPos;//���һ�λ��
    public Transform materialPos;//����λ��
    public Transform productPos;//��Ʒλ��
    public Transform leftCloestPos;//������λ��
    private void Awake()
    {
        Instance = this;
    }
    //��������ӣ������������
    private void OnMouseDown()
    {
        Debug.Log("���������");
        Debug.Log(player.instance.choosedObj);
        if (player.instance.choosedObj != null)//ѡ�������
        {
            int mark = int.Parse(player.instance.choosedObj.name);
            Npc npc= NpcManager.Instance.FindHaveTimeNpc();
            if (npc!=null)//�п��е�Npc
            {
                npc.Move(productPos.position, () =>
                {
                    Debug.Log("�ӳ�Ʒλ���ƶ�����߼���");

                    
                    npc.gameObject.transform.Find("material").GetComponent<SpriteRenderer>().sprite = OrderManager.instance.objects[mark].sprite;
                    
                    npc.Move(leftCloestPos.position, () =>
                    {
                        OrderManager.instance.objects[mark].inShelves += 1;
                        OrderManager.instance.RefreshBoardSprite(mark);
                        npc.gameObject.transform.Find("material").GetComponent<SpriteRenderer>().sprite = null;
                        OrderManager.instance.PortObject2Guizi(mark);
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
