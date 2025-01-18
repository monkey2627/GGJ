using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Npc : MonoBehaviour
{
    public int npcId;
    public bool hasTime=true;//�Ƿ���ʱ��������
    private NavMeshAgent agent;
    private Vector3 oriPos;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        oriPos = transform.position;
    }
    public void MoveToStart(UnityAction action)
    {
        Move(oriPos, action);
    }
    public void Move(Vector3 pos, UnityAction action)
    {
        hasTime = false;
        agent.destination = pos;
        StartCoroutine(OnMove(pos,action));
    }
    /// <summary>
    /// hasTime�����¼������
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    IEnumerator OnMove(Vector3 pos,UnityAction action)//��ɺ�ִ�е��¼�
    {
        while (Vector3.Distance(transform.position, pos) > 0.5f)
        {
            yield return null;
        }
        //����Ŀ�ĵ�
        action?.Invoke();
    }
    //public void DoSomething(UnityAction action)
    //{
    //    hasTime = false;
    //    StartCoroutine(OnDoSomething(action));
    //}
    //IEnumerator OnDoSomething(UnityAction action)
    //{
    //    action?.Invoke();
    //    yield return null;
    //    hasTime = true;
    //}
}
