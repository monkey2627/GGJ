using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loom : MonoBehaviour
{
    public static loom Instance;
    public Transform zhibujiPos;//�Ʋ���λ��
    public GameObject rightClose;
    public GameObject rightFar;
    private void Awake()
    {
        Instance = this;
    }
    private void OnMouseDown()
    {
        Debug.Log("���֯����");
        Debug.Log(player.instance.choosedObj);
        if (player.instance.choosedObj != null)//ѡ�������
        {
            //WorldMaterial wm = worldMaterial
            //���������ж�ѡ����ĸ�
            int mark = int.Parse(player.instance.choosedObj.name);
            Npc npc= NpcManager.Instance.FindHaveTimeNpc();
            if (npc!=null)//�п��е�Npc
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
                //���
                npc.Move(pos1, () => 
                {
                    //wm.OnSelected();//���ؼ��Ӳ���
                    OrderManager.instance.objects[mark].inShelves -= 1;
                    OrderManager.instance.RefreshBoardSprite(mark);
                    // npc.worldMaterials[mark].SetActive(true);//npc�ϵĲ�����ʾ����
                    npc.gameObject.transform.Find("material").GetComponent<SpriteRenderer>().sprite = OrderManager.instance.objects[mark].sprite;
                    npc.Move(zhibujiPos.position, () =>
                    {
                        //����
                        npc.gameObject.transform.Find("material").GetComponent<SpriteRenderer>().sprite = null;
                        OrderManager.instance.AddIntoLoom(mark);
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
