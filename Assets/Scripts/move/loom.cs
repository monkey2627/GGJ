using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Loom : MonoBehaviour
{
    public static Loom Instance;
    public Transform loompos;//制布机位置
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

            //选中被点击的物体

        
        Debug.Log("点击loom");
        Debug.Log(player.instance.choosedObj);   
        Vector3 pos1;
        Npc npc;
        int mark;
        if (player.instance.choosedObj != null)//选择材料了
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
                //只有线能放上去
                pos1 = rightClose.transform.position;
            }
            npc = NpcManager.Instance.FindHaveTimeNpc();
            if (npc != null)//有空闲的Npc
            {
                npc.SetPos(pos1, loompos.position, 0, mark);
            }
        }
    }}
}
