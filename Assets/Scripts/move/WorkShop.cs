using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorkShop : MonoBehaviour
{
    public static WorkShop instance;
    public Transform workShop;//制布机位置
    public GameObject left;
    public GameObject rightClose;
    public GameObject rightFar;
    public GameObject[] forShow;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
    }
    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 pos1;
            Npc npc;
            int mark;
            Debug.Log("点击workshop");
            Debug.Log(player.instance.choosedObj);
            if (player.instance.choosedObj != null)//选择材料了
            {

                mark = int.Parse(player.instance.choosedObj.name);
                if (mark >= 9)
                {
                    pos1 = left.transform.position;
                }
                else if (mark >= 5)
                {
                    pos1 = rightFar.transform.position;
                }
                else
                {
                    pos1 = rightClose.transform.position;
                }
                npc = NpcManager.Instance.FindHaveTimeNpc();
                if (npc != null)//有空闲的Npc
                {
                    npc.SetPos(pos1, workShop.position, 1, mark);
                }
            }

        }
    }
}
