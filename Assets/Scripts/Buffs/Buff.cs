using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : MonoBehaviour
{
    public Buffable target;
    public bool isApplied;
    public virtual void ApplyBuff()
    {
         
    }
    public virtual void RemoveBuff()
    {

    }
}
