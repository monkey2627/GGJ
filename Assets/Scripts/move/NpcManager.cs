using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    public static NpcManager Instance;
    public List<Npc> npcs=new List<Npc>();
    private void Awake()
    {
        Instance = this;
    }
    public Npc FindHaveTimeNpc()
    {
        Npc temp = npcs.Find((n) => n.hasTime);
        return temp;
    }
}
