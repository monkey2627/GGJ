using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Loom : MonoBehaviour
{
    public static Loom Instance;
    public Transform loompos;//�Ʋ���λ��
    public GameObject rightClose;
    public GameObject[] forShow;


    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
    }
    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {

            //ѡ�б����������

        
        Debug.Log("���loom");
        Debug.Log(player.instance.choosedObj);   
        Vector3 pos1;
        Npc npc;
        int mark;
        if (player.instance.choosedObj != null)//ѡ�������
        {

            mark = int.Parse(player.instance.choosedObj.name);
            if (mark >= 9)
            {
                return;
            }
            else if (mark >= 5)
            {
                return;
            }
            else
            {
                //ֻ�����ܷ���ȥ
                pos1 = rightClose.transform.position;
            }
            npc = NpcManager.Instance.FindHaveTimeNpc();
            if (npc != null)//�п��е�Npc
            {
                npc.SetPos(pos1, loompos.position, 0, mark);
            }
        }
    }}
}
