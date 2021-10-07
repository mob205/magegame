using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenBuff : Buff
{
    public float modifier;

    public override void ApplyBuff()
    {
        Debug.Log("Not implemented");
        
        //if (isApplied)
        //{
        //    Debug.Log("Buff already applied.");
        //}
        //if (!target)
        //{
        //    Debug.Log("No target to buff.");
        //    return;
        //}
        //moveScript = target.GetComponent<IMove>();
        //if (moveScript == null)
        //{
        //    Debug.Log("No movement script found on target.");
        //    return;
        //}
        //moveScript.MoveSpeed *= modifier;
        //target.AddBuff(this);
        //isApplied = true;
    }
    public override void RemoveBuff()
    {
        //if (isApplied)
        //{
        //    moveScript.MoveSpeed /= modifier;
        //    target.RemoveBuff(this);
        //    isApplied = false;
        //}
        //else
        //{
        //    Debug.Log("Buff not applied.");
        //}
    }
}
