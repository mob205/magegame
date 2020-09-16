using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffable : MonoBehaviour
{
    List<Buff> buffs = new List<Buff>();

    public void AddBuff(Buff buff)
    {
        buffs.Add(buff);
    }
    public void RemoveBuff(Buff buff)
    {
        buffs.Remove(buff);
    }
}
